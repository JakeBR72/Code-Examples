import static org.junit.Assert.assertEquals;

import org.junit.Test;

import components.program.Program;
import components.queue.Queue;
import components.simplereader.SimpleReader;
import components.simplereader.SimpleReader1L;
import components.utilities.Tokenizer;

/**
 * JUnit test fixture for {@code Program}'s constructor and kernel methods.
 *
 * @author Gautham Sivakumar, Jacob Ruth, Taha Topiwala
 *
 */
public abstract class ProgramTest {

    /**
     * The names of a files containing a (possibly invalid) BL programs.
     */
    private static final String FILE_NAME_1 = "test/program1.bl",
            FILE_NAME_2 = "test/program2.bl",
            CUSTOM_1 = "test/program_invalid_name_instruction.bl",
            CUSTOM_2 = "test/program_missing_begin.bl",
            CUSTOM_3 = "test/program_missing_end_instruction.bl",
            CUSTOM_4 = "test/program_missing_end.bl",
            CUSTOM_5 = "test/program_missing_instruction.bl",
            CUSTOM_6 = "test/program_missing_is_instruction.bl",
            CUSTOM_7 = "test/program_missing_is.bl",
            CUSTOM_8 = "test/program_missing_name_final_instruction.bl",
            CUSTOM_9 = "test/program_missing_name_final.bl",
            CUSTOM_10 = "test/program_missing_name_instruction.bl",
            CUSTOM_11 = "test/program_missing_name.bl",
            CUSTOM_12 = "test/program_missing_program.bl",
            CUSTOM_13 = "test/program_repeat_name_instruction.bl";

    /**
     * Invokes the {@code Program} constructor for the implementation under test
     * and returns the result.
     *
     * @return the new program
     * @ensures constructorTest = ("Unnamed", {}, compose((BLOCK, ?, ?), <>))
     */
    protected abstract Program constructorTest();

    /**
     * Invokes the {@code Program} constructor for the reference implementation
     * and returns the result.
     *
     * @return the new program
     * @ensures constructorRef = ("Unnamed", {}, compose((BLOCK, ?, ?), <>))
     */
    protected abstract Program constructorRef();

    /**
     * Test of parse on syntactically valid input.
     */
    @Test
    public final void testParseValidExample() {
        /*
         * Setup
         */
        Program pRef = this.constructorRef();
        SimpleReader file = new SimpleReader1L(FILE_NAME_1);
        pRef.parse(file);
        file.close();
        Program pTest = this.constructorTest();
        file = new SimpleReader1L(FILE_NAME_1);
        Queue<String> tokens = Tokenizer.tokens(file);
        file.close();
        /*
         * The call
         */
        pTest.parse(tokens);
        /*
         * Evaluation
         */
        assertEquals(pRef, pTest);
    }

    /**
     * Test of parse on syntactically invalid input.
     */
    @Test(expected = RuntimeException.class)
    public final void testParseErrorExample() {
        /*
         * Setup
         */
        Program pTest = this.constructorTest();
        SimpleReader file = new SimpleReader1L(FILE_NAME_2);
        Queue<String> tokens = Tokenizer.tokens(file);
        file.close();
        /*
         * The call--should result in a syntax error being found
         */
        pTest.parse(tokens);
    }

    //CUSTOM TEST CASES
    /**
     * Test of parse on syntactically invalid input.
     */
    @Test(expected = RuntimeException.class)
    public final void testParseError_invalid_name_instruction() {
        Program pTest = this.constructorTest();
        SimpleReader file = new SimpleReader1L(CUSTOM_1);
        Queue<String> tokens = Tokenizer.tokens(file);
        file.close();
        pTest.parse(tokens);
    }

    /**
     * Test of parse on syntactically invalid input.
     */
    @Test(expected = RuntimeException.class)
    public final void testParseError_missing_begin() {
        Program pTest = this.constructorTest();
        SimpleReader file = new SimpleReader1L(CUSTOM_2);
        Queue<String> tokens = Tokenizer.tokens(file);
        file.close();
        pTest.parse(tokens);
    }

    /**
     * Test of parse on syntactically invalid input.
     */
    @Test(expected = RuntimeException.class)
    public final void testParseError_missing_end_instruction() {
        Program pTest = this.constructorTest();
        SimpleReader file = new SimpleReader1L(CUSTOM_3);
        Queue<String> tokens = Tokenizer.tokens(file);
        file.close();
        pTest.parse(tokens);
    }

    /**
     * Test of parse on syntactically invalid input.
     */
    @Test(expected = RuntimeException.class)
    public final void testParseError_missing_end() {
        Program pTest = this.constructorTest();
        SimpleReader file = new SimpleReader1L(CUSTOM_4);
        Queue<String> tokens = Tokenizer.tokens(file);
        file.close();
        pTest.parse(tokens);
    }

    /**
     * Test of parse on syntactically invalid input.
     */
    @Test(expected = RuntimeException.class)
    public final void testParseError_missing_instruction() {
        Program pTest = this.constructorTest();
        SimpleReader file = new SimpleReader1L(CUSTOM_5);
        Queue<String> tokens = Tokenizer.tokens(file);
        file.close();
        pTest.parse(tokens);
    }

    /**
     * Test of parse on syntactically invalid input.
     */
    @Test(expected = RuntimeException.class)
    public final void testParseError_missing_is_instruction() {
        Program pTest = this.constructorTest();
        SimpleReader file = new SimpleReader1L(CUSTOM_6);
        Queue<String> tokens = Tokenizer.tokens(file);
        file.close();
        pTest.parse(tokens);
    }

    /**
     * Test of parse on syntactically invalid input.
     */
    @Test(expected = RuntimeException.class)
    public final void testParseError_missing_is() {
        Program pTest = this.constructorTest();
        SimpleReader file = new SimpleReader1L(CUSTOM_7);
        Queue<String> tokens = Tokenizer.tokens(file);
        file.close();
        pTest.parse(tokens);
    }

    /**
     * Test of parse on syntactically invalid input.
     */
    @Test(expected = RuntimeException.class)
    public final void testParseError_missing_name_final_instruction() {
        Program pTest = this.constructorTest();
        SimpleReader file = new SimpleReader1L(CUSTOM_8);
        Queue<String> tokens = Tokenizer.tokens(file);
        file.close();
        pTest.parse(tokens);
    }

    /**
     * Test of parse on syntactically invalid input.
     */
    @Test(expected = RuntimeException.class)
    public final void testParseError_missing_name_final() {
        Program pTest = this.constructorTest();
        SimpleReader file = new SimpleReader1L(CUSTOM_9);
        Queue<String> tokens = Tokenizer.tokens(file);
        file.close();
        pTest.parse(tokens);
    }

    /**
     * Test of parse on syntactically invalid input.
     */
    @Test(expected = RuntimeException.class)
    public final void testParseError_missing_name_instruction() {
        Program pTest = this.constructorTest();
        SimpleReader file = new SimpleReader1L(CUSTOM_10);
        Queue<String> tokens = Tokenizer.tokens(file);
        file.close();
        pTest.parse(tokens);
    }

    /**
     * Test of parse on syntactically invalid input.
     */
    @Test(expected = RuntimeException.class)
    public final void testParseError_missing_name() {
        Program pTest = this.constructorTest();
        SimpleReader file = new SimpleReader1L(CUSTOM_11);
        Queue<String> tokens = Tokenizer.tokens(file);
        file.close();
        pTest.parse(tokens);
    }

    /**
     * Test of parse on syntactically invalid input.
     */
    @Test(expected = RuntimeException.class)
    public final void testParseError_missing_program() {
        Program pTest = this.constructorTest();
        SimpleReader file = new SimpleReader1L(CUSTOM_12);
        Queue<String> tokens = Tokenizer.tokens(file);
        file.close();
        pTest.parse(tokens);
    }

    /**
     * Test of parse on syntactically invalid input.
     */
    @Test(expected = RuntimeException.class)
    public final void testParseError_repeat_name_instruction() {
        Program pTest = this.constructorTest();
        SimpleReader file = new SimpleReader1L(CUSTOM_13);
        Queue<String> tokens = Tokenizer.tokens(file);
        file.close();
        pTest.parse(tokens);
    }
}
