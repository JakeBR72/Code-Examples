import components.simplereader.SimpleReader;
import components.simplereader.SimpleReader1L;
import components.simplewriter.SimpleWriter;
import components.simplewriter.SimpleWriter1L;

/**
 * This program estimates a given number mu by taking in 4 numbers from the user
 * and estimating mu using 17 exponents and 83251 combinations, estimation form:
 * w^(a) x^(b) y^(c) z^(d).
 *
 * @author Jacob Ruth
 *
 */
public final class ABCDGuesser2 {

    /**
     * Private constructor so this utility class cannot be instantiated.
     */
    private ABCDGuesser2() {
    }

    /**
     * A method that will find the exponents that best approximate the number
     * given.
     *
     * @param o
     *            the simplewriter to print to
     * @param fo
     *            fourth number given
     * @param t
     *            third number given
     * @param s
     *            second number given
     * @param f
     *            first number given
     * @param m
     *            the number to estimate
     */
    private static void findExponents(int m, int f, int s, int t, int fo,
            SimpleWriter o) {
        double mu = m;
        final double first = f;
        final double second = s;
        final double third = t;
        final double fourth = fo;
        SimpleWriter out = o;
        double error = 1;
        final double[] exponents = { -5, -4, -3, -2, -1, -1.0 / 2.0,
                -1.0 / 3.0, -1.0 / 4.0, 0, 1.0 / 4.0, 1.0 / 3.0, 1.0 / 2.0, 1,
                2, 3, 4, 5 };
        final String[] exponentsString = { "-5", "-4", "-3", "-2", "-1",
                "-1/2", "-1/3", "-1/4", "0", "1/4", "1/3", "1/2", "1", "2",
                "3", "4", "5" };
        int[] numExp = { 0, 0, 0, 0 };
        double value = 0;
        final int shiftDecimal = 100;
        for (int count1 = 0; count1 < exponents.length; count1++) {
            for (int count2 = 0; count2 < exponents.length; count2++) {
                for (int count3 = 0; count3 < exponents.length; count3++) {
                    for (int count4 = 0; count4 < exponents.length; count4++) {
                        double currValue = Math.pow(first, exponents[count1])
                                * Math.pow(second, exponents[count2])
                                * Math.pow(third, exponents[count3])
                                * Math.pow(fourth, exponents[count4]);
                        double currError = Math.abs(mu - currValue) / mu;
                        if (currError < 1 && currError < error) {
                            numExp[0] = count1;
                            numExp[1] = count2;
                            numExp[2] = count3;
                            numExp[3] = count4;
                            error = currError;
                            value = currValue;
                        }
                    }
                }
            }
        }
        out.println("a[" + exponentsString[numExp[0]] + "] b["
                + exponentsString[numExp[1]] + "] c["
                + exponentsString[numExp[2]] + "] d["
                + exponentsString[numExp[3]] + "]");
        out.print("Estimated Value: ");
        out.println(value, 0, false);
        out.print("Error: ");
        out.print(error * shiftDecimal, 2, false);
        out.println("%");
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
        out.println("please enter a target value:");
        int mu = in.nextInteger();
        out.println("please enter the first value:");
        int first = in.nextInteger();
        out.println("please enter the second value:");
        int second = in.nextInteger();
        out.println("please enter the third value:");
        int third = in.nextInteger();
        out.println("please enter the fourth value:");
        int fourth = in.nextInteger();

        findExponents(mu, first, second, third, fourth, out);
        in.close();
        out.close();
    }

}
