import java.util.List;

import Types.Out;
import Types.Prog;

public class Interpreter {
	List types;

	public Interpreter(List types) {
		this.types = types;
		Interpret();
	}

	public void Interpret() {
		((Prog) types.get(0)).Exec();
	}
}
