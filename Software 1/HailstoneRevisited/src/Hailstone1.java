import components.naturalnumber.NaturalNumber;
import components.naturalnumber.NaturalNumber2;
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
public final class Hailstone1 {

    /**
     * Private constructor so this utility class cannot be instantiated.
     */
    private Hailstone1() {
    }

    /**
     *  * Generates and outputs the Hailstone series starting with the given  *
     * {@code NaturalNumber}.  *  * @param n  *            the starting natural
     * number  * @param out  *            the output stream  * @updates
     * out.content  * @requires n > 0 and out.is_open  * @ensures out.content =
     * #out.content * [the Hailstone series starting with n]  
     */
    private static void generateSeries(NaturalNumber n, SimpleWriter out) {
        int count = 1;
        final int three = 3;
        NaturalNumber max = new NaturalNumber2(1);
        NaturalNumber remainder = new NaturalNumber2(0);
        NaturalNumber h = new NaturalNumber2(0);
        h.copyFrom(n);
        if (h.equals(new NaturalNumber2(1))) {
            out.print("1");
        } else {
            out.print(h + ", ");
        }
        while (!h.equals(new NaturalNumber2(1))) {
            if (h.compareTo(max) > 0) {
                max.copyFrom(h);
            }
            remainder.copyFrom(h);
            remainder = remainder.divide(new NaturalNumber2(2));
            if (!remainder.equals(new NaturalNumber2(0))) {
                h.multiply(new NaturalNumber2(three));
                h.increment();
            } else {
                h.divide(new NaturalNumber2(2));
            }
            if (!h.equals(new NaturalNumber2(1))) {
                out.print(h + ", ");
            } else {
                out.print(h);
            }
            count++;
        }
        out.println("\nSeries is " + count + " number(s) long."
                + "\nMaximum value of the series: " + max.toString());
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
        NaturalNumber inputNatural = new NaturalNumber2();
        out.println("Please enter a positive integer");
        String input = in.nextLine();
        if (inputNatural.canSetFromString(input)) {
            inputNatural.setFromString(input);
        }
        while (!inputNatural.canSetFromString(input)
                || inputNatural.equals(new NaturalNumber2(0))) {
            out.println("Please enter a positive integer");
            input = in.nextLine();
            inputNatural.setFromString(input);
        }
        generateSeries(inputNatural, out);
        in.close();
        out.close();
    }
}
