package Types;



import java.util.List;

public class Cmpr {
	List<String> tokens;
	Variables vars;
	int depth;
	Expr exprL;
	Expr exprR;
	String connector;
	boolean value;
	
	public Cmpr(List tokens, Variables vars, int depth) {
		this.tokens = tokens;
		this.depth = depth;
		this.vars = vars;
	}	
	
	public void Parse() {
		if(Print.printTree) Print.tree(this.getClass().getName(),tokens, depth);
		if(tokens.contains("EQUALS")) {
			connector = "=";
			exprL = new Expr(tokens.subList(0, tokens.indexOf("EQUALS")), vars,depth+1);
			exprR = new Expr(tokens.subList(tokens.indexOf("EQUALS")+1, tokens.size()),vars,depth+1);
			exprL.Parse();
			exprR.Parse();
		}else if(tokens.contains("LESSTHAN")) {
			connector = "<";
			exprL = new Expr(tokens.subList(0, tokens.indexOf("LESSTHAN")),vars,depth+1);
			exprR = new Expr(tokens.subList(tokens.indexOf("LESSTHAN")+1, tokens.size()),vars,depth+1);
			exprL.Parse();
			exprR.Parse();			
		}else if(tokens.contains("LESSTHANEQUAL")) {
			connector = "<=";
			exprL = new Expr(tokens.subList(0, tokens.indexOf("LESSTHANEQUAL")),vars,depth+1);
			exprR = new Expr(tokens.subList(tokens.indexOf("LESSTHANEQUAL")+1, tokens.size()),vars,depth+1);
			exprL.Parse();
			exprR.Parse();			
		}
	}
	
	public void Exec() {
		exprL.Exec();
		exprR.Exec();
		if(connector.equals("<") && exprL.value < exprR.value) {
			value = true;
		}
		else if (connector.equals("=") && exprL.value == exprR.value){
			value = true;	
		}
		else if (connector.equals("<=") && exprL.value <= exprR.value) {
			value = true;
		}
		else {
			value = false;
		}
	}

}
