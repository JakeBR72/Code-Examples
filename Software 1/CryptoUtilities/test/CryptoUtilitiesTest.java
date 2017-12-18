import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertTrue;

import org.junit.Test;

import components.naturalnumber.NaturalNumber;
import components.naturalnumber.NaturalNumber2;

/**
 * @author Jacob Ruth
 *
 */
public class CryptoUtilitiesTest {

    /*
     * Tests of isPrime2
     */
    @Test
    public void isPrime2_102359() {
        NaturalNumber n = new NaturalNumber2(102359);
        boolean test = CryptoUtilities.isPrime2(n);
        assertTrue(test);
        assertEquals("102359", n.toString());
    }

    @Test
    public void isPrime2_2() {
        NaturalNumber n = new NaturalNumber2(2);
        boolean test = CryptoUtilities.isPrime2(n);
        assertTrue(test);
        assertEquals("2", n.toString());
    }

    @Test
    public void isPrime2_72() {
        NaturalNumber n = new NaturalNumber2(72);
        boolean test = CryptoUtilities.isPrime2(n);
        assertTrue(!test);
        assertEquals("72", n.toString());
    }

    /*
     * Tests of generateNextLikelyPrime
     */
    @Test
    public void generateNextLikelyPrime_4() {
        NaturalNumber n = new NaturalNumber2(4);
        CryptoUtilities.generateNextLikelyPrime(n);
        assertEquals("5", n.toString());
    }

    @Test
    public void generateNextLikelyPrime_102345() {
        NaturalNumber n = new NaturalNumber2(102345);
        CryptoUtilities.generateNextLikelyPrime(n);
        assertEquals("102359", n.toString());
    }

    /*
     * Tests of isWitnessToCompositeness
     */
    @Test
    public void isWitnessToCompositeness_3_5() {
        NaturalNumber w = new NaturalNumber2(3);
        NaturalNumber n = new NaturalNumber2(5);
        boolean test = CryptoUtilities.isWitnessToCompositeness(w, n);
        assertTrue(!test);
        assertEquals("5", n.toString());
    }

    @Test
    public void isWitnessToCompositeness_4_10() {
        NaturalNumber w = new NaturalNumber2(4);
        NaturalNumber n = new NaturalNumber2(10);
        boolean test = CryptoUtilities.isWitnessToCompositeness(w, n);
        assertTrue(test);
        assertEquals("10", n.toString());
    }

    @Test
    public void isWitnessToCompositeness_0_0() {
        NaturalNumber w = new NaturalNumber2(2);
        NaturalNumber n = new NaturalNumber2(4);
        boolean test = CryptoUtilities.isWitnessToCompositeness(w, n);
        assertTrue(test);
        assertEquals("4", n.toString());
    }

    /*
     * Tests of reduceToGCD
     */

    @Test
    public void testReduceToGCD_0_0() {
        NaturalNumber n = new NaturalNumber2(0);
        NaturalNumber m = new NaturalNumber2(0);
        CryptoUtilities.reduceToGCD(n, m);
        assertEquals("0", n.toString());
        assertEquals("0", m.toString());
    }

    @Test
    public void testReduceToGCD_30_21() {
        NaturalNumber n = new NaturalNumber2(30);
        NaturalNumber m = new NaturalNumber2(21);
        CryptoUtilities.reduceToGCD(n, m);
        assertEquals("3", n.toString());
        assertEquals("0", m.toString());
    }

    @Test
    public void testReduceToGCD_72_42() {
        NaturalNumber n = new NaturalNumber2(72);
        NaturalNumber m = new NaturalNumber2(42);
        CryptoUtilities.reduceToGCD(n, m);
        assertEquals("6", n.toString());
        assertEquals("0", m.toString());
    }

    /*
     * Tests of isEven
     */

    @Test
    public void testIsEven_0() {
        NaturalNumber n = new NaturalNumber2(0);
        boolean result = CryptoUtilities.isEven(n);
        assertEquals("0", n.toString());
        assertTrue(result);
    }

    @Test
    public void testIsEven_1() {
        NaturalNumber n = new NaturalNumber2(1);
        boolean result = CryptoUtilities.isEven(n);
        assertEquals("1", n.toString());
        assertTrue(!result);
    }

    @Test
    public void testIsEven_2() {
        NaturalNumber n = new NaturalNumber2(2);
        boolean result = CryptoUtilities.isEven(n);
        assertEquals("2", n.toString());
        assertTrue(result);
    }

    @Test
    public void testIsEven_17() {
        NaturalNumber n = new NaturalNumber2(17);
        boolean result = CryptoUtilities.isEven(n);
        assertEquals("17", n.toString());
        assertTrue(!result);
    }

    @Test
    public void testIsEven_18() {
        NaturalNumber n = new NaturalNumber2(18);
        boolean result = CryptoUtilities.isEven(n);
        assertEquals("18", n.toString());
        assertTrue(result);
    }

    /*
     * Tests of powerMod X
     */
    @Test
    public void testPowerMod_3_4_5() {
        NaturalNumber n = new NaturalNumber2(3);
        NaturalNumber p = new NaturalNumber2(4);
        NaturalNumber m = new NaturalNumber2(5);
        CryptoUtilities.powerMod(n, p, m);
        assertEquals("1", n.toString());
        assertEquals("4", p.toString());
        assertEquals("5", m.toString());
    }

    @Test
    public void testPowerMod_32_12_50() {
        NaturalNumber n = new NaturalNumber2(32);
        NaturalNumber p = new NaturalNumber2(12);
        NaturalNumber m = new NaturalNumber2(50);
        CryptoUtilities.powerMod(n, p, m);
        assertEquals("26", n.toString());
        assertEquals("12", p.toString());
        assertEquals("50", m.toString());
    }

    @Test
    public void testPowerMod_12_20_7() {
        NaturalNumber n = new NaturalNumber2(12);
        NaturalNumber p = new NaturalNumber2(20);
        NaturalNumber m = new NaturalNumber2(7);
        CryptoUtilities.powerMod(n, p, m);
        assertEquals("4", n.toString());
        assertEquals("20", p.toString());
        assertEquals("7", m.toString());
    }

    @Test
    public void testPowerMod_32_12_2() {
        NaturalNumber n = new NaturalNumber2(32);
        NaturalNumber p = new NaturalNumber2(12);
        NaturalNumber m = new NaturalNumber2(2);
        CryptoUtilities.powerMod(n, p, m);
        assertEquals("0", n.toString());
        assertEquals("12", p.toString());
        assertEquals("2", m.toString());
    }

    @Test
    public void testPowerMod_4_2_6() {
        NaturalNumber n = new NaturalNumber2(4);
        NaturalNumber p = new NaturalNumber2(2);
        NaturalNumber m = new NaturalNumber2(6);
        CryptoUtilities.powerMod(n, p, m);
        assertEquals("4", n.toString());
        assertEquals("2", p.toString());
        assertEquals("6", m.toString());
    }

    @Test
    public void testPowerMod_0_0_2() {
        NaturalNumber n = new NaturalNumber2(0);
        NaturalNumber p = new NaturalNumber2(0);
        NaturalNumber m = new NaturalNumber2(2);
        CryptoUtilities.powerMod(n, p, m);
        assertEquals("1", n.toString());
        assertEquals("0", p.toString());
        assertEquals("2", m.toString());
    }

    @Test
    public void testPowerMod_17_18_19() {
        NaturalNumber n = new NaturalNumber2(17);
        NaturalNumber p = new NaturalNumber2(18);
        NaturalNumber m = new NaturalNumber2(19);
        CryptoUtilities.powerMod(n, p, m);
        assertEquals("1", n.toString());
        assertEquals("18", p.toString());
        assertEquals("19", m.toString());
    }

}