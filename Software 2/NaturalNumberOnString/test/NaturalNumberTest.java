import static org.junit.Assert.assertEquals;

import org.junit.Test;

import components.naturalnumber.NaturalNumber;
import components.naturalnumber.NaturalNumber2;

/**
 * JUnit test fixture for {@code NaturalNumber}'s constructors and kernel
 * methods.
 *
 * @author Gautham Sivakumar, Jacob Ruth, Taha Topiwala
 *
 */
public abstract class NaturalNumberTest {

    /**
     * Invokes the appropriate {@code NaturalNumber} constructor for the
     * implementation under test and returns the result.
     *
     * @return the new number
     * @ensures constructorTest = 0
     */
    protected abstract NaturalNumber constructorTest();

    /**
     * Invokes the appropriate {@code NaturalNumber} constructor for the
     * implementation under test and returns the result.
     *
     * @param i
     *            {@code int} to initialize from
     * @return the new number
     * @requires i >= 0
     * @ensures constructorTest = i
     */
    protected abstract NaturalNumber constructorTest(int i);

    /**
     * Invokes the appropriate {@code NaturalNumber} constructor for the
     * implementation under test and returns the result.
     *
     * @param s
     *            {@code String} to initialize from
     * @return the new number
     * @requires there exists n: NATURAL (s = TO_STRING(n))
     * @ensures s = TO_STRING(constructorTest)
     */
    protected abstract NaturalNumber constructorTest(String s);

    /**
     * Invokes the appropriate {@code NaturalNumber} constructor for the
     * implementation under test and returns the result.
     *
     * @param n
     *            {@code NaturalNumber} to initialize from
     * @return the new number
     * @ensures constructorTest = n
     */
    protected abstract NaturalNumber constructorTest(NaturalNumber n);

    /**
     * Invokes the appropriate {@code NaturalNumber} constructor for the
     * reference implementation and returns the result.
     *
     * @return the new number
     * @ensures constructorRef = 0
     */
    protected abstract NaturalNumber constructorRef();

    /**
     * Invokes the appropriate {@code NaturalNumber} constructor for the
     * reference implementation and returns the result.
     *
     * @param i
     *            {@code int} to initialize from
     * @return the new number
     * @requires i >= 0
     * @ensures constructorRef = i
     */
    protected abstract NaturalNumber constructorRef(int i);

    /**
     * Invokes the appropriate {@code NaturalNumber} constructor for the
     * reference implementation and returns the result.
     *
     * @param s
     *            {@code String} to initialize from
     * @return the new number
     * @requires there exists n: NATURAL (s = TO_STRING(n))
     * @ensures s = TO_STRING(constructorRef)
     */
    protected abstract NaturalNumber constructorRef(String s);

    /**
     * Invokes the appropriate {@code NaturalNumber} constructor for the
     * reference implementation and returns the result.
     *
     * @param n
     *            {@code NaturalNumber} to initialize from
     * @return the new number
     * @ensures constructorRef = n
     */
    protected abstract NaturalNumber constructorRef(NaturalNumber n);

    // CONSTRUCTOR TEST CASES
    /**
     * Test Case for empty Constructor.
     */
    @Test
    public final void testNoArgumentConstructor() {
        NaturalNumber n = this.constructorTest();
        NaturalNumber nExpected = this.constructorRef();

        assertEquals(nExpected, n);
    }

    /**
     * Test Case for integer Constructor.
     */
    @Test
    public final void testConstructorInteger() {
        NaturalNumber n = this.constructorTest(12);
        NaturalNumber nExpected = this.constructorRef(12);

        assertEquals(nExpected, n);
    }

    /**
     * Test Case for String Constructor.
     */
    @Test
    public final void testConstructorString() {
        NaturalNumber n = this.constructorTest("11");
        NaturalNumber nExpected = this.constructorRef("11");

        assertEquals(nExpected, n);
    }

    /**
     * Test Case for NaturalNumber Constructor.
     */
    @Test
    public final void testConstructorNN() {
        NaturalNumber n1 = new NaturalNumber2(12);
        NaturalNumber n = this.constructorTest(n1);
        NaturalNumber nExpected = this.constructorRef(n1);

        assertEquals(nExpected, n);
    }

    //multiplyBy10() TEST CASES
    /**
     * Test multiply by ten using zero.
     */
    @Test
    public final void multiplyByTenZeroTest() {
        NaturalNumber test = this.constructorTest();
        test.multiplyBy10(6);
        NaturalNumber testExpected = this.constructorRef(6);
        assertEquals(test, testExpected);
    }

    /**
     * Test multiply by ten using non zero.
     */
    @Test
    public final void multiplyByTenNonZeroTest() {
        NaturalNumber test = this.constructorTest(6);
        test.multiplyBy10(2);
        NaturalNumber testExpected = this.constructorRef(62);
        assertEquals(test, testExpected);
    }

    /**
     * Test multiply by ten with a big number.
     */
    @Test
    public final void multiplyByTenBigDigitTest() {
        NaturalNumber test = this.constructorTest(1234);
        test.multiplyBy10(5);
        NaturalNumber testExpected = this.constructorRef(12345);
        assertEquals(test, testExpected);
    }

    //divideBy10() TEST CASES

    /**
     * Test divide by ten using zero.
     */
    @Test
    public final void divideByTenZeroTest() {
        NaturalNumber test = this.constructorTest();
        int div = test.divideBy10();
        NaturalNumber testExpected = this.constructorRef();
        int divExpected = 0;
        assertEquals(test, testExpected);
        assertEquals(divExpected, div);
    }

    /**
     * Test divide by ten using non zero.
     */
    @Test
    public final void divideByTenNonZeroTest() {
        NaturalNumber test = this.constructorTest(8);
        int div = test.divideBy10();
        NaturalNumber testExpected = this.constructorRef(0);
        int divExpected = 8;
        assertEquals(testExpected, test);
        assertEquals(divExpected, div);
    }

    /**
     * Test divide by ten using a big number.
     */
    @Test
    public final void divideByTenBigDigitTest() {
        NaturalNumber test = this.constructorTest(1234);
        int div = test.divideBy10();
        NaturalNumber testExpected = this.constructorRef(123);
        int divExpected = 4;
        assertEquals(test, testExpected);
        assertEquals(div, divExpected);
    }

    //isZero() TEST CASES
    /**
     * Test Case for isZero when NN is "".
     */
    @Test
    public final void testIsEmptyZero() {
        NaturalNumber n = this.constructorTest();
        boolean isZero = n.isZero();
        boolean isZeroExpected = true;
        assertEquals(isZeroExpected, isZero);
    }

    /**
     * Test Case for isZero when NN is "1".
     */
    @Test
    public final void testIsNumber1Zero() {
        NaturalNumber n = this.constructorTest(1);
        boolean isZero = n.isZero();
        boolean isZeroExpected = false;
        assertEquals(isZeroExpected, isZero);
    }

    /**
     * Test Case for isZero when NN is "5".
     */
    @Test
    public final void testIsNumber5Zero() {
        NaturalNumber n = this.constructorTest(5);
        boolean isZero = n.isZero();
        boolean isZeroExpected = false;
        assertEquals(isZeroExpected, isZero);
    }

    /**
     * Test Case for isZero when NN is "100".
     */
    @Test
    public final void testIs100Zero() {
        NaturalNumber n = this.constructorTest(100);
        boolean isZero = n.isZero();
        boolean isZeroExpected = false;
        assertEquals(isZeroExpected, isZero);
    }

}
