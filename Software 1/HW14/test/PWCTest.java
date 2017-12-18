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
     * Test with input 1234. should return 1 comma "1,234"
     */
    @Test
    public void printWithCommasTest1Comma4Numbers() {
        NaturalNumber n = new NaturalNumber2(1234);
        String x = PWC.printWithCommas(n);

        assertTrue(x == "1,234");
        assertTrue(n.compareTo(new NaturalNumber2(1234)) == 0);
    }

    /**
     * Test with input 0. should return 0 commas "0"
     */
    @Test
    public void printWithCommasTestZero() {
        NaturalNumber n = new NaturalNumber2(0);
        String x = PWC.printWithCommas(n);

        assertTrue(x == "0");
        assertTrue(n.compareTo(new NaturalNumber2(0)) == 0);
    }

    /**
     * Test with input 1. should return 0 commas "1"
     */
    @Test
    public void printWithCommasTest1() {
        NaturalNumber n = new NaturalNumber2(1);
        String x = PWC.printWithCommas(n);

        assertTrue(x == "1");
        assertTrue(n.compareTo(new NaturalNumber2(1)) == 0);
    }

    /**
     * Test with input 123456. should return 1 comma "123,456"
     */
    @Test
    public void printWithCommasTest1Comma6Numbers() {
        NaturalNumber n = new NaturalNumber2(123456);
        String x = PWC.printWithCommas(n);

        assertTrue(x == "123,456");
        assertTrue(n.compareTo(new NaturalNumber2(123456)) == 0);
    }

    /**
     * Test with input 1234567. should return 2 commas "1,234,567"
     */
    @Test
    public void printWithCommasTest2Commas7Numbers() {
        NaturalNumber n = new NaturalNumber2(1234567);
        String x = PWC.printWithCommas(n);

        assertTrue(x == "1,234,567");
        assertTrue(n.compareTo(new NaturalNumber2(1234567)) == 0);
    }
}