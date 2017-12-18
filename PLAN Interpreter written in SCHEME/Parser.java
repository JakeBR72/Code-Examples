import java.util.ArrayList;
import java.util.List;

import Types.Out;
import Types.Prog;


public class Parser {
	public List types = new ArrayList<Prog>();

	public Parser(List<String> tokens) {
		types.add(new Prog(tokens, 0));
		((Prog) types.get(0)).Parse();	
	}
}
