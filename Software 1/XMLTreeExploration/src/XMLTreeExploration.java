import components.simplereader.SimpleReader;
import components.simplereader.SimpleReader1L;
import components.simplewriter.SimpleWriter;
import components.simplewriter.SimpleWriter1L;
import components.xmltree.XMLTree;
import components.xmltree.XMLTree1;

/**
 * Put a short phrase describing the program here.
 *
 * @author Put your name here
 *
 */
public final class XMLTreeExploration {

    /**
     * Private constructor so this utility class cannot be instantiated.
     */
    private XMLTreeExploration() {
    }

    /**
     * Output all attributes names and values for the root of the given
     * {@code XMLTree}.
     *
     * @param xt
     *            the {@code XMLTree} whose root's attributes are to be printed
     *
     * @param out
     *            the output stream
     * @updates out.content
     * @requires [the label of the root of xt is a tag] and out.is_open
     * @ensures <pre>
     *     out.content = #out.content
     *     [the name and value of each attribute of the root of xt]
     * </pre>
     *
     *           
     */
    private static void printRootAttributes(XMLTree xt, SimpleWriter out) {
        XMLTree tree = xt;
        for (String name : tree.attributeNames()) {
            out.println(name + ", " + tree.attributeValue(name));
        }
    }

    /**
     * Output information about the middle child of the given {@code XMLTree}.
     *
     * @param xt
     *            the {@code XMLTree} whose middle child is to be printed
     * @param out
     *            the output stream
     * @updates out.content
     * @requires<pre> [the label of the root of xt is a tag]  and [xt has at
     *                least one child]  and  out.is_opens </pre>
     *
     * @ensures <pre>
     *     out.content = #out.content [the label of the middle child
     *     of xt, whether the root of the middle child is a tag or text,
     *     and if it is a tag, the number of children of the middle child]
     * </pre>
     *
     *           
     */
    private static void printMiddleNode(XMLTree xt, SimpleWriter out) {
        XMLTree tree = xt;
        SimpleWriter o = out;
        XMLTree treeChild = tree.child((tree.numberOfChildren() / 2));
        o.println("label(): " + treeChild.label());
        o.println("isTag()? " + treeChild.isTag());
        if (tree.child((tree.numberOfChildren() / 2)).isTag()) {
            o.println("numberOfChildren(): " + treeChild.numberOfChildren());
        }
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
        XMLTree xml = new XMLTree1(
                "http://xml.weather.yahoo.com/forecastrss/43210.xml");
        //out.print(xml.toString());
        xml.display();
        out.println("isTag()? " + xml.isTag() + ",  label: " + xml.label());

        XMLTree channel = xml.child(0);
        out.println("numberOfChildren(): " + channel.numberOfChildren());
        XMLTree title = channel.child(0);
        XMLTree titleText = title.child(0);
        out.println("Title text: " + titleText.toString());
        out.println("Title text ( 1 line ): "
                + xml.child(0).child(0).child(0).toString());

        XMLTree astronomy = channel.child(10);
        out.println("sunset? " + astronomy.hasAttribute("sunset")
                + ", midday? " + astronomy.hasAttribute("midday"));
        out.println("sunrise: " + astronomy.attributeValue("sunrise")
                + ", sunset: " + astronomy.attributeValue("sunset"));

        printMiddleNode(channel, out);

        XMLTree item = channel.child(12);
        XMLTree forecast = item.child(8);
        printRootAttributes(forecast, out);

        in.close();
        out.close();
    }
}
