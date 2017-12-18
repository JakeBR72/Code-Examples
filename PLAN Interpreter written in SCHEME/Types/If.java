package Types;

import java.util.List;

public class If {
	List<String> tokens;
	Variables vars;
	int depth;
	Cond cond;
	Stmtseq thenStmtseq;
	Stmtseq elseStmtseq;

	public If(List tokens,Variables vars, int depth) {
		this.tokens = tokens;
		this.depth = depth;
		this.vars = vars;
	}

	public void Parse() {
		if (Print.printTree)
			Print.tree(this.getClass().getName(), tokens, depth);
		if (tokens.contains("THEN")) {
			cond = new Cond(tokens.subList(1, tokens.indexOf("THEN")), vars, depth + 1);
			cond.Parse();
			int index = tokens.indexOf("THEN") + 1;

			int statementCount = 1;
			if (tokens.get(index).contains("ID[") 
					|| tokens.get(index).equals("IF") 
					|| tokens.get(index).equals("WHILE")
					|| tokens.get(index).equals("INPUT") 
					|| tokens.get(index).equals("OUTPUT")) {
				statementCount++;
			} else {
				Print.error(this.getClass().getName() + " ERROR: Invalid stmt");
			}
			index++;
			String t = tokens.get(index);
			while (index < tokens.size() && statementCount > 0) {
				t = tokens.get(index);
				if(tokens.get(index).equals("IF")
						|| tokens.get(index).equals("WHILE")
						|| tokens.get(index).equals("INPUT")
						|| tokens.get(index).equals("OUTPUT")
						|| tokens.get(index).equals("RETURN")
						|| (tokens.get(index).contains("ID[") && tokens.get(index+1).equals("ASSIGN"))) {
					statementCount++;
				}else if(tokens.get(index).equals("SEMICOLON") || tokens.get(index).equals("ELSE") || tokens.get(index).equals("ENDIF")) {
					statementCount--;
				}
				if (statementCount == 0) {
					thenStmtseq = new Stmtseq(tokens.subList(tokens.indexOf("THEN")+1, index+1), vars, depth + 1);
					thenStmtseq.Parse();
					break;
				}
				index++;
			}
			if (index < tokens.size() && tokens.get(index).equals("ELSE")) {
				elseStmtseq = new Stmtseq(tokens.subList(index + 1, tokens.size()-2), vars, depth + 1);
				elseStmtseq.Parse();
			}

		} else {
			Print.error(this.getClass().getName() + " ERROR: No 'then' token found");
		}

	}

	public void Exec() {
		cond.Exec();
		if (cond.value) {
			thenStmtseq.Exec();
		} else if (elseStmtseq != null) {
			elseStmtseq.Exec();
		}
	}
}
