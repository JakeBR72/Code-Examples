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
public final class Hailstone3 {

    /**
     * Private constructor so this utility class cannot be instantiated.
     */
    private Hailstone3() {
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
