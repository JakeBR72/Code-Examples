import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertTrue;

import org.junit.Test;

import components.map.Map;

/**
 * JUnit test fixture for {@code Map<String, String>}'s constructor and kernel
 * methods.
 *
 * @author Put your name here
 *
 */
public abstract class MapTest {

    /**
     * Invokes the appropriate {@code Map} constructor for the implementation
     * under test and returns the result.
     *
     * @return the new map
     * @ensures constructorTest = {}
     */
    protected abstract Map<String, String> constructorTest();

    /**
     * Invokes the appropriate {@code Map} constructor for the reference
     * implementation and returns the result.
     *
     * @return the new map
     * @ensures constructorRef = {}
     */
    protected abstract Map<String, String> constructorRef();

    /**
     *
     * Creates and returns a {@code Map<String, String>} of the implementation
     * under test type with the given entries.
     *
     * @param args
     *            the (key, value) pairs for the map
     * @return the constructed map
     * @requires
     *
     *           <pre>
     * [args.length is even]  and
     * [the 'key' entries in args are unique]
     *           </pre>
     *
     * @ensures createFromArgsTest = [pairs in args]
     */
    private Map<String, String> createFromArgsTest(String... args) {
        assert args.length % 2 == 0 : "Violation of: args.length is even";
        Map<String, String> map = this.constructorTest();
        for (int i = 0; i < args.length; i += 2) {
            assert!map.hasKey(args[i]) : ""
                    + "Violation of: the 'key' entries in args are unique";
            map.add(args[i], args[i + 1]);
        }
        return map;
    }

    /**
     *
     * Creates and returns a {@code Map<String, String>} of the reference
     * implementation type with the given entries.
     *
     * @param args
     *            the (key, value) pairs for the map
     * @return the constructed map
     * @requires
     *
     *           <pre>
     * [args.length is even]  and
     * [the 'key' entries in args are unique]
     *           </pre>
     *
     * @ensures createFromArgsRef = [pairs in args]
     */
    private Map<String, String> createFromArgsRef(String... args) {
        assert args.length % 2 == 0 : "Violation of: args.length is even";
        Map<String, String> map = this.constructorRef();
        for (int i = 0; i < args.length; i += 2) {
            assert!map.hasKey(args[i]) : ""
                    + "Violation of: the 'key' entries in args are unique";
            map.add(args[i], args[i + 1]);
        }
        return map;
    }

    // TODO - add test cases for constructor, add, remove, removeAny, value, hasKey, and size

    @Test
    public void testConstructor1() {

        Map<String, String> Seq = this.createFromArgsTest("A", "1", "B", "2");

        Map<String, String> expectedSeq = this.createFromArgsRef("A", "1", "B",
                "2");

        assertEquals(Seq, expectedSeq);
    }

    @Test
    public void testAdd1() {
        Map<String, String> Seq = this.createFromArgsTest();
        Map<String, String> expectedSeq = this.createFromArgsRef("A", "1");

        Seq.add("A", "1");

        assertEquals(expectedSeq, Seq);
    }

    @Test
    public void testRemove1() {
        Map<String, String> Seq = this.createFromArgsTest("B", "2");
        Map<String, String> expectedSeq = this.createFromArgsRef();

        Seq.remove("B");

        assertEquals(Seq, expectedSeq);
    }

    @Test
    public void testSize() {
        Map<String, String> Seq = this.createFromArgsTest("A", "1", "B", "2");

        int size = Seq.size();
        int expSize = 2;

        assertEquals(size, expSize);
    }

    @Test
    public void testRemoveAny() {
        Map<String, String> Seq = this.createFromArgsTest("A", "1", "B", "2");
        Map<String, String> expectedSeq = this.createFromArgsRef("A", "1", "B",
                "2");

        Seq.removeAny();

        assertEquals(Seq.size(), expectedSeq.size() - 1);
    }

    @Test
    public void testHasKey() {
        Map<String, String> Seq = this.createFromArgsTest("A", "1", "B", "2");

        boolean testing = Seq.hasKey("A");

        assertTrue(testing);
    }

    @Test
    public void testDoesNotHaveKey() {
        Map<String, String> Seq = this.createFromArgsTest("A", "1", "B", "2");

        boolean testing = Seq.hasKey("C");

        assertTrue(!testing);
    }

    @Test
    public void testValue() {
        Map<String, String> Seq = this.createFromArgsTest("A", "1", "B", "2");

        String testing = Seq.value("A");

        assertEquals("1", testing);
    }

}
