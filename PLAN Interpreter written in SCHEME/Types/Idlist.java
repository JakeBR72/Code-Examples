package Types;



import java.util.List;

public class Idlist {
	List<String> tokens;
	Variables vars;
	int depth;
	Idlist idlist;

	public Idlist(List tokens, Variables vars, int depth) {
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
		vars.AddVariable(tokens.get(0));
		if (1 <= tokens.size() - 1 && tokens.get(1).equals("COMMA")) {
			if (2 <= tokens.size() - 1) {
				idlist = new Idlist(tokens.subList(2, tokens.size()), vars, depth + 1);
				idlist.Parse();
			}else {
				Print.error(this.getClass().getName() + " ERROR: Expected id after ',' in declaration");
								
			}
		}
	}

	public void Exec() {

	}
}
