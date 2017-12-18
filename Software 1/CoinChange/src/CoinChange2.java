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
public final class CoinChange2 {

    /**
     * Private constructor so this utility class cannot be instantiated.
     */
    private CoinChange2() {
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
        int remaining = c;
        final int[] coinsAmt = { 100, 50, 25, 10, 5, 1 };
        String[] coinsName = { "Dollars: ", " Half-Dollars: ", " Quarters: ",
                " Dimes: ", " Nickels: ", " Pennies: " };
        int[] coins = { 0, 0, 0, 0, 0, 0 };
        int count = 0;
        while (remaining > 0) {
            coins[count] = remaining / coinsAmt[count];
            remaining = remaining % coinsAmt[count];
            out.print(coinsName[count] + coins[count]);
            count++;
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
        out.println("Please enter the amount ( in cents )");
        int coin = in.nextInteger();

        findCoins(coin, out);
        in.close();
        out.close();
    }

}
