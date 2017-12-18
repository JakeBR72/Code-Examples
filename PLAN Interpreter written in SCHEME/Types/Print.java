package Types;

import java.io.PrintWriter;
import java.io.Writer;
import java.util.List;

public class Print {
	public static boolean printTree = false;
	public static PrintWriter writer;
	
	public static void tree(String className, List tokens, int depth) {
		for(int i = 0; i < depth; i++) {
			writer.print("|");
			System.out.print("|");
		}
		writer.println("["+className.substring(6)+"]=" + tokens);
		System.out.println("["+className.substring(6)+"]=" + tokens);
	}
	
	public static void line(String string) {
		writer.println(string);
		System.out.println(string);
	}
	public static void error(String string) {
		writer.println(string);
		System.out.println(string);
		//System.out.println(string);
		writer.flush();
		writer.close();
		System.exit(0);
	}
}
