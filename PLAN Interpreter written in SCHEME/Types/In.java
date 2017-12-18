package Types;

import java.util.List;
import java.util.Scanner;

public class In {
	List<String> tokens;
	Variables vars;
	int depth;
	String id;

	public In(List tokens,Variables vars, int depth) {
		this.tokens = tokens;
		this.depth = depth;
		this.vars = vars;
	}

	public void Parse() {
		if (Print.printTree)
			Print.tree(this.getClass().getName(), tokens, depth);
		id = tokens.get(1);
	}

	public void Exec() {
		System.out.print(": ");
		Scanner scanner = new Scanner(System.in);
		String input = scanner.nextLine();
		int value = Integer.parseInt(input);
		if (value < 0) {
			Print.error(this.getClass().getName() + " ERROR: Negative input");
		}
		vars.AssignVariable(id, value);
	}

	public void Exec(Variables vars2) {
		// TODO Auto-generated method stub
		
	}
}
