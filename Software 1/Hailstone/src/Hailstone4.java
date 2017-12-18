import components.simplereader.SimpleReader;
import components.simplereader.SimpleReader1L;
import components.simplewriter.SimpleWriter;
import components.simplewriter.SimpleWriter1L;

/**
 * Hailstone Series.
 *
 * @author Jacob Ruth
 *
 */
public final class Hailstone4 {

    /**
     * Private constructor so this utility class cannot be instantiated.
     */
    private Hailstone4() {
    }

    /**
     * The generateSeries method produces the Hailstone Series for a given
     * number n.
     *
     * @param n
     *            The integer given by the user
     * @param out
     *            The output stream
     * @param in
     *            the input stream
     */
    private static void generateSeries(int n, SimpleWriter out, SimpleReader in) {
        out.print(n + ", ");
        int count = 1;
        int max = 0;
        while (n != 1) {
            if (n > max) {
                max = n;
            }
            if (n % 2 > 0) {
                n = 3 * n + 1;
            } else {
                n = n / 2;
            }
            if (n != 1) {
                out.print(n + ", ");
            } else {
                out.print(n);
            }
            count++;
        }
        out.println("\nSeries is " + count + " numbers long.");
        out.println("Maximum value of the series: " + max);
        out.println("Would you like to compute another series? (y/n) ");
        String msg = in.nextLine();
        if (msg.equals("y")) {
            out.println("Please enter a starting integer: ");
            n = in.nextInteger();
            generateSeries(n, out, in);
        }
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
        out.println("Please enter a starting integer: ");
        int n = in.nextInteger();
        generateSeries(n, out, in);
        in.close();
        out.close();
    }

}
