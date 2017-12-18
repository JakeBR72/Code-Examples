package Types;



import java.util.List;

public class Cond {
	List<String> tokens;
	Variables vars;
	int depth;
	Cmpr cmpr;
	Cond cond;
	boolean value;
	
	public Cond(List tokens,Variables vars, int depth) {
		this.tokens = tokens;
		this.depth = depth;
		this.vars = vars;
	}	
	
	public void Parse() {
		if(Print.printTree) Print.tree(this.getClass().getName(),tokens, depth);
		if(tokens.get(0).equals("EXCLAMATION")) {
			if(tokens.get(1).toString().equals("LEFTPAREN") && tokens.get(tokens.size()-1).toString().equals("RIGHTPAREN")) {
				cond = new Cond(tokens.subList(2, tokens.size()-1),vars,depth+1);
				cond.Parse();
			}
			else {
				System.out.println("Condition ERROR: Parenthesis issue.");
				System.exit(1);
			}
		}
		else if (tokens.contains("OR")) {
			cmpr = new Cmpr(tokens.subList(0, tokens.indexOf("OR")),vars,depth+1);
			cond = new Cond(tokens.subList(tokens.indexOf("OR")+1, tokens.size()),vars,depth+1);
			cmpr.Parse();
			cond.Parse();
		}
		else {
			cmpr = new Cmpr(tokens,vars,depth+1);
			cmpr.Parse();
		}
	}
	
	public void Exec() {
		if(cmpr != null) {
			cmpr.Exec();
			value = cmpr.value;
			if (cond != null && !value) {
				cond.Exec();
				value = cond.value;
			}
		}
		else if (cond != null) {
			cond.Exec();
			value = !cond.value;
		}
	}

}
