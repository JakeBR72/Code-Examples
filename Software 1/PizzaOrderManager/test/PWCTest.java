import static org.junit.Assert.assertTrue;

import org.junit.Test;

import components.naturalnumber.NaturalNumber;
import components.naturalnumber.NaturalNumber2;

/**
 * JUnit fixture for testing printWithCommas.
 *
 * @author Jacob Ruth
 *
 */
public final class PWCTest {
    /**
     *  * Calls the method under test.  *  * @param n  *            the number
     * to pass to the method under test  * @return the {@code String} returned
     * by the method under test  * @ensures
     *
     * <pre>
     *      * redirectToMethodUnderTest = [String returned by the method under test]
     *      *
     * </pre>
     *
     *  
     */
    private static String redirectToMethodUnderTest(NaturalNumber n) {
        return NNtoStringWithCommas6.toStringWithCommas(n);
    }

    /**
     * Test with input 1234. should return 1 comma "1,234"
     */
    @Test
    public void printWithCommasTest1Comma4Numbers() {
        NaturalNumber n = new NaturalNumber2(1234);
        String x = redirectToMethodUnderTest(n);
        System.out.println(n + " [] " + x);
        assertTrue(x.equals("1,234"));
        assertTrue(n.compareTo(new NaturalNumber2(1234)) == 0);
    }

    /**
     * Test with input 0. should return 0 commas "0"
     */
    @Test
    public void printWithCommasTestZero() {
        NaturalNumber n = new NaturalNumber2(0);
        String x = redirectToMethodUnderTest(n);
        System.out.println(n + " [] " + x);
        assertTrue(x.equals("0"));
        assertTrue(n.compareTo(new NaturalNumber2(0)) == 0);
    }

    /**
     * Test with input 1. should return 0 commas "1"
     */
    @Test
    public void printWithCommasTest1() {
        NaturalNumber n = new NaturalNumber2(1);
        String x = redirectToMethodUnderTest(n);
        System.out.println(n + " [] " + x);
        assertTrue(x.equals("1"));
        assertTrue(n.compareTo(new NaturalNumber2(1)) == 0);
    }

    /**
     * Test with input 123456. should return 1 comma "123,456"
     */
    @Test
    public void printWithCommasTest1Comma6Numbers() {
        NaturalNumber n = new NaturalNumber2(123456);
        String x = redirectToMethodUnderTest(n);
        System.out.println(n + " [] " + x);
        assertTrue(x.equals("123,456"));
        assertTrue(n.compareTo(new NaturalNumber2(123456)) == 0);
    }

    /**
     * Test with input 1234567. should return 2 commas "1,234,567"
     */
    @Test
    public void printWithCommasTest2Commas7Numbers() {
        NaturalNumber n = new NaturalNumber2(1234567);
        String x = redirectToMethodUnderTest(n);
        System.out.println(n + " [] " + x);
        assertTrue(x.equals("1,234,567"));
        assertTrue(n.compareTo(new NaturalNumber2(1234567)) == 0);
    }

    /**
     * Test with input 10001000. should return 2 commas "10,001,000"
     */
    @Test
    public void printWithCommasTest3Commas11Numbers() {
        NaturalNumber n = new NaturalNumber2("10001000");
        String x = redirectToMethodUnderTest(n);
        System.out.println(n + " [] " + x);
        assertTrue(x.equals("10,001,000"));
        assertTrue(n.compareTo(new NaturalNumber2("10001000")) == 0);
    }

    /**
     * Test with input 12345678910111213. should return 2 commas
     * "12,345,678,910,111,213"
     */
    @Test
    public void printWithCommasTestLargeNumber() {
        NaturalNumber n = new NaturalNumber2("12345678910111213");
        String x = redirectToMethodUnderTest(n);
        System.out.println(n + " [] " + x);
        assertTrue(x.equals("12,345,678,910,111,213"));
        assertTrue(n.compareTo(new NaturalNumber2("12345678910111213")) == 0);
    }
}
