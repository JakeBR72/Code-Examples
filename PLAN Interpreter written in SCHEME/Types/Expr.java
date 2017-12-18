package Types;



import java.util.List;

public class Expr {
	public int value;
	Variables vars;
	int depth;
	Term term;
	String connector;
	Expr expr;
	List tokens;

	public Expr(List tokens,Variables vars, int depth) {
		this.tokens = tokens;
		this.depth = depth;
		this.vars = vars;
	}

	public void Parse() {
		if(Print.printTree) Print.tree(this.getClass().getName(),tokens, depth);
		
		int index = 0;
		int parenCount = 0;
		if(tokens.contains("PLUS") || tokens.contains("MINUS")) {
			while(parenCount > 0 || (!(tokens.get(index).equals("PLUS") || tokens.get(index).equals("MINUS")))){
				if(tokens.get(index).equals("LEFTPAREN")) {
					parenCount++;
				}else if(tokens.get(index).equals("RIGHTPAREN")) {
					parenCount--;
				}
				if(index == tokens.size()-1) {
					if (parenCount > 0) {
						Print.error(this.getClass().getName() + " ERROR: Mismatching parenthesis");
					}
					term = new Term(tokens.subList(0, tokens.size()),vars,depth+1);
					term.Parse();
					return;
				}
				index++;
			}
			term = new Term(tokens.subList(0, index),vars,depth+1);
			expr = new Expr(tokens.subList(index+1, tokens.size()),vars,depth+1);
			term.Parse();
			expr.Parse();
			if(tokens.get(index).equals("PLUS")) {
				connector = "+";
			}else {
				connector = "-";
			}
		}else {
			term = new Term(tokens,vars,depth+1);
			term.Parse();
		}
	}

	public void Exec() {
		term.Exec();
		if (expr != null) {
			expr.Exec();
			if (connector == "+") {
				value = term.value + expr.value;
			} else {
				value = term.value - expr.value;
			}
		} else {
			value = term.value;
		}
	}
}
