package Types;

import java.util.List;

public class Factor {
	public int value;
	Variables vars;
	int depth;
	Expr expr;
	String constant;
	String id = "";
	List tokens;
	String functionName;
	Function func;
	Exprlist exprlist;

	public Factor(List tokens, Variables vars, int depth) {
		this.tokens = tokens;
		this.depth = depth;
		this.vars = vars;
	}

	public void Parse() {
		if (Print.printTree)
			Print.tree(this.getClass().getName(), tokens, depth);
		if (tokens.get(0).equals("LEFTPAREN")) {
			expr = new Expr(tokens.subList(1, tokens.lastIndexOf("RIGHTPAREN")), vars, depth + 1);
			expr.Parse();
		} else if (tokens.get(0).equals("CALL")) {
			functionName = tokens.get(1).toString().substring(3, tokens.get(1).toString().length() - 1);

			exprlist = new Exprlist(tokens.subList(tokens.indexOf("LEFTPAREN") + 1, tokens.lastIndexOf("RIGHTPAREN")),
					vars, depth + 1);
			exprlist.Parse();
		} else {
			if (tokens.size() > 1) {
				Print.error(
						this.getClass().getName() + " ERROR: Unexpected token " + tokens.subList(1, tokens.size()));
			}
			if (tokens.get(0).toString().charAt(0) == 'I') {
				id = (String) tokens.get(0);
			} else {
				constant = (String) tokens.get(0);
			}
		}

	}

	public void Exec() {
		if (expr != null) {
			expr.Exec();
			value = expr.value;
		} else if (functionName != null) {
			for (int i = 0; i < Prog.functions.size(); i++) {
				if (Prog.functions.get(i).name.equals(functionName)) {
					func = new Function(Prog.functions.get(i),depth+1);
					break;
				}
			}
			// Add variable values and Exec function
			exprlist.Exec();
			for (int i = 0; i < exprlist.values.size(); i++) {
				func.vars.list.get(i).value = exprlist.values.get(i).intValue();
				func.vars.list.get(i).initialized = true;
			}
			func.Exec();
			value = func.returnExpr.value;
		} else {
			if (!id.equals("")) {
				if (vars.Initialized(id)) {
					value = vars.Valueof(id);
				} else {
					Print.error(this.getClass().getName() + " ERROR: Uninitialized Variable " + id);
				}
			} else {
				value = Integer.parseInt(constant);
			}
		}
	}

}
