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
public final class Hailstone1 {

    /**
     * Private constructor so this utility class cannot be instantiated.
     */
    private Hailstone1() {
    }

    /**
     * The generateSeries method produces the Hailstone Series for a given
     * number n.
     *
     * @param n
     *            The user given integer
     * @param out
     *            The output stream
     */
    private static void generateSeries(int n, SimpleWriter out) {
        out.print(n + ", ");
        while (n != 1) {
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
        generateSeries(n, out);
        in.close();
        out.close();
    }

}
