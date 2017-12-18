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
public final class CoinChange1 {

    /**
     * Private constructor so this utility class cannot be instantiated.
     */
    private CoinChange1() {
    }

    /**
     * This method will return then number of coins required to give change for
     * the amount given by the user.
     *
     * @param c
     *            The amount given by the user
     *
     * @param out
     *            Simple Writer
     *
     */
    private static void findCoins(int c, SimpleWriter out) {
        final int dollarAmt = 100, halfDollarAmt = 50, quarterAmt = 25;
        final int dimeAmt = 10, nickelAmt = 5, pennyAmt = 1;

        int remaining = c;
        int dollar = remaining / dollarAmt;
        remaining = remaining % dollarAmt;
        int halfDollar = remaining / halfDollarAmt;
        remaining = remaining % halfDollarAmt;
        int quarter = remaining / quarterAmt;
        remaining = remaining % quarterAmt;
        int dime = remaining / dimeAmt;
        remaining = remaining % dimeAmt;
        int nickel = remaining / nickelAmt;
        remaining = remaining % nickelAmt;
        int penny = remaining / pennyAmt;

        out.println("Dollars: " + dollar + ", Half-Dollars: " + halfDollar
                + ", Quarters: " + quarter + ", Dimes: " + dime + ", Nickels: "
                + nickel + ", Pennies: " + penny);
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
        out.println("Please enter the amount ( in cents )");
        int coin = in.nextInteger();
        findCoins(coin, out);
        in.close();
        out.close();
    }

}
