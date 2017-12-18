package Types;



import java.util.List;

public class Stmtseq {
	List<String> tokens;
	Variables vars;
	int depth;
	Stmt stmt;
	Stmtseq stmtseq;
	
	public Stmtseq(List tokens,Variables vars, int depth) {
		this.tokens = tokens;
		this.depth = depth;
		this.vars = vars;
	}	
	
	public void Parse() {
		if(Print.printTree) Print.tree(this.getClass().getName(),tokens, depth);
		if(tokens.size() == 0) {
			return;
		}
		int statementCount = 0;
		if(tokens.get(0).contains("ID[") 
				|| tokens.get(0).equals("IF")
				|| tokens.get(0).equals("WHILE")
				|| tokens.get(0).equals("INPUT")
				|| tokens.get(0).equals("OUTPUT")) {
			statementCount++;
		}else {
			Print.error(this.getClass().getName() + " ERROR: Invalid stmt : " + tokens);
		}
		int index = 1;
		String t = tokens.get(index);
		while(index < tokens.size() && statementCount > 0) {
			t = tokens.get(index);
			if( tokens.get(index).equals("IF")
					|| tokens.get(index).equals("WHILE")
					|| tokens.get(index).equals("INPUT")
					|| tokens.get(index).equals("OUTPUT")
					|| tokens.get(index).equals("RETURN")
					|| (tokens.get(index).contains("ID[") && tokens.get(index+1).equals("ASSIGN"))) {
				statementCount++;
			}
			else if(tokens.get(index).equals("SEMICOLON")) {
				statementCount--;
				if(statementCount == 0) {
					stmt = new Stmt(tokens.subList(0, index+1), vars, depth+1);
					stmt.Parse();
					break;
				}
			}
			index++;
		}
		if(statementCount > 0) {
			Print.error(this.getClass().getName() + " ERROR: Invalid stmt : " + tokens);
		}
		if(index+1 < tokens.size() && tokens.subList(index+1, tokens.size()).size() > 2) {
			stmtseq = new Stmtseq(tokens.subList(index+1, tokens.size()),vars, depth+1);
			stmtseq.Parse();
		}		
	}
	
	public void Exec() {
		stmt.Exec();
		if(stmtseq != null) {
			stmtseq.Exec();
		}
	}

}
