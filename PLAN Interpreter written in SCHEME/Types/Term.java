package Types;

import java.util.List;

public class Term {
	Variables vars;
	public int value;
	int depth;
	Factor factor;
	String connector;
	Term term;
	List tokens;

	public Term(List tokens, Variables vars, int depth) {
		this.tokens = tokens;
		this.depth = depth;
		this.vars = vars;
	}

	public void Parse() {
		if (Print.printTree)
			Print.tree(this.getClass().getName(), tokens, depth);

		int index = 0;
		int parenCount = 0;
		if (tokens.contains("ASTERISK")) {
			while (parenCount > 0 || !tokens.get(index).equals("ASTERISK")) {
				if (tokens.get(index).equals("LEFTPAREN")) {
					parenCount++;
				} else if (tokens.get(index).equals("RIGHTPAREN")) {
					parenCount--;
				}
				if (index == tokens.size() - 1) {
					if (parenCount > 0) {
						Print.error(this.getClass().getName() + " ERROR: Mismatching parenthesis");

					}
					factor = new Factor(tokens, vars, depth + 1);
					factor.Parse();
					return;
				}
				index++;
			}
			factor = new Factor(tokens.subList(0, index), vars, depth + 1);
			term = new Term(tokens.subList(index + 1, tokens.size()), vars, depth + 1);
			factor.Parse();
			term.Parse();
			connector = "*";
		} else {
			factor = new Factor(tokens, vars, depth + 1);
			factor.Parse();
		}
	}

	public void Exec() {
		factor.Exec();
		if (term != null) {
			term.Exec();
			value = factor.value * term.value;
		} else {
			value = factor.value;
		}
	}

}
