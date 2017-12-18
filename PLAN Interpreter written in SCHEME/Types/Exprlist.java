package Types;

import java.util.ArrayList;
import java.util.List;

public class Exprlist {
	public ArrayList<Integer> values = new ArrayList<Integer>();
	Variables vars;
	int depth;
	List tokens;
	Expr expr;
	Exprlist exprlist;

	public Exprlist(List tokens, Variables vars, int depth) {
		this.tokens = tokens;
		this.depth = depth;
		this.vars = vars;
	}

	public void Parse() {
		if (Print.printTree)
			Print.tree(this.getClass().getName(), tokens, depth);
		if(tokens.size() == 0) {
			return;
		}
		if (tokens.contains("COMMA")) {
			expr = new Expr(tokens.subList(0, tokens.indexOf("COMMA")), vars, depth + 1);
			expr.Parse();
			exprlist = new Exprlist(tokens.subList(tokens.indexOf("COMMA") + 1, tokens.size()), vars, depth + 1);
			exprlist.Parse();
		}else {
			expr = new Expr(tokens, vars, depth + 1);
			expr.Parse();
		}

	}

	public void Exec() {
		values.clear();
		if(expr != null) {
			expr.Exec();
			values.add(expr.value);
		}
		if (exprlist != null) {
			exprlist.Exec();
			values.addAll(exprlist.values);
		}
	}

}
