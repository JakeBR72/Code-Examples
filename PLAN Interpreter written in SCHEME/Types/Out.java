package Types;



import java.util.ArrayList;
import java.util.List;

public class Out {
	public int value;
	Variables vars;
	int depth;
	Expr expr;
	List tokens;

	public Out(List<String> list,Variables vars, int depth) {
		this.tokens = list;
		this.depth = depth;
		this.vars = vars;
	}

	public void Parse() {
		if (Print.printTree)
			Print.tree(this.getClass().getName(), tokens, depth);
		if (tokens.get(0).equals("OUTPUT")) {
			expr = new Expr(tokens.subList(1, tokens.indexOf("SEMICOLON")),vars, depth + 1);
			expr.Parse();
		} else {
			expr = new Expr(tokens,vars, depth + 1);
			expr.Parse();
		}
	}

	public void Exec() {
		expr.Exec();
		value = expr.value;
		Print.line(""+value);
	}

	public void Exec(Variables vars2) {
		// TODO Auto-generated method stub
		
	}
}
