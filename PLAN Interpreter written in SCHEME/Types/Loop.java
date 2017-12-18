package Types;



import java.util.List;

public class Loop {
	List<String> tokens;
	Variables vars;
	int depth;
	Cond cond;
	Stmtseq stmtseq;
	
	public Loop(List tokens,Variables vars, int depth) {
		this.tokens = tokens;
		this.depth = depth;
		this.vars = vars;
	}	
	
	public void Parse() {
		if(Print.printTree) Print.tree(this.getClass().getName(),tokens, depth);
		if(!tokens.get(0).equals("WHILE")) {
			Print.error(this.getClass().getName() + " ERROR: Expected 'while'");
		}
		if(!tokens.contains("BEGIN")) {
			Print.error(this.getClass().getName() + " ERROR: Missing 'begin'");
		}
		if(!tokens.contains("ENDWHILE")) {
			Print.error(this.getClass().getName() + " ERROR: Missing 'endwhile'");
		}
		cond = new Cond(tokens.subList(1, tokens.indexOf("BEGIN")),vars,depth+1);
		stmtseq = new Stmtseq(tokens.subList(tokens.indexOf("BEGIN")+1, tokens.lastIndexOf("ENDWHILE")),vars,depth+1);
		cond.Parse();
		stmtseq.Parse();
	}
	
	public void Exec() {
		cond.Exec();
		while(cond.value) {
			stmtseq.Exec();
			cond.Exec();
		}
	}

	public void Exec(Variables vars2) {
		// TODO Auto-generated method stub
		
	}
}
