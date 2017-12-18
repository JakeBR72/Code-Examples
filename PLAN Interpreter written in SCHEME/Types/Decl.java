package Types;



import java.util.List;

public class Decl {
	List<String> tokens;
	Variables vars;
	int depth;
	Idlist idList;
	
	public Decl(List tokens, Variables vars, int depth) {
		this.tokens = tokens;
		this.depth = depth;
		this.vars = vars;
	}	
	
	public void Parse() {
		if(Print.printTree) Print.tree(this.getClass().getName(),tokens, depth);
		if(tokens.get(0).equals("INT")) {
			idList = new Idlist(tokens.subList(1, tokens.indexOf("SEMICOLON")), vars, depth+1);
			idList.Parse();
		}
		else if(tokens.get(0).equals("FUNCTION")) {
  			Function func = new Function(tokens);
			Prog.functions.add(func);
			func.Parse();			
		}
		else {
			Print.error(this.getClass().getName() + " ERROR: Missing 'int' in declaration");
			
		}
	}
	
	public void Exec() {
		
	}
}
