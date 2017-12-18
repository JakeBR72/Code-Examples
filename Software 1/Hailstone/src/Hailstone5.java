import components.simplereader.SimpleReader;
import components.simplereader.SimpleReader1L;
import components.simplewriter.SimpleWriter;
import components.simplewriter.SimpleWriter1L;
import components.utilities.FormatChecker;

/**
 * Hailstone Series.
 *
 * @author Jacob Ruth
 *
 */
public final class Hailstone5 {

    /**
     * Private constructor so this utility class cannot be instantiated.
     */
    private Hailstone5() {
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
        int count = 1;
        final int three = 3;
        int max = 1;
        int h = n;
        if (h == 1) {
            out.print("1");
        } else {
            out.print(h + ", ");
        }
        while (h != 1) {
            if (h > max) {
                max = h;
            }
            if (h % 2 > 0) {
                h = three * n + 1;
            } else {
                h = n / 2;
            }
            if (h != 1) {
                out.print(h + ", ");
            } else {
                out.print(h);
            }
            count++;
        }
        out.println("\nSeries is " + count + " number(s) long."
                + "\nMaximum value of the series: " + max
                + "\nWould you like to compute another series? (y/n)");
        String nextLine = in.nextLine();
        if (nextLine.equals("y")) {
            generateSeries(getPositiveInteger(in, out), out, in);
        }
    }

    /**
     * Repeatedly asks the user for a positive integer until the user enters
     * one. Returns the positive integer.
     *
     * @param in
     *            the input stream
     * @param out
     *            the output stream
     * @return a positive integer entered by the user
     */
    private static int getPositiveInteger(SimpleReader in, SimpleWriter out) {
        int n = 0;
        while (n <= 0) {
            out.println("Please enter a positive integer: ");
            String nextLine = in.nextLine();
            if (FormatChecker.canParseInt(nextLine)
                    && Integer.parseInt(nextLine) > 0) {
                n = Integer.parseInt(nextLine);
            }
        }
        return n;
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
        generateSeries(getPositiveInteger(in, out), out, in);
        in.close();
        out.close();
    }

}
