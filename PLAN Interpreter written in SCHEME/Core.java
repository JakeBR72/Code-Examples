import java.io.*;

import Types.Print;


public class Core {
	public static PrintWriter writer;

	@SuppressWarnings("unused")
	public static void main(String[] args) throws IOException {
		//Setup output file
		File outputFile = new File(args[1]);
		writer = new PrintWriter(outputFile);
		writer.print("");
		
		//Tokenize
		Tokenizer tokenizer = new Tokenizer(args[0]);
		
		//Print Parse Tree?
		Print.printTree = false;
		Print.writer = writer;
		
		//Parse 
		Parser parser = new Parser(tokenizer.tokens);		
		
		//Interpret
		Interpreter interpreter = new Interpreter(parser.types);
		
		writer.close();
	}
}
