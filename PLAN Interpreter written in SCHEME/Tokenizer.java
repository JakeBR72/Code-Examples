import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.Reader;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class Tokenizer {

	public static List uniqueChars = Arrays
			.asList(new String[] { "!", ",", "(", ")", ";", "*", "-", "+", "<", "<=", ":=", "=" });
	public static List uniqueWords = Arrays.asList(new String[] { "program", "begin", "end", "int", "if", "then",
			"else", "endif", "while", "endwhile", "or", "input", "output", "call" ,"fun", "return" });
	public static ArrayList<String> tokens = new ArrayList<String>();
	public static File file;

	public Tokenizer(String newFile) throws IOException {
		file = new File(newFile);
		GenerateTokens();
	}

	public static void GenerateTokens() throws IOException {
		InputStream inputStream = new FileInputStream(file);
		Reader in = new InputStreamReader(inputStream, "UTF-8");
		BufferedReader read = new BufferedReader(in);
		String newLine = read.readLine();

		String token = "";
		int index = 0;

		while (newLine != null) {
			while (index < newLine.length()) {
				if (token.length() > 0 && Character.isWhitespace(newLine.charAt(index))) {
					tokens.add(CreateToken(token));
					token = "";
				} else if (Character.isDigit(newLine.charAt(index)) || Character.isLetter(newLine.charAt(index))) {
					token += newLine.charAt(index);
				} else if (newLine.charAt(index) == ':' || uniqueChars.contains("" + newLine.charAt(index))) {
					if (token.length() > 0) {
						tokens.add(CreateToken(token));
					}
					if (index + 1 < newLine.length()
							&& uniqueChars.contains("" + newLine.charAt(index) + newLine.charAt(index + 1))) {
						tokens.add(ChangeCharacterToken("" + newLine.charAt(index) + newLine.charAt(index + 1)));
						index++;
					} else {
						tokens.add(CreateToken("" + newLine.charAt(index)));
					}
					token = "";
				}
				index++;
			}
			newLine = read.readLine();
			index = 0;
		}
		if(token.length() > 0) {
			tokens.add(CreateToken(token));
		}
	}

	public static String CreateToken(String input) {
		if (uniqueChars.contains(input)) {
			input = ChangeCharacterToken(input);
		} else if (uniqueWords.contains(input)) {
			input = ChangeWordToken(input);
		} else {
			for (int i = 0; i < input.length(); i++) {
				if (Character.isAlphabetic(input.charAt(i))) {
					input = CreateID(input);
					break;
				}
			}
		}
		return input;
	}

	public static String ChangeCharacterToken(String input) {
		if (tokens.get(tokens.size() - 1).equals("SEMICOLON") && input.equals(";")) {
			Types.Print.error("Tokenizer ERROR: Empty line");
		}
		switch (input) {
		case "!":
			input = "EXCLAMATION";
			break;
		case ",":
			input = "COMMA";
			break;
		case ";":
			input = "SEMICOLON";
			break;
		case "*":
			input = "ASTERISK";
			break;
		case "+":
			input = "PLUS";
			break;
		case "-":
			input = "MINUS";
			break;
		case "(":
			input = "LEFTPAREN";
			break;
		case ")":
			input = "RIGHTPAREN";
			break;
		case "<":
			input = "LESSTHAN";
			break;
		case "<=":
			input = "LESSTHANEQUAL";
			break;
		case ":=":
			input = "ASSIGN";
			break;
		case "=":
			input = "EQUALS";
			break;
		default:
			Types.Print.error("Tokenizer ERROR: Invalid character token");
			break;

		}
		return input;
	}

	public static String ChangeWordToken(String input) {
		switch (input) {
		case "program":
			input = "PROGRAM";
			break;
		case "begin":
			input = "BEGIN";
			break;
		case "end":
			input = "END";
			break;
		case "int":
			input = "INT";
			break;
		case "if":
			input = "IF";
			break;
		case "then":
			input = "THEN";
			break;
		case "else":
			input = "ELSE";
			break;
		case "endif":
			input = "ENDIF";
			break;
		case "while":
			input = "WHILE";
			break;
		case "endwhile":
			input = "ENDWHILE";
			break;
		case "or":
			input = "OR";
			break;
		case "input":
			input = "INPUT";
			break;
		case "output":
			input = "OUTPUT";
			break;
		case "call":
			input = "CALL";
			break;
		case "fun":
			input = "FUNCTION";
			break;
		case "return":
			input = "RETURN";
			break;
		}
		return input;
	}

	public static String CreateID(String input) {
		return "ID[" + input + "]";
	}
}
