import components.simplereader.SimpleReader;
import components.simplereader.SimpleReader1L;
import components.simplewriter.SimpleWriter;
import components.simplewriter.SimpleWriter1L;

/**
 * Simple program to exercise EmailAccount functionality.
 */
public final class EmailAccountMain {

    /**
     * Private constructor so this utility class cannot be instantiated.
     */
    private EmailAccountMain() {
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
        EmailAccount myAccount = new EmailAccount1("Brutus", "Buckeye");
        /*
         * Should print: Brutus Buckeye
         */
        out.println(myAccount.name());
        /*
         * Should print: buckeye.1@osu.edu
         */
        out.println(myAccount.emailAddress());
        /*
         * Should print: Name: Brutus Buckeye, Email: buckeye.1@osu.edu
         */
        String name = ".";
        out.println(myAccount);
        while (!name.equals(" ")) {
            out.println("Please Enter Your Name: ");
            name = in.nextLine();
            EmailAccount newAccount = new EmailAccount1(
                    name.substring(0, name.indexOf(" ")),
                    name.substring(name.indexOf(" ") + 1, name.length()));
            out.println(newAccount.name());
            out.println(newAccount.emailAddress());
            out.println(newAccount);
        }
        in.close();
        out.close();
    }

}
