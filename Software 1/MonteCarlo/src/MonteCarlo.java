import components.random.Random;
import components.random.Random1L;
import components.simplereader.SimpleReader;
import components.simplereader.SimpleReader1L;
import components.simplewriter.SimpleWriter;
import components.simplewriter.SimpleWriter1L;

/**
 * Monte Carlo Estimation.
 *
 * @author Jacob Ruth
 */
public final class MonteCarlo {

    /**
     * Private constructor so this utility class cannot be instantiated.
     */
    private MonteCarlo() {
    }

    /**
     * Main method.
     *
     * @param args
     *            the command line arguments; unused here
     */
    public static void main(String[] args) {
        SimpleReader input = new SimpleReader1L();
        SimpleWriter output = new SimpleWriter1L();
        output.print("Number of points: ");
        int n = input.nextInteger();
        int ptsInInterval = 0, ptsInSubinterval = 0;
        Random rnd = new Random1L();
        while (ptsInInterval < n) {
            double x = rnd.nextDouble() * 2;
            double y = rnd.nextDouble() * 2;
            double dist = Math.sqrt(Math.pow(1 - x, 2) + Math.pow(1 - y, 2));
            ptsInInterval++;
            if (dist <= 1) {
                ptsInSubinterval++;
            }
        }
        //output.println("IN:" + ptsInSubinterval + " OUT:"
        //      + (ptsInInterval - ptsInSubinterval));
        double estimate = (4.0 * ptsInSubinterval / ptsInInterval);
        output.println("Estimate of area: " + estimate);
        output.println("Actual area: " + Math.PI);
        input.close();
        output.close();
    }

}