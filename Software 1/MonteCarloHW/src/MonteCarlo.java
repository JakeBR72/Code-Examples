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
        final double four = 4;
        output.print("Number of points: ");
        int n = input.nextInteger();
        double estimate = (four * numberOfPointsInCircle(n) / n);
        output.println("Estimate of area: " + estimate);
        output.println("Actual area: " + Math.PI);
        input.close();
        output.close();
    }

    /**
     * Checks whether the given point (xCoord, yCoord) is inside the circle of
     * radius 1.0 centered at the point (1.0, 1.0).  
     *
     * @param xCoord
     *             the x coordinate of the point  
     * @param yCoord
     *             the y coordinate of the point  
     * @return true if the point is inside the circle, false otherwise  
     */
    private static boolean pointIsInCircle(double xCoord, double yCoord) {
        double x = xCoord;
        double y = yCoord;
        double dist = Math.sqrt(Math.pow(1 - x, 2) + Math.pow(1 - y, 2));
        if (dist <= 1) {
            return true;
        }
        return false;
    }

    /**
     * Generates n pseudo-random points in the [0.0,2.0) x [0.0,2.0) square and
     * returns the number that fall in the circle of radius 1.0 centered at the
     * point (1.0, 1.0).  
     *
     * @param n
     *              the number of points to generate
     * @return the number of points that fall in the circle  
     */
    private static int numberOfPointsInCircle(int n) {
        int ptsInInterval = 0, ptsInSubinterval = 0;
        Random rnd = new Random1L();
        while (ptsInInterval < n) {
            double x = rnd.nextDouble() * 2;
            double y = rnd.nextDouble() * 2;
            ptsInInterval++;
            if (pointIsInCircle(x, y)) {
                ptsInSubinterval++;
            }
        }
        return ptsInSubinterval;
    }
}