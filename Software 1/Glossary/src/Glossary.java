import java.util.Comparator;

import components.map.Map;
import components.map.Map2;
import components.queue.Queue;
import components.queue.Queue2;
import components.set.Set;
import components.set.Set1L;
import components.simplereader.SimpleReader;
import components.simplereader.SimpleReader1L;
import components.simplewriter.SimpleWriter;
import components.simplewriter.SimpleWriter1L;

/**
 * This prorgam creates a glossary of terms from a given file by creating an
 * html document for each term and definition as well as an index page.
 *
 * @author Jacob Ruth
 *
 */
public final class Glossary {
    /**
     * Compare {@code String}s in lexicographic order.
     */
    private static class StringLT implements Comparator<String> {
        @Override
        public int compare(String first, String second) {
            return first.compareTo(second);
        }
    }

    /**
     * Private constructor so this utility class cannot be instantiated.
     */
    private Glossary() {
    }

    /**
     * Reads the file in and puts all terms and definitions into a map.
     *
     * @author Jacob Ruth
     * @param html
     *            The html document to read from.
     * @param termsAndDefs
     *            The map of terms and definitions to be modified.
     * @requires html is open
     * @ensures File will be read and all terms and definitions will be added to
     *          the Map, termsAnd Defs
     * @updates {@code termsAndDefs}
     */
    public static void readFile(SimpleReader html,
            Map<String, String> termsAndDefs) {
        while (!html.atEOS()) {
            String term = html.nextLine();
            String definition = "";
            boolean done = false;
            while (!done) {
                String nextLine = html.nextLine();
                if (nextLine.equals("")) {
                    done = true;
                } else {
                    definition = definition.concat(" " + nextLine);
                }
            }
            termsAndDefs.add(term, definition);
        }
    }

    /**
     * Prints an html document cooresponding to each term.
     *
     * @author Jacob Ruth
     * @param termsAndDefs
     *            The map of terms and definitions
     * @param separatorSet
     *            The set of separators to check for
     * @requires termsAndDefs is not empty, separatorSet is not empty
     * @ensures For each term there will be a generated html document with the
     *          team and its definition as well as a link back to the index page
     */
    public static void printTermPages(Map<String, String> termsAndDefs,
            Set<Character> separatorSet) {
        for (Map.Pair<String, String> item : termsAndDefs) {

            String definition = item.value();
            String term = item.key();
            SimpleWriter termHtml = new SimpleWriter1L("output/" + term
                    + ".html");
            printHeader(termHtml, term);
            termHtml.println("<h2><b><i><font color=\"red\">" + term
                    + "</font></i></b></h2>");
            termHtml.print("<blockquote>");

            int position = 0;
            while (position < definition.length()) {
                String returned = nextWordOrSeparator(definition, position,
                        separatorSet);
                boolean printReturned = true;
                for (Map.Pair<String, String> item2 : termsAndDefs) {
                    if (returned.equals(item2.key())) {
                        printReturned = false;
                        termHtml.print("<a href=\"" + item2.key() + ".html\">"
                                + item2.key() + "</a>");
                    }
                }
                if (printReturned) {
                    termHtml.print(returned);
                }
                position += returned.length();
            }

            termHtml.println("</blockquote>");
            termHtml.println("<hr />");
            termHtml.println("<p>Return to <a href=\"index.html\">index</a>.</p>");
            termHtml.println("</body>");
            termHtml.println("</html>");
            termHtml.close();
        }
    }

    /**
     * Prints an html document for the index page.
     *
     * @author Jacob Ruth
     * @param html
     *            The SimpleWriter to print to
     * @param termsAndDefs
     *            The map of terms and definitions
     * @requires html is open, termsAndDefs is not empty
     * @ensures An html document will be generated listing all terms in
     *          alphabetical order
     */
    public static void printIndexPage(SimpleWriter html,
            Map<String, String> termsAndDefs) {

        printHeader(html, "Glossary");
        html.println("<h2>Glossary</h2>");
        html.println("<hr />");
        html.println("<h3>Index</h3>");
        html.println("<ul>");

        for (Map.Pair<String, String> term : termsAndDefs) {
            html.println("<li><a href=\"" + term.key() + ".html\">"
                    + term.key() + "</a></li>");
        }

        html.println("</ul>");
        html.println("</body>");
        html.println("</html>");
    }

    /**
     * Prints the header of an HTML document.
     *
     * @author Jacob Ruth
     * @param html
     *            The SimpleWriter to print to
     * @param title
     *            The title to set the page to
     * @requires html is open, title is not null
     *
     */
    public static void printHeader(SimpleWriter html, String title) {
        html.println("<html>");
        html.println("<head>");
        html.println("<title>" + title + "</title>");
        html.println("</head>");
        html.println("<body>");
    }

    /**
     * Sorts the given map alphabetically.
     *
     * @author Jacob Ruth
     * @param termsAndDefs
     *            The map of terms and definitions
     * @updates {@code termsAndDefs}
     * @requires <pre>
     * {@code [map.size() > 0 ]}
     * </pre>
     * @ensures <pre>
     * {@code termsAndDefs.content = [#termsAndDefs.content sorted
     * alphabetically]}
     * </pre>
     */
    private static void sortTermsAlphabetically(Map<String, String> termsAndDefs) {
        Map<String, String> tempMap = new Map2<String, String>();
        tempMap.transferFrom(termsAndDefs);
        Queue<String> tempTerms = new Queue2<String>();
        for (Map.Pair<String, String> term : tempMap) {
            tempTerms.enqueue(term.key());
        }

        Comparator<String> order = new StringLT();
        tempTerms.sort(order);
        while (tempTerms.length() > 0) {
            String term = tempTerms.front();
            String definition = tempMap.value(tempTerms.dequeue());
            termsAndDefs.add(term, definition);
        }
    }

    /**
     * Generates the set of characters in the given {@code String} into the
     * given {@code Set}.
     *
     * @author Jacob Ruth
     * @param str
     *            the given {@code String}
     * @param strSet
     *            the {@code Set} to be replaced
     * @replaces strSet
     * @ensures strSet = entries(str)
     */
    private static void generateElements(String str, Set<Character> strSet) {
        assert str != null : "Violation of: str is not null";
        assert strSet != null : "Violation of: strSet is not null";
        strSet.clear();
        char[] strCharArr = str.toCharArray();
        for (int i = 0; i < strCharArr.length; i++) {
            if (!strSet.contains(strCharArr[i])) {
                strSet.add(strCharArr[i]);
            }
        }
    }

    /**
     * Returns the first "word" (maximal length string of characters not in
     * {@code separators}) or "separator string" (maximal length string of
     * characters in {@code separators}) in the given {@code text} starting at
     * the given {@code position}.
     *
     * @author Jacob Ruth [Note: Method was discussed between Matthew Blosco and
     *         Jacob Ruth during lab. The methods will most likely be very
     *         similar or share key elements]
     * @param text
     *            the {@code String} from which to get the word or separator
     *            string
     * @param position
     *            the starting index
     * @param separators
     *            the {@code Set} of separator characters
     * @return the first word or separator string found in {@code text} starting
     *         at index {@code position}
     * @requires 0 <= position < |text|
     * @ensures <pre>
     * nextWordOrSeparator =
     *   text[position, position + |nextWordOrSeparator|)  and
     * if entries(text[position, position + 1)) intersection separators = {}
     * then
     *   entries(nextWordOrSeparator) intersection separators = {}  and
     *   (position + |nextWordOrSeparator| = |text|  or
     *    entries(text[position, position + |nextWordOrSeparator| + 1))
     *      intersection separators /= {})
     * else
     *   entries(nextWordOrSeparator) is subset of separators  and
     *   (position + |nextWordOrSeparator| = |text|  or
     *    entries(text[position, position + |nextWordOrSeparator| + 1))
     *      is not subset of separators)
     * </pre>
     */
    private static String nextWordOrSeparator(String text, int position,
            Set<Character> separators) {
        assert text != null : "Violation of: text is not null";
        assert separators != null : "Violation of: separators is not null";
        assert 0 <= position : "Violation of: 0 <= position";
        assert position < text.length() : "Violation of: position < |text|";

        String returnString = "";
        int i = position;
        if (!separators.contains(text.charAt(position))) {
            while (i < text.length() && !separators.contains(text.charAt(i))) {
                i++;
            }
            returnString = text.substring(position, i);
        } else {
            while (i < text.length() && separators.contains(text.charAt(i))) {
                i++;
            }
            returnString = text.substring(position, i);
        }
        return returnString;
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

        //Define separator characters for testing
        final String separatorStr = " \t, ";
        Set<Character> separatorSet = new Set1L<>();
        generateElements(separatorStr, separatorSet);

        //Ask user for data file
        out.println("Please enter a data txt file:");
        String dataFileName = in.nextLine();
        SimpleReader inputFile = new SimpleReader1L(dataFileName);
        //Ask user for output folder
        out.println("Please enter a name of the output folder");
        String outputFolderName = in.nextLine();
        SimpleWriter index = new SimpleWriter1L(outputFolderName
                + "/index.html");
        //Read the file and separate terms and definitions
        Map<String, String> termsAndDefs = new Map2<String, String>();
        readFile(inputFile, termsAndDefs);
        //Sort the terms alphabetically in the map
        sortTermsAlphabetically(termsAndDefs);
        //print index page
        printIndexPage(index, termsAndDefs);
        //Print each term's html page
        printTermPages(termsAndDefs, separatorSet);

        index.close();
        inputFile.close();
        in.close();
        out.close();
    }

}
