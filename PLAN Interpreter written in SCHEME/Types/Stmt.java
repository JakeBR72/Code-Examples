package Types;



import java.util.List;

public class Stmt {
	List<String> tokens;
	Variables vars;
	int depth;
	Assign assign;
	If ifstmt;
	Loop loop;
	In in;
	Out out;

	public Stmt(List tokens,Variables vars, int depth) {
		this.tokens = tokens;
		this.depth = depth;
		this.vars = vars;
	}

	public void Parse() {
		if(Print.printTree) Print.tree(this.getClass().getName(),tokens, depth);
		if(tokens.get(0).substring(0, 2).equals("ID")) {
			assign = new Assign(tokens,vars,depth+1);
			assign.Parse();
		}else if(tokens.get(0).equals("IF")) {
			ifstmt = new If(tokens,vars,depth+1);
			ifstmt.Parse();
		}else if(tokens.get(0).equals("WHILE")) {
			loop = new Loop(tokens,vars,depth+1);
			loop.Parse();
		}else if(tokens.get(0).equals("INPUT")) {
			in = new In(tokens,vars,depth+1);
			in.Parse();
		}else if(tokens.get(0).equals("OUTPUT")) {
			out = new Out(tokens,vars,depth+1);
			out.Parse();
		}else {
			Print.error(this.getClass().getName() + " ERROR: Unexpected character '"+tokens.get(0)+"'");
						
		}
	}

	public void Exec() {
		if(ifstmt != null) {
			ifstmt.Exec();
		}
		else if (out != null) {
			out.Exec();
		}
		else if (in != null) {
			in.Exec();
		}
		else if (loop != null) {
			loop.Exec();
		}
		else if (assign != null) {
			assign.Exec();
		}
	}

}
