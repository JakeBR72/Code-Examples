import static org.junit.Assert.assertEquals;

import java.util.Comparator;

import org.junit.Test;

import components.sortingmachine.SortingMachine;

/**
 * JUnit test fixture for {@code SortingMachine<String>}'s constructor and
 * kernel methods.
 *
 * @author Gautham Sivakumar, Jacob Ruth, Taha Topiwala
 *
 */
public abstract class SortingMachineTest {

    /**
     * Invokes the appropriate {@code SortingMachine} constructor for the
     * implementation under test and returns the result.
     *
     * @param order
     *            the {@code Comparator} defining the order for {@code String}
     * @return the new {@code SortingMachine}
     * @requires IS_TOTAL_PREORDER([relation computed by order.compare method])
     * @ensures constructorTest = (true, order, {})
     */
    protected abstract SortingMachine<String> constructorTest(
            Comparator<String> order);

    /**
     * Invokes the appropriate {@code SortingMachine} constructor for the
     * reference implementation and returns the result.
     *
     * @param order
     *            the {@code Comparator} defining the order for {@code String}
     * @return the new {@code SortingMachine}
     * @requires IS_TOTAL_PREORDER([relation computed by order.compare method])
     * @ensures constructorRef = (true, order, {})
     */
    protected abstract SortingMachine<String> constructorRef(
            Comparator<String> order);

    /**
     *
     * Creates and returns a {@code SortingMachine<String>} of the
     * implementation under test type with the given entries and mode.
     *
     * @param order
     *            the {@code Comparator} defining the order for {@code String}
     * @param insertionMode
     *            flag indicating the machine mode
     * @param args
     *            the entries for the {@code SortingMachine}
     * @return the constructed {@code SortingMachine}
     * @requires IS_TOTAL_PREORDER([relation computed by order.compare method])
     * @ensures
     *
     *          <pre>
     * createFromArgsTest = (insertionMode, order, [multiset of entries in args])
     *          </pre>
     */
    private SortingMachine<String> createFromArgsTest(Comparator<String> order,
            boolean insertionMode, String... args) {
        SortingMachine<String> sm = this.constructorTest(order);
        for (int i = 0; i < args.length; i++) {
            sm.add(args[i]);
        }
        if (!insertionMode) {
            sm.changeToExtractionMode();
        }
        return sm;
    }

    /**
     *
     * Creates and returns a {@code SortingMachine<String>} of the reference
     * implementation type with the given entries and mode.
     *
     * @param order
     *            the {@code Comparator} defining the order for {@code String}
     * @param insertionMode
     *            flag indicating the machine mode
     * @param args
     *            the entries for the {@code SortingMachine}
     * @return the constructed {@code SortingMachine}
     * @requires IS_TOTAL_PREORDER([relation computed by order.compare method])
     * @ensures
     *
     *          <pre>
     * createFromArgsRef = (insertionMode, order, [multiset of entries in args])
     *          </pre>
     */
    private SortingMachine<String> createFromArgsRef(Comparator<String> order,
            boolean insertionMode, String... args) {
        SortingMachine<String> sm = this.constructorRef(order);
        for (int i = 0; i < args.length; i++) {
            sm.add(args[i]);
        }
        if (!insertionMode) {
            sm.changeToExtractionMode();
        }
        return sm;
    }

    /**
     * Comparator<String> implementation to be used in all test cases. Compare
     * {@code String}s in lexicographic order.
     */
    private static class StringLT implements Comparator<String> {

        @Override
        public int compare(String s1, String s2) {
            return s1.compareToIgnoreCase(s2);
        }

    }

    /**
     * Comparator instance to be used in all test cases.
     */
    private static final StringLT ORDER = new StringLT();

    /*
     * Sample test cases.
     */

    @Test
    public final void testConstructor() {
        SortingMachine<String> m = this.constructorTest(ORDER);
        SortingMachine<String> mExpected = this.constructorRef(ORDER);
        assertEquals(mExpected, m);
    }

    @Test
    public final void testAddEmpty() {
        SortingMachine<String> m = this.createFromArgsTest(ORDER, true);
        SortingMachine<String> mExpected = this.createFromArgsRef(ORDER, true,
                "green");
        m.add("green");
        assertEquals(mExpected, m);
    }

    //TEST CASES FOR constructor
    @Test
    public final void testConstructorEmpty() {
        SortingMachine<String> sMTest1 = this.createFromArgsTest(ORDER, true);
        SortingMachine<String> sMExpected = this.createFromArgsRef(ORDER, true);
        assertEquals(sMExpected, sMTest1);
    }

    @Test
    public final void testConstructorOneElement() {
        SortingMachine<String> sMTest1 = this.createFromArgsTest(ORDER, true,
                "a");
        SortingMachine<String> sMExpected = this.createFromArgsRef(ORDER, true,
                "a");
        assertEquals(sMExpected, sMTest1);
    }

    @Test
    public final void testConstructorTwoElement() {
        SortingMachine<String> sMTest1 = this.createFromArgsTest(ORDER, true,
                "a", "b");
        SortingMachine<String> sMExpected = this.createFromArgsRef(ORDER, true,
                "a", "b");
        assertEquals(sMExpected, sMTest1);
    }

    //TEST CASES FOR add
    @Test
    public final void testAddToEmpty() {
        SortingMachine<String> sMTest1 = this.createFromArgsTest(ORDER, true);
        SortingMachine<String> sMExpected = this.createFromArgsRef(ORDER, true,
                "b");
        sMTest1.add("b");
        assertEquals(sMExpected, sMTest1);
    }

    @Test
    public final void testAddToOneElement() {
        SortingMachine<String> sMTest1 = this.createFromArgsTest(ORDER, true,
                "a");
        SortingMachine<String> sMExpected = this.createFromArgsRef(ORDER, true,
                "a", "b");
        sMTest1.add("b");
        assertEquals(sMExpected, sMTest1);

    }

    @Test
    public final void testAddToThreeElements() {
        SortingMachine<String> sMTest1 = this.createFromArgsTest(ORDER, true,
                "b", "a", "c");
        SortingMachine<String> sMExpected = this.createFromArgsRef(ORDER, true,
                "b", "a", "c", "z");
        sMTest1.add("z");
        assertEquals(sMExpected, sMTest1);

    }

    //TEST CASES FOR changeToExtractionMode
    @Test
    public final void testChangeToExtractionModeWhenEmpty() {
        SortingMachine<String> sMTest1 = this.createFromArgsTest(ORDER, true);
        SortingMachine<String> sMExpected = this.createFromArgsRef(ORDER,
                false);
        sMTest1.changeToExtractionMode();
        assertEquals(sMExpected, sMTest1);

    }

    @Test
    public final void testChangeToExtractionModeWithTwoElements() {
        SortingMachine<String> sMTest1 = this.createFromArgsTest(ORDER, true,
                "a", "c");
        SortingMachine<String> sMExpected = this.createFromArgsRef(ORDER, false,
                "a", "c");
        sMTest1.changeToExtractionMode();
        assertEquals(sMExpected, sMTest1);
    }

    //TEST CASES FOR isInInsertionMode
    @Test
    public final void testIsInInsertionModeWhenNonEmptyAndTrue() {
        SortingMachine<String> sMTest1 = this.createFromArgsTest(ORDER, true,
                "c", "b");
        SortingMachine<String> sMExpected = this.createFromArgsRef(ORDER, true,
                "c", "b");
        assertEquals(sMTest1.isInInsertionMode(), true);
        assertEquals(sMExpected, sMTest1);
    }

    @Test
    public final void testIsInInsertionModeWhenEmptyAndTrue() {
        SortingMachine<String> sMTest1 = this.createFromArgsTest(ORDER, true);
        SortingMachine<String> sMExpected = this.createFromArgsRef(ORDER, true);
        assertEquals(sMTest1.isInInsertionMode(), true);
        assertEquals(sMExpected, sMTest1);
    }

    @Test
    public final void testIsInInsertionModeWhenNonEmptyAndFalse() {
        SortingMachine<String> sMTest1 = this.createFromArgsTest(ORDER, true,
                "c", "b");
        SortingMachine<String> sMExpected = this.createFromArgsRef(ORDER, false,
                "c", "b");
        sMTest1.changeToExtractionMode();
        assertEquals(sMTest1.isInInsertionMode(), false);
        assertEquals(sMExpected, sMTest1);
    }

    @Test
    public final void testIsInInsertionModeWhenEmptyAndFalse() {
        SortingMachine<String> sMTest1 = this.createFromArgsTest(ORDER, true);
        SortingMachine<String> sMExpected = this.createFromArgsRef(ORDER,
                false);
        sMTest1.changeToExtractionMode();
        assertEquals(sMTest1.isInInsertionMode(), false);
        assertEquals(sMExpected, sMTest1);
    }

    //TEST CASES FOR order
    @Test
    public final void testOrderInsertionModeEmpty() {
        SortingMachine<String> sMTest1 = this.createFromArgsTest(ORDER, true);
        assertEquals(ORDER, sMTest1.order());
    }

    @Test
    public final void testOrderInsertionModeNonEmpty() {
        SortingMachine<String> sMTest1 = this.createFromArgsTest(ORDER, true,
                "b", "a");
        assertEquals(ORDER, sMTest1.order());
    }

    @Test
    public final void testOrderExtractionModeEmpty() {
        SortingMachine<String> sMTest1 = this.createFromArgsTest(ORDER, false);
        assertEquals(ORDER, sMTest1.order());
    }

    @Test
    public final void testOrderExtractionModeNonEmpty() {
        SortingMachine<String> sMTest1 = this.createFromArgsTest(ORDER, false,
                "b", "a");
        assertEquals(ORDER, sMTest1.order());
    }

    //TEST CASES FOR removeFirst.
    @Test
    public final void testRemoveFirstOneElement() {
        SortingMachine<String> sMTest1 = this.createFromArgsTest(ORDER, true,
                "a");
        SortingMachine<String> sMExpected = this.createFromArgsRef(ORDER,
                false);
        sMTest1.changeToExtractionMode();
        String a = sMTest1.removeFirst();
        assertEquals(a, "a");
        assertEquals(sMExpected, sMTest1);
    }

    @Test
    public final void testRemoveFirstThreeElements() {
        SortingMachine<String> sMTest1 = this.createFromArgsTest(ORDER, true,
                "c", "a", "b");
        SortingMachine<String> sMExpected = this.createFromArgsRef(ORDER, false,
                "c", "b");
        sMTest1.changeToExtractionMode();
        String a = sMTest1.removeFirst();
        assertEquals(a, "a");
        assertEquals(sMExpected, sMTest1);
    }

    //TEST CASES FOR size
    @Test
    public final void testSizeEmptyInsertion() {
        SortingMachine<String> sMTest1 = this.createFromArgsTest(ORDER, true);
        assertEquals(0, sMTest1.size());
    }

    @Test
    public final void testSizeOneInsertion() {
        SortingMachine<String> sMTest1 = this.createFromArgsTest(ORDER, true,
                "a");
        assertEquals(1, sMTest1.size());
    }

    @Test
    public final void testSizeTwoInsertion() {
        SortingMachine<String> sMTest1 = this.createFromArgsTest(ORDER, true,
                "a", "b");
        assertEquals(2, sMTest1.size());
    }

    @Test
    public final void testSizeEmptyExtraction() {
        SortingMachine<String> sMTest1 = this.createFromArgsTest(ORDER, false);
        assertEquals(0, sMTest1.size());
    }

    @Test
    public final void testSizeOneExtraction() {
        SortingMachine<String> sMTest1 = this.createFromArgsTest(ORDER, false,
                "a");
        assertEquals(1, sMTest1.size());
    }

    @Test
    public final void testSizeTwoExtraction() {
        SortingMachine<String> sMTest1 = this.createFromArgsTest(ORDER, false,
                "a", "b");
        assertEquals(2, sMTest1.size());
    }

}
