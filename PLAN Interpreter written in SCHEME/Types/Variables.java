package Types;



import java.util.ArrayList;
import java.util.List;

public class Variables {
	public List<Id> list = new ArrayList<Id>();
	
	public void AddVariable(String name) {
		for(Id var : list) {
			if(var.id.equals(name)) {
				Print.error("Variables ERROR: Variable Already Declared");
				return;
			}
		}
		list.add(new Id(name,0,false));
	}
	
	public boolean AssignVariable(String name, int value) {
		for(Id var : list) {
			if(var.id.equals(name)) {
				var.value = value;
				var.initialized = true;
				return true;
			}
		}
		return false;
	}
	
	public boolean Initialized(String name) {
		for(Id var : list) {
			if(var.id.equals(name) && var.initialized) {
				return true;
			}
		}
		return false;
	}
	
	public int Valueof(String name) {
		for(Id var : list) {
			if(var.id.equals(name)) {
				return var.value;
			}
		}
		return 0;
	}
}
