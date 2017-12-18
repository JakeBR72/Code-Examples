import components.naturalnumber.NaturalNumber;
import components.naturalnumber.NaturalNumber2;
import components.simplereader.SimpleReader;
import components.simplereader.SimpleReader1L;
import components.simplewriter.SimpleWriter;
import components.simplewriter.SimpleWriter1L;
import components.utilities.Reporter;
import components.xmltree.XMLTree;
import components.xmltree.XMLTree1;

/**
 * Program to evaluate XMLTree expressions of {@code int}.
 *
 * @author Jacob Ruth
 *
 */
public final class XMLTreeNNExpressionEvaluator {

    /**
     * Private constructor so this utility class cannot be instantiated.
     */
    private XMLTreeNNExpressionEvaluator() {
    }

    /**
     * Evaluate the given expression.
     *
     * @param exp
     *            the {@code XMLTree} representing the expression
     * @return the value of the expression
     * @requires <pre>
     * [exp is a subtree of a well-formed XML arithmetic expression]  and
     * [the label of the root of exp is not "expression"]
     * </pre>
     *
     * @ensures evaluate = [the value of the expression]  
     */
    private static NaturalNumber evaluate(XMLTree exp) {
        assert exp != null : "Violation of: exp is not null";
        NaturalNumber val1 = new NaturalNumber2(0);
        NaturalNumber val2 = new NaturalNumber2(0);
        NaturalNumber retVal = new NaturalNumber2(0);
        final NaturalNumber zero = new NaturalNumber2(0);
        if (exp.label().equals("number")) {
            retVal = new NaturalNumber2(exp.attributeValue("value"));
        } else {
            val1 = evaluate(exp.child(0));
            val2 = evaluate(exp.child(1));
        }
        if (exp.label().equals("divide")) {
            retVal.copyFrom(val1);
            if (val2.compareTo(zero) > 0) {
                retVal.divide(val2);
            } else {
                Reporter.fatalErrorToConsole("ERROR: (b == 0) when trying "
                        + "(a/b) this would result in a division by zero "
                        + "which is impossible");
            }
        } else if (exp.label().equals("times")) {
            retVal.copyFrom(val1);
            retVal.multiply(val2);
        } else if (exp.label().equals("plus")) {
            retVal.copyFrom(val1);
            retVal.add(val2);
        } else if (exp.label().equals("minus")) {
            retVal.copyFrom(val1);
            if (retVal.compareTo(val2) >= 0) {
                retVal.subtract(val2);
            } else {
                Reporter.fatalErrorToConsole("ERROR: (b > a) when trying "
                        + "(a - b) this would result in a negative number "
                        + "which NaturalNumber cannot handle");
            }
        }
        return retVal;
    }

    /**
     * Main method.
     *
     * @param args
     *            the command line arguments
     */
    public static void main(String[] args) {
        SimpleReader in = new SimpleReader1L();
        SimpleWriter out = new SimpleWriter1L();

        out.print("Enter the name of an expression XML file: ");
        String file = in.nextLine();
        while (!file.equals("")) {
            XMLTree exp = new XMLTree1(file);
            out.println(evaluate(exp.child(0)));
            out.print("Enter the name of an expression XML file: ");
            file = in.nextLine();
        }

        in.close();
        out.close();
    }

}
