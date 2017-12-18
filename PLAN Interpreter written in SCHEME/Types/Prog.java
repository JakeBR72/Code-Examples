package Types;

import java.util.ArrayList;
import java.util.List;

public class Prog {
	public static List<Function> functions = new ArrayList<Function>();
	List<String> tokens;
	int depth;
	Declseq declseq;
	Stmtseq stmtseq;
	
	public Prog(List tokens, int depth) {
		this.tokens = tokens;
		this.depth = depth;
	}	
	
	public void Parse() {
		Variables global = new Variables();
		
		if(Print.printTree) Print.tree(this.getClass().getName(),tokens, depth);
		if(tokens.get(0).equals("PROGRAM")) {
			int beginCount = 1;
			int beginIndex = 1;
			String t = tokens.get(beginIndex);
			while(beginCount > 0 || !tokens.get(beginIndex-1).equals("BEGIN")) {
				t = tokens.get(beginIndex);
				if(tokens.get(beginIndex).equals("FUNCTION") || tokens.get(beginIndex).equals("WHILE")) {
					beginCount++;
				}
				if(tokens.get(beginIndex).equals("BEGIN")) {
					beginCount--;
				}
				beginIndex++;
			}
			
			if(beginIndex > 0) {
				declseq = new Declseq(tokens.subList(1, beginIndex), global, depth+1);	
				declseq.Parse();
			}else {
				Print.error(this.getClass().getName() + " ERROR: Missing 'begin'");
				
			}
			int endIndex = tokens.lastIndexOf("END");
			if(endIndex > 0) {
				stmtseq = new Stmtseq(tokens.subList(beginIndex, endIndex), global, depth+1);
				stmtseq.Parse();
			}else {
				Print.error(this.getClass().getName() + " ERROR: Missing 'end'");
				
			}
			
		}else {
			Print.error(this.getClass().getName() + " ERROR: Missing 'program'");
			
		}
		
	}
	
	public void Exec() {
		stmtseq.Exec();
	}
}
