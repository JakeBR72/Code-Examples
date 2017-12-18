import components.simplereader.SimpleReader;
import components.simplereader.SimpleReader1L;
import components.simplewriter.SimpleWriter;
import components.simplewriter.SimpleWriter1L;

/**
 * This program will find the square root of a given double.
 *
 * @author Jacob Ruth
 *
 */
public final class Newton3 {
    /**
     * Private constructor so this utility class cannot be instantiated.
     */
    private Newton3() {
    }

    /**
     * Computes estimate of square root of x to within relative error 0.01%.
     * (works when x = 0)
     *
     * @param x
     *            positive number to compute square root of
     * @param e
     *            the error of accuracy entered by the user
     * @return estimate of square root
     */
    private static double sqrt(double x, double e) {
        double number = x;
        double estimate = x;
        double error = e;
        while (Math.abs(number - (estimate * estimate)) > error) {
            estimate = (estimate + number / estimate) / 2;
        }
        return estimate;
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
        out.println("Please enter the percent of error:");
        double error = in.nextDouble();
        out.println("Please enter a positive double:");
        double square = in.nextDouble();
        out.println("square root = " + sqrt(square, error));
        in.close();
        out.close();
    }
}
