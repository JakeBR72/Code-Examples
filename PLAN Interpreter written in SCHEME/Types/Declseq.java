package Types;

import java.util.List;

public class Declseq {
	List<String> tokens;
	Variables vars;
	int depth;
	Decl decl;
	Declseq declseq;

	public Declseq(List tokens, Variables vars, int depth) {
		this.tokens = tokens;
		this.depth = depth;
		this.vars = vars;
	}

	public void Parse() {
		if (Print.printTree)
			Print.tree(this.getClass().getName(), tokens, depth);
		int index = 0;
		if(tokens.size() == 0) {
			return;
		}
		if (tokens.get(index).equals("INT")) {
			int semicolonIndex = tokens.indexOf("SEMICOLON");
			if (semicolonIndex > 0) {
				decl = new Decl(tokens.subList(0, semicolonIndex + 1), vars, depth + 1);
				decl.Parse();
				if (semicolonIndex + 1 < tokens.size()) {
					List declSeqTokens = tokens.subList(semicolonIndex + 1, tokens.size());
					if (!declSeqTokens.isEmpty()) {
						declseq = new Declseq(declSeqTokens, vars, depth + 1);
						declseq.Parse();
					}
				}
			} else {
				Print.error(this.getClass().getName() + " ERROR: Missing ';' in declaration");

			}
		} else if (tokens.get(0).equals("FUNCTION")) {
			index += 2;

			String two = tokens.get(index - 2);
			String one = tokens.get(index - 1);
			String zero = tokens.get(index);
			while (!tokens.get(index - 1).equals("END") || !tokens.get(index - 2).equals("SEMICOLON")
					|| !tokens.get(index).equals("SEMICOLON")) {
				index++;
				two = tokens.get(index - 2);
				one = tokens.get(index - 1);
				zero = tokens.get(index);
			}
			decl = new Decl(tokens.subList(0, index+1), vars, depth + 1);
			decl.Parse();
			if (index+2 < tokens.size()-1) {
				declseq = new Declseq(tokens.subList(index+1, tokens.size()),vars,depth+1);
				declseq.Parse();
			}
		}

	}

	public void Exec() {

	}
}
