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
public final class CoinChange3 {

    /**
     * Private constructor so this utility class cannot be instantiated.
     */
    private CoinChange3() {
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
    private static int[] coinCountsToMakeChange(int c, int[] arr) {
        int remaining = c;
        final int[] coinsAmt = arr;
        int[] coins = { 0, 0, 0, 0, 0, 0 };
        int count = 0;
        while (remaining > 0) {
            coins[count] = remaining / coinsAmt[count];
            remaining = remaining % coinsAmt[count];
            count++;
        }
        return coins;
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
        final int[] denominations = { 100, 50, 25, 10, 5, 1 };
        String[] coinsName = { "Dollars: ", " Half-Dollars: ", " Quarters: ",
                " Dimes: ", " Nickels: ", " Pennies: " };
        out.println("Please enter the amount ( in cents )");
        int coin = in.nextInteger();
        int[] coins = coinCountsToMakeChange(coin, denominations);
        for (int i = 0; i < coins.length; i++) {
            out.print(coinsName[i] + coins[i]);
        }
        in.close();
        out.close();
    }
}
