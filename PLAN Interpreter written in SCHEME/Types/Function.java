package Types;

import java.util.List;

public class Function implements Cloneable {
	List<String> tokens;
	String name;
	Variables vars;
	Idlist idlist;
	Declseq declseq;
	Stmtseq stmtseq;
	Expr returnExpr;
	int params;
	int depth;

	Function(List tokens) {
		this.tokens = tokens;
		vars = new Variables();
	}

	Function(Function func, int depth) {
		vars = new Variables();
		this.depth = depth;
		this.tokens = func.tokens;
		this.name = func.name;
		this.idlist = new Idlist(func.idlist.tokens, vars, 1);
		this.declseq = new Declseq(func.declseq.tokens, vars, 1);
		this.stmtseq = new Stmtseq(func.stmtseq.tokens, vars, 1);
		this.returnExpr = new Expr(func.returnExpr.tokens, vars, 1);
		this.params = func.params;

		this.idlist.Parse();
		this.declseq.Parse();
		this.stmtseq.Parse();
		this.stmtseq.Parse();
		this.returnExpr.Parse();
	}

	public void Parse() {
		if (Print.printTree)
			Print.tree(this.getClass().getName(), tokens, depth);
		if (tokens.get(0).equals("FUNCTION")) {
			name = tokens.get(1).substring(3, tokens.get(1).length() - 1);
		} else {
			Print.error(this.getClass().getName() + " ERROR: Expected \'fun\' got " + tokens);
		}
		if (tokens.get(2).equals("LEFTPAREN")) {
			if (tokens.indexOf("RIGHTPAREN") == -1) {
				Print.error(this.getClass().getName() + " ERROR: Missing \')\' ");
			}
			idlist = new Idlist(tokens.subList(3, tokens.indexOf("RIGHTPAREN")), vars, depth + 1);
		} else {
			Print.error(this.getClass().getName() + " ERROR: Expected \'(\' got " + tokens);
		}
		params = vars.list.size();
		declseq = new Declseq(tokens.subList(tokens.indexOf("RIGHTPAREN") + 1, tokens.indexOf("BEGIN")), vars,
				depth + 1);
		if(!tokens.contains("RETURN")) {
			Print.error(this.getClass().getName() + " ERROR: No return statement");
		}
		stmtseq = new Stmtseq(tokens.subList(tokens.indexOf("BEGIN") + 1, tokens.lastIndexOf("RETURN")), vars,
				depth + 1);
		returnExpr = new Expr(tokens.subList(tokens.indexOf("RETURN") + 1, tokens.lastIndexOf("END") - 1), vars,
				depth + 1);

		idlist.Parse();
		declseq.Parse();
		stmtseq.Parse();
		returnExpr.Parse();
	}

	public void Exec() {
		if (stmtseq.tokens.size() > 0) {
			stmtseq.Exec();
		}
		returnExpr.Exec();
	}
}
