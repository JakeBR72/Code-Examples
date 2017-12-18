import java.io.Serializable;
import java.util.Comparator;

import components.map.Map;
import components.map.Map1L;
import components.queue.Queue;
import components.queue.Queue2;
import components.set.Set;
import components.set.Set1L;
import components.simplereader.SimpleReader;
import components.simplereader.SimpleReader1L;
import components.simplewriter.SimpleWriter;
import components.simplewriter.SimpleWriter1L;

/**
 * Finds and counts all words used within a given txt file then produces an html
 * page that lists the words in alphabetical order and how many times they were
 * used within the text.
 *
 * @author Jacob Ruth
 *
 *
 */
public final class WordCounter {
    /**
     * Compare {@code String}s in lexicographic order.
     */
    private static class StringLT implements Comparator<String>, Serializable {
        /**
         *
         */
        private static final long serialVersionUID = 1L;

        @Override
        public int compare(String first, String second) {
            return first.compareToIgnoreCase(second);
        }
    }

    /**
     * Default constructor--private to prevent instantiation.
     */
    private WordCounter() {

    }

    /**
     * Prints the header of an HTML document.
     *
     * @param html
     *            The SimpleWriter to print to
     * @param title
     *            The String to set the page to
     * @requires html is open, title is not null
     *
     */
    public static void printHeader(SimpleWriter html, String title) {
        html.println("<html>");
        html.println("<head>");
        html.println("<title> Words Counted in " + title + "</title>");
        html.println("</head>");
        html.println("<body>");
        html.println("<h2>Words Counted in " + title + "</h2>");
        html.println("<hr />");
    }

    /**
     * Prints the words and counts to the HTML document.
     *
     * @param html
     *            The SimpleWriter to print to
     * @param map
     *            The map of all words and counts
     * @param list
     *            The queue containing the sorted keys from map
     * @requires html is open, |map.keys| = list
     *
     */
    public static void printWordsAndCounts(SimpleWriter html,
            Map<String, Integer> map, Queue<String> list) {
        html.println("<table border=\"1\">");
        html.println("<tr>");
        html.println("<th>Words</th>");
        html.println("<th>Counts</th>");
        html.println("</tr>");
        for (String word : list) {
            html.println("<tr>");
            html.println("<td>" + word + "</td>");
            html.println("<td>" + map.value(word) + "</td>");
            html.println("</tr>");
        }
        html.println("</table>");
    }

    /**
     * Prints the closing tags of an HTML document.
     *
     * @param html
     *            The SimpleWriter to print to
     * @requires html is open
     *
     */
    public static void printFooter(SimpleWriter html) {
        html.println("</body>");
        html.println("</html>");
    }

    /**
     * Reads the file in and puts all terms and definitions into a map.
     *
     * @param txt
     *            The SimpleReader to read from.
     * @param wordMap
     *            The Map of words and how many times they occured
     * @param separatorSet
     *            The Set of characters containing all text separators
     * @requires txt is open
     * @ensures File will be read and all words will be added to the word map
     * @updates wordMap
     */
    public static void readFile(SimpleReader txt, Map<String, Integer> wordMap,
            Set<Character> separatorSet) {
        while (!txt.atEOS()) {
            String nextLine = txt.nextLine();
            int index = 0;
            int position = 0;
            String word;
            while (index < nextLine.length()) {
                if (!separatorSet.contains(nextLine.charAt(index))) {
                    while (index < nextLine.length()
                            && !separatorSet.contains(nextLine.charAt(index))) {
                        index++;
                    }
                    word = nextLine.substring(position, index);
                    if (wordMap.hasKey(word)) {
                        int tempCount = wordMap.value(word);
                        tempCount++;
                        wordMap.replaceValue(word, tempCount);
                    } else {
                        wordMap.add(word, 1);
                    }
                    position = index;
                } else {
                    while (index < nextLine.length()
                            && separatorSet.contains(nextLine.charAt(index))) {
                        index++;
                        position = index;
                    }
                }
            }
        }
    }

    /**
     * Sorts the given map in to a queue alphabetically.
     *
     * @param wordMap
     *            The map of words *
     * @requires wordMap.size() > 0
     * @return A sorted Queue containing all words in wordMap
     * @ensures sortWords.content = [wordMap.keys sorted alphabetically]
     *
     */
    public static Queue<String> sortWords(Map<String, Integer> wordMap) {
        Queue<String> sortWords = new Queue2<String>();
        for (Map.Pair<String, Integer> term : wordMap) {
            sortWords.enqueue(term.key());
        }
        Comparator<String> order = new StringLT();
        sortWords.sort(order);
        return sortWords;
    }

    /**
     * Generates a Set of separators from a given String.
     *
     * @param str
     *            The string of separators
     * @param strSet
     *            The set of characters
     * @replaces strSet
     * @ensures strSet = entries(str)
     */
    public static void generateSeparatorSet(String str, Set<Character> strSet) {
        strSet.clear();
        char[] strCharArr = str.toCharArray();
        for (int i = 0; i < strCharArr.length; i++) {
            if (!strSet.contains(strCharArr[i])) {
                strSet.add(strCharArr[i]);
            }
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

        out.println("Please enter the name of the file to proces: ");
        SimpleReader txt = new SimpleReader1L(in.nextLine());
        out.println("Please enter then name of the ouput file: ");
        SimpleWriter html = new SimpleWriter1L(in.nextLine());

        final String separatorStr = " \t, .-";
        Set<Character> separatorSet = new Set1L<>();
        generateSeparatorSet(separatorStr, separatorSet);

        Map<String, Integer> wordMap = new Map1L<String, Integer>();
        readFile(txt, wordMap, separatorSet);
        Queue<String> sortedList = new Queue2<String>();
        sortedList.transferFrom(sortWords(wordMap));

        printHeader(html, txt.name());
        printWordsAndCounts(html, wordMap, sortedList);
        printFooter(html);

        in.close();
        out.close();
        txt.close();
        html.close();
    }

}
