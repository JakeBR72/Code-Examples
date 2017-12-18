package Types;

import java.util.List;

public class Assign {
	List<String> tokens;
	Variables vars;
	int depth;
	Expr expr;
	String id;
	
	public Assign(List tokens, Variables vars, int depth) {
		this.tokens = tokens;
		this.depth = depth;
		this.vars = vars;
	}

	public void Parse() {
		if (Print.printTree)
			Print.tree(this.getClass().getName(), tokens, depth);
		if(tokens.get(0).contains("ID[")){
			id = tokens.get(0);
		}else {
			Print.error(this.getClass().getName() + " ERROR: Unexpected character '" + tokens.get(0) + "'");
		}
		if (1 < tokens.size() - 1 && !tokens.get(1).equals("ASSIGN")) {
			Print.error(this.getClass().getName() + " ERROR: Unexpected character '" + tokens.get(0) + "'");
		}
		if (2 < tokens.size()) {
			expr = new Expr(tokens.subList(2, tokens.size()-1), vars, depth + 1);
			expr.Parse();
		}else {
			Print.error(this.getClass().getName() + " ERROR: Expected <expr>");
		}
	}

	public void Exec() {
		expr.Exec();	
		vars.AssignVariable(id, expr.value);	
	}

}
