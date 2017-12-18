import static org.junit.Assert.assertEquals;

import org.junit.Test;

import components.set.Set;

/**
 * JUnit test fixture for {@code Set<String>}'s constructor and kernel methods.
 *
 * @author Put your name here
 *
 */
public abstract class SetTest {

    /**
     * Invokes the appropriate {@code Set} constructor and returns the result.
     *
     * @return the new set
     * @ensures constructorTest = {}
     */
    protected abstract Set<String> constructorTest();

    /**
     * Invokes the appropriate {@code Set} constructor and returns the result.
     *
     * @return the new set
     * @ensures constructorRef = {}
     */
    protected abstract Set<String> constructorRef();

    /**
     * Creates and returns a {@code Set<String>} of the implementation under
     * test type with the given entries.
     *
     * @param args
     *            the entries for the set
     * @return the constructed set
     * @requires [every entry in args is unique]
     * @ensures createFromArgsTest = [entries in args]
     */
    private Set<String> createFromArgsTest(String... args) {
        Set<String> set = this.constructorTest();
        for (String s : args) {
            assert!set.contains(
                    s) : "Violation of: every entry in args is unique";
            set.add(s);
        }
        return set;
    }

    /**
     * Creates and returns a {@code Set<String>} of the reference implementation
     * type with the given entries.
     *
     * @param args
     *            the entries for the set
     * @return the constructed set
     * @requires [every entry in args is unique]
     * @ensures createFromArgsRef = [entries in args]
     */
    private Set<String> createFromArgsRef(String... args) {
        Set<String> set = this.constructorRef();
        for (String s : args) {
            assert!set.contains(
                    s) : "Violation of: every entry in args is unique";
            set.add(s);
        }
        return set;
    }

    /**
     * Add: to 0 element(s).
     */
    @Test
    public final void testAdd0() {
        Set<String> set1 = this.createFromArgsTest();
        Set<String> set1Expected = this.createFromArgsRef("red");
        set1.add("red");
        assertEquals(set1Expected, set1);
    }

    /**
     * Add: to 1 element(s).
     */
    @Test
    public final void testAdd1() {
        Set<String> set1 = this.createFromArgsTest("red");
        Set<String> set1Expected = this.createFromArgsRef("red", "green");
        set1.add("green");
        assertEquals(set1Expected, set1);
    }

    /**
     * Remove: from 1 element(s).
     */
    @Test
    public final void testRemove1() {
        Set<String> set1 = this.createFromArgsTest("red");
        Set<String> set1Expected = this.createFromArgsRef();
        set1.remove("red");
        assertEquals(set1Expected, set1);
    }

    /**
     * Remove: from 2 element(s).
     */
    @Test
    public final void testRemove2() {
        Set<String> set1 = this.createFromArgsTest("red", "green");
        Set<String> set1Expected = this.createFromArgsRef("green");
        set1.remove("red");
        assertEquals(set1Expected, set1);
    }

    /**
     * RemoveAny: 1 element(s).
     */
    @Test
    public final void testRemoveAny1() {
        Set<String> set1 = this.createFromArgsTest("red");
        Set<String> set1Expected = this.createFromArgsRef();
        set1.removeAny();
        assertEquals(set1Expected, set1);
    }

    /**
     * Contains: 1 element(s).
     */
    @Test
    public final void testContains1() {
        Set<String> set1 = this.createFromArgsTest("red");
        boolean set1Expected = true;
        boolean set1Bool = set1.contains("red");
        assertEquals(set1Expected, set1Bool);
    }

    /**
     * Size: 0 element(s).
     */
    @Test
    public final void testSize0() {
        Set<String> set1 = this.createFromArgsTest();
        int set1Expected = 0;
        int set1Size = set1.size();
        assertEquals(set1Expected, set1Size);
    }

    /**
     * Size: 1 element(s).
     */
    @Test
    public final void testSize1() {
        Set<String> set1 = this.createFromArgsTest("red");
        int set1Expected = 1;
        int set1Size = set1.size();
        assertEquals(set1Expected, set1Size);
    }
}
