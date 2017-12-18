import components.stack.Stack;
import components.stack.Stack2;

/**
 * Model class.
 *
 * @author Jacob Ruth
 */
public final class AppendUndoModel1 implements AppendUndoModel {

    /**
     * Model variables.
     */
    private String input, output;
    /**
     * Model Variable.
     */
    private Stack<String> outputStack = new Stack2<String>();

    /**
     * Default constructor.
     */
    public AppendUndoModel1() {
        /*
         * Initialize model; both variables start as empty strings
         */
        this.input = "";
        this.output = "";
    }

    @Override
    public void setInput(String input) {
        this.input = input;
    }

    @Override
    public String input() {
        return this.input;
    }

    @Override
    public Stack<String> output() {
        return this.outputStack;
    }

}
