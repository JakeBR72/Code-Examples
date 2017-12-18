import static org.junit.Assert.assertEquals;

import org.junit.Test;

import components.sequence.Sequence;
import components.sequence.Sequence1L;

/**
 * Sample JUnit test fixture for Homework.
 *
 * @author Jacob Ruth
 *
 */
public final class HomeworkTest {

    /**
     * Constructs and returns a sequence of the integers provided as arguments.
     *
     * @param args
     *            0 or more integer arguments
     * @return the sequence of the given arguments
     * @ensures createFromArgs= [the sequence of integers in args]
     */
    private Sequence<Integer> createFromArgs(Integer... args) {
        Sequence<Integer> s = new Sequence1L<Integer>();
        for (Integer x : args) {
            s.add(s.length(), x);
        }
        return s;
    }

    @Test
    public void test1() {
        /*
         * Set up variables and call method under test
         */
        int i = Integer.MAX_VALUE;
        int j = Integer.MAX_VALUE - 1;
        int avg = Homework.average(i, j);
        /*
         * Assert that values of variables match expectations
         */
        assertEquals(Integer.MAX_VALUE - 1, avg);
    }

    @Test
    public void test2() {
        /*
         * Set up variables and call method under test
         */
        int i = Integer.MIN_VALUE;
        int j = Integer.MIN_VALUE + 1;
        int avg = Homework.average(i, j);
        /*
         * Assert that values of variables match expectations
         */
        assertEquals(Integer.MIN_VALUE - 1, avg);
    }

    @Test
    public void test3() {
        /*
         * Set up variables and call method under test
         */
        int i = Integer.MIN_VALUE;
        int j = Integer.MIN_VALUE;
        int avg = Homework.average(i, j);
        /*
         * Assert that values of variables match expectations
         */
        assertEquals(Integer.MIN_VALUE, avg);
    }

    @Test
    public void test4() {
        /*
         * Set up variables and call method under test
         */
        int i = Integer.MAX_VALUE;
        int j = Integer.MAX_VALUE;
        int avg = Homework.average(i, j);
        /*
         * Assert that values of variables match expectations
         */
        assertEquals(Integer.MAX_VALUE, avg);
    }

    @Test
    public void test6() {
        /*
         * Set up variables and call method under test
         */
        int i = -1073741824;
        int j = 1073741825;
        int avg = Homework.average(i, j);
        /*
         * Assert that values of variables match expectations
         */
        assertEquals(0, avg);
    }

    @Test
    public void test1normal() {
        /*
         * Set up variables and call method under test
         */
        int i = 5;
        int j = 8;
        int avg = Homework.average(i, j);
        /*
         * Assert that values of variables match expectations
         */
        assertEquals(6, avg);
    }

    @Test
    public void test2normal() {
        /*
         * Set up variables and call method under test
         */
        int i = -5;
        int j = -8;
        int avg = Homework.average(i, j);
        /*
         * Assert that values of variables match expectations
         */
        assertEquals(-6, avg);
    }

    @Test
    public void test3normal() {
        /*
         * Set up variables and call method under test
         */
        int i = 11;
        int j = -4;
        int avg = Homework.average(i, j);
        /*
         * Assert that values of variables match expectations
         */
        assertEquals(3, avg);
    }

    @Test
    public void test4normal() {
        /*
         * Set up variables and call method under test
         */
        int i = -3;
        int j = 2;
        int avg = Homework.average(i, j);
        /*
         * Assert that values of variables match expectations
         */
        assertEquals(0, avg);
    }

    @Test
    public void test5normal() {
        /*
         * Set up variables and call method under test
         */
        int i = 3;
        int j = 5;
        int avg = Homework.average(i, j);
        /*
         * Assert that values of variables match expectations
         */
        assertEquals(4, avg);
    }

    @Test
    public void test6normal() {
        /*
         * Set up variables and call method under test
         */
        int i = -3;
        int j = -5;
        int avg = Homework.average(i, j);
        /*
         * Assert that values of variables match expectations
         */
        assertEquals(-4, avg);
    }
}
