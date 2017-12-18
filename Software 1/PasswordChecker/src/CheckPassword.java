import components.simplereader.SimpleReader;
import components.simplereader.SimpleReader1L;
import components.simplewriter.SimpleWriter;
import components.simplewriter.SimpleWriter1L;

/**
 * Put a short phrase describing the program here.
 *
 * @author Put your name here
 *
 */
public final class CheckPassword {

    /**
     * Private constructor so this utility class cannot be instantiated.
     */
    private CheckPassword() {
    }

    /**
     * Checks whether the given String satisfies the CSE department criteria for
     * a valid password. Prints an appropriate message to the given output
     * stream.  
     *
     * @param s
     *            the String to check  
     * @param out
     *            the output stream  
     */
    private static void checkPassword(String s, SimpleWriter out) {
        int validNum = 0;
        final int isValid = 3;
        final int stringLength = 6;
        String string = s;
        if (string.length() <= stringLength) {
            if (containsLowerCaseLetter(s)) {
                validNum++;
            }
            if (containsUpperCaseLetter(s)) {
                validNum++;
            }
            if (containsDigit(s)) {
                validNum++;
            }
            if (containsSpecial(s)) {
                validNum++;
            }
            if (validNum >= isValid) {
                out.println("Valid password!");
            } else {
                out.println("Invalid password!");
            }
        } else {
            out.println("Invalid password!");
        }
    }

    /**
     * Checks if the given String contains a special character.
     *
     * @param s
     *            the String to check
     *
     * @return true if s contains a special character, false otherwise  
     */
    private static boolean containsSpecial(String s) {
        int count = 0;
        int count2 = 0;
        char[] special = { '!', '@', '#', '\'', '%', '^', '&', '*', '(', ')',
                '-', '+', '=', '{', '}', '[', ']', ':', ';', ',', '.', '?', };
        boolean valid = false;
        String string = s;
        while (count < string.length()) {
            while (count2 < special.length) {
                if (string.charAt(count) == special[count2]) {
                    valid = true;
                }
                count2++;
            }
            count2 = 0;
            count++;
        }
        return valid;
    }

    /**
     * Checks if the given String contains an lower case letter.
     *
     * @param s
     *            the String to check
     *
     * @return true if s contains an lower case letter, false otherwise  
     */
    private static boolean containsLowerCaseLetter(String s) {
        int count = 0;
        String string = s;
        while (count < string.length() - 1
                && !Character.isLowerCase(string.charAt(count))) {
            count++;
        }
        return Character.isLowerCase(string.charAt(count));
    }

    /**
     * Checks if the given String contains a digit.
     *
     * @param s
     *            the String to check
     *
     * @return true if s contains a digit, false otherwise  
     */
    private static boolean containsDigit(String s) {
        int count = 0;
        String string = s;
        while (count < string.length() - 1
                && !Character.isDigit(string.charAt(count))) {
            count++;
        }
        return Character.isDigit(string.charAt(count));
    }

    /**
     * Checks if the given String contains an upper case letter.
     *
     * @param s
     *            the String to check
     *
     * @return true if s contains an upper case letter, false otherwise  
     */
    private static boolean containsUpperCaseLetter(String s) {
        int count = 0;
        String string = s;
        while (count < string.length() - 1
                && !Character.isUpperCase(string.charAt(count))) {
            count++;
        }
        return Character.isUpperCase(string.charAt(count));
    }

    /**
     * Main method.
     *
     * @param args
     *            the command line arguments
     */
    public static void main(String[] args) {
        SimpleReader in = new SimpleReader1L();
        SimpleWriter out = new SimpleWriter1L();
        String string = "[]";
        while (!string.equals("")) {
            out.println("Please enter a password:");
            string = in.nextLine();
            if (!string.equals("")) {
                checkPassword(string, out);
            }
        }
        out.println("Exited");
        in.close();
        out.close();
    }
}
