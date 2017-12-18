import static org.junit.Assert.assertTrue;

import org.junit.Test;

import components.set.Set;
import components.set.Set1L;
import components.simplereader.SimpleReader;
import components.simplereader.SimpleReader1L;
import components.simplewriter.SimpleWriter;
import components.simplewriter.SimpleWriter1L;

/**
 * JUnit fixture for testing printWithCommas.
 *
 * @author Jacob Ruth
 *
 */
public final class StringReassemblyTest {

    /**
     * Test printWithLineSeparators. normal string 0 newline
     */
    @Test
    public void printWithLineSeparators0newline() {
        SimpleWriter out = new SimpleWriter1L("data/testoutput.txt");
        SimpleReader in = new SimpleReader1L("data/testoutput.txt");
        String str = "test12345";
        StringReassembly.printWithLineSeparators(str, out);
        String firstLine = in.nextLine();
        out.close();
        in.close();
        assertTrue(firstLine.equals("test12345"));
    }

    /**
     * Test printWithLineSeparators. normal string 2 newline
     */
    @Test
    public void printWithLineSeparators2newline() {
        SimpleWriter out = new SimpleWriter1L("data/testoutput.txt");
        SimpleReader in = new SimpleReader1L("data/testoutput.txt");
        String str = "test~~12345";
        StringReassembly.printWithLineSeparators(str, out);
        String firstLine = in.nextLine();
        String secondLine = in.nextLine();
        String thirdLine = in.nextLine();
        out.close();
        in.close();
        assertTrue(firstLine.equals("test"));
        assertTrue(secondLine.equals(""));
        assertTrue(thirdLine.equals("12345"));
    }

    /**
     * Test printWithLineSeparators. normal string 1 newline
     */
    @Test
    public void printWithLineSeparators1newline() {
        SimpleWriter out = new SimpleWriter1L("data/testoutput.txt");
        SimpleReader in = new SimpleReader1L("data/testoutput.txt");
        String str = "test~12345";
        StringReassembly.printWithLineSeparators(str, out);
        String firstLine = in.nextLine();
        String secondLine = in.nextLine();
        out.close();
        in.close();
        assertTrue(firstLine.equals("test"));
        assertTrue(secondLine.equals("12345"));
    }

    /**
     * Test addToSetAvoidingSubstrings. add "test" to containing "nothing"
     */
    @Test
    public void addToSetAvoidingSubstrings3() {
        Set<String> set = new Set1L<String>();
        set.add("nothing");
        String str2 = "test";
        StringReassembly.addToSetAvoidingSubstrings(set, str2);
        assertTrue(set.contains("test"));
        assertTrue(set.contains("nothing"));
    }

    /**
     * Test addToSetAvoidingSubstrings. add "test" to containing "tes"
     */
    @Test
    public void addToSetAvoidingSubstrings2() {
        Set<String> set = new Set1L<String>();
        set.add("tes");
        String str2 = "test";
        StringReassembly.addToSetAvoidingSubstrings(set, str2);
        assertTrue(set.contains("test"));
    }

    /**
     * Test addToSetAvoidingSubstrings. add "test" to containing "testing"
     */
    @Test
    public void addToSetAvoidingSubstrings1() {
        Set<String> set = new Set1L<String>();
        set.add("testing");
        String str2 = "test";
        StringReassembly.addToSetAvoidingSubstrings(set, str2);
        assertTrue(!set.contains("test"));
    }

    /**
     * Test combination. 1 overlap "testing"
     */
    @Test
    public void combination1Overlap() {
        String str1 = "test";
        String str2 = "ting";
        String ret = StringReassembly.combination(str1, str2, 1);
        assertTrue(ret.equals("testing"));
    }

    /**
     * Test combination. 2 overlap "testting"
     */
    @Test
    public void combination2Overlap() {
        String str1 = "testt";
        String str2 = "tting";
        String ret = StringReassembly.combination(str1, str2, 2);
        assertTrue(ret.equals("testting"));
    }

    /**
     * Test combination. 0 overlap "testing"
     */
    @Test
    public void combination0Overlap() {
        String str1 = "test";
        String str2 = "ing";
        String ret = StringReassembly.combination(str1, str2, 0);
        assertTrue(ret.equals("testing"));
    }
}
