import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.util.Comparator;
import java.util.Deque;
import java.util.LinkedList;
import java.util.Map;
import java.util.TreeMap;

/**
 * Creates a html file that generates a Tag Cloud containing given amount of
 * words.
 *
 * @author Taha Topiwala
 * @author Jacob Ruth
 * @author Gautham Sivakumar
 *
 */

public final class TagCloud {
    /**
     * Minimum frequency of the words.
     */
    private static int minFrequency = 0;

    /**
     * Maximum frequency of the words.
     */
    private static int maxFrequency = 0;

    /**
     * Maximum font size for displaying.
     */
    public static final int MAX_FONT_SIZE = 48;

    /**
     * Minimum font size for displaying.
     */
    public static final int MIN_FONT_SIZE = 11;

    /**
     * Integer Comparator.
     */

    private static class MaxValueComparator implements Comparator<String> {
        /**
         *
         */
        Map<String, Integer> base;

        /**
         *
         */
        MaxValueComparator(Map<String, Integer> base) {
            this.base = base;
        }

        @Override
        public int compare(String one, String two) {
            int firstDig = this.base.get(one);
            int secondDig = this.base.get(two);
            if (secondDig > firstDig) {
                return 1;
            } else if (firstDig > secondDig) {
                return -1;
            } else {
                return two.compareTo(one);
            }
        }
    }

    /**
     * .
     */
    private TagCloud() {
    }

    /**
     * Seperators.
     */
    private static final String SEPERATORS = " \t\n\r =+-_)(*&^%$#@!/'\","
            + ".:;{}[]<>?|~`";

    /**
     *
     * Creates the header for the HTML output file.
     *
     * @param inputFile
     *            name of the input file
     *
     * @param outputFile
     *            name of the output file
     *
     * @param outputHTML
     *            output stream
     *
     * @param numberOfWords
     *            number of words the user wants to search through
     *
     */
    private static void createHeaderHTML(PrintWriter outputHTML,
            String inputFile, String outputFile, int numberOfWords) {

        outputHTML.println("<html>");
        outputHTML.println("<head>");
        outputHTML.print("<title>");
        outputHTML.print("Top " + numberOfWords + " words in " + inputFile);
        outputHTML.println("</title>");
        outputHTML.println("<link href=\"tagcloud.css\""
                + " rel=\"stylesheet\" type=\"text/css\">");
        outputHTML.println("</head>");
        outputHTML.println("<body>");
        outputHTML.println("<h2>Top " + numberOfWords + " words in " + inputFile
                + "</h2>");
        outputHTML.println("<hr>");
        outputHTML.println("<div class=\"cdiv\">");
        outputHTML.println("<p class=\"cbox\">");

    }

    /**
     * Creates the body of the HTML file.
     *
     * @param fontDeque
     *            Deque containing font sizes
     *
     * @param wordCount
     *            Alphabetized map containing words and their counts
     *
     * @param outputHTML
     *            Output stream
     */
    private static void createBodyHTML(Deque<Integer> fontDeque,
            Map<String, Integer> wordCount, PrintWriter outputHTML) {
        for (Map.Entry<String, Integer> entry : wordCount.entrySet()) {
            outputHTML.println("<span style=\"cursor:default;\" class=\"f"
                    + fontDeque.removeFirst() + "\" title=\"count: "
                    + entry.getValue() + "\">" + entry.getKey() + "</span>");
        }
    }

    /**
     * Creates the footer of the html document.
     *
     * @param outputHTML
     *            file output stream
     * @requires outputHTML is open
     *
     * @ensures completed html file footer
     *
     */
    private static void createFooterHTML(PrintWriter outputHTML) {

        outputHTML.println("</p>");
        outputHTML.println("</div>");
        outputHTML.println("</body>");
        outputHTML.println("</html>");
    }

    /**
     * Counts the number of times a word is used within the given text.
     *
     * @param in
     *            input stream
     *
     * @return map containing words and their counts
     *
     * @ensures {@code Returned map contains words and their counts provided
     * by input file}
     *
     */
    private static Map<String, Integer> createMapOfWords(BufferedReader in) {

        Map<String, Integer> countOfWords = new TreeMap<String, Integer>();
        String inPart = "";
        try {
            inPart = in.readLine();
        } catch (IOException e) {
            System.err.println("Error reading input file: " + e);
            return countOfWords;
        }
        int location = 0, counter;
        try {
            while (inPart != null) {
                while (location < inPart.length()) {
                    String word = nextWordOrSeparator(inPart, location,
                            SEPERATORS);
                    if (!SEPERATORS
                            .contains(Character.toString(word.charAt(0)))) {
                        if (!countOfWords.containsKey(word)) {
                            countOfWords.put(word, 1);
                        } else {
                            counter = countOfWords.get(word);
                            counter++;
                            countOfWords.remove(word);
                            countOfWords.put(word, counter);
                        }
                    }
                    location += word.length();
                }
                location = 0;
                inPart = in.readLine();
            }
        } catch (IOException e) {
            System.err
                    .println("Error reading line from file input stream: " + e);
            return countOfWords;
        }
        return countOfWords;
    }

    /**
     * Returns the first "word" (maximal length string of characters not in
     * {@code SEPARATORS}) or "separator string" (maximal length string of
     * characters in {@code SEPARATORS}) in the given {@code text} starting at
     * the given {@code position}.
     *
     * @param text
     *            the {@code String} from which to get the word or separator
     *            string
     * @param position
     *            the starting index
     * @return the first word or separator string found in {@code text} starting
     *         at index {@code position}
     * @requires 0 <= position < |text|
     * @ensures
     *
     *          <pre>
     * nextWordOrSeparator =
     *   text[position, position + |nextWordOrSeparator|)  and
     * if entries(text[position, position + 1)) intersection entries(SEPARATORS) = {}
     * then
     *   entries(nextWordOrSeparator) intersection entries(SEPARATORS) = {}  and
     *   (position + |nextWordOrSeparator| = |text|  or
     *    entries(text[position, position + |nextWordOrSeparator| + 1))
     *      intersection entries(SEPARATORS) /= {})
     * else
     *   entries(nextWordOrSeparator) is subset of entries(SEPARATORS)  and
     *   (position + |nextWordOrSeparator| = |text|  or
     *    entries(text[position, position + |nextWordOrSeparator| + 1))
     *      is not subset of entries(SEPARATORS))
     *          </pre>
     */
    private static String nextWordOrSeparator(String text, int position,
            String separators) {
        assert text != null : "Violation of: text is not null";
        assert separators != null : "Violation of: separators is not null";
        assert 0 <= position : "Violation of: 0 <= position";
        assert position < text.length() : "Violation of: position < |text|";

        String ans = "";
        int i = position;
        if (!separators.contains(Character.toString(text.charAt(position)))) {
            while (i < text.length() && !separators
                    .contains(Character.toString(text.charAt(i)))) {
                i++;
            }
            ans = text.substring(position, i);
        } else {
            while (i < text.length() && separators
                    .contains(Character.toString(text.charAt(i)))) {
                i++;
            }
            ans = text.substring(position, i);
        }
        return ans.toLowerCase();
    }

    /**
     *
     * Sorts the top n words in alphabetical order and creates a deque
     * containing the font sizes for each word.
     *
     * @param wordCount
     *            map that contains the words and their respective count values
     *
     * @param numberOfWords
     *            The value that the user input at the beginning for how many
     *            words to look through from top
     * @return wordFontDeque A deque containing the font sizes for the sorted
     *         word map
     *
     */
    private static Deque<Integer> getFontDeque(Map<String, Integer> wordCount,
            int numberOfWords) {

        TreeMap<String, Integer> comp = new TreeMap<String, Integer>(wordCount);
        MaxValueComparator maxComp = new MaxValueComparator(comp);
        Deque<Integer> wordFontDeque = new LinkedList<Integer>();
        TreeMap<String, Integer> sortedMapByValue = new TreeMap<String, Integer>(
                maxComp);

        sortedMapByValue.putAll(wordCount);
        wordCount.clear();

        for (int i = 0; i < numberOfWords && !sortedMapByValue.isEmpty(); i++) {
            if (maxFrequency == 0) {
                maxFrequency = sortedMapByValue.firstEntry().getValue();
            }
            if (i == numberOfWords - 1) {
                minFrequency = sortedMapByValue.firstEntry().getValue();
            }
            wordCount.put(sortedMapByValue.firstEntry().getKey(),
                    sortedMapByValue.firstEntry().getValue());
            sortedMapByValue.remove(sortedMapByValue.firstKey());
        }
        for (Map.Entry<String, Integer> entry : wordCount.entrySet()) {
            wordFontDeque.add(calculateFontSize(entry.getValue()));
        }
        return wordFontDeque;
    }

    /**
     * Calculate the font size given a count.
     *
     * @param count
     *            the frequency of the word
     * @return the font size for the word of {@code frequency}.
     */
    private static int calculateFontSize(int count) {
        if (count == minFrequency) {
            return MIN_FONT_SIZE;
        } else if (count == maxFrequency) {
            return MAX_FONT_SIZE;
        } else {
            return (int) ((MAX_FONT_SIZE - MIN_FONT_SIZE)
                    * (count - minFrequency)
                    / (double) (maxFrequency - minFrequency)) + MIN_FONT_SIZE;

        }
    }

    /**
     * Main method.
     *
     * @param args
     */
    public static void main(String[] args) {

        BufferedReader inputFile = null;
        PrintWriter outputHTML = null;
        BufferedReader in = new BufferedReader(
                new InputStreamReader(System.in));

        //Ask for input file name
        System.out.print("Enter a valid input file: ");
        String directory = "";
        try {
            directory = in.readLine();
        } catch (IOException out) {
            System.err.println("Error with creating input stream : " + out);
            return;
        }

        try {
            inputFile = new BufferedReader(new FileReader(directory));
        } catch (IOException out) {
            System.err.println(
                    "Error with opening input stream from file: " + out);
            return;
        }
        System.out.println();
        //Ask for output file name
        String outputFileName = "";
        System.out.print("Enter a valid output file: ");
        try {
            outputFileName = in.readLine();
        } catch (IOException out) {
            System.err.println("Error with creating input stream: " + out);
            return;
        }
        try {
            outputHTML = new PrintWriter(
                    new BufferedWriter(new FileWriter(outputFileName)));
        } catch (IOException out) {
            System.err.println("Error creating output stream to file: " + out);
            return;
        }
        System.out.println();

        int numberOfWords = 0;
        System.out.print("Number of words to generate: ");
        try {
            numberOfWords = Integer.parseInt(in.readLine());
        } catch (NumberFormatException out) {
            System.err.println("Error with int value " + out);
        } catch (IOException out) {
            System.err.println("Error with input: " + out);
            return;
        }

        createHeaderHTML(outputHTML, directory, outputFileName, numberOfWords);

        Map<String, Integer> wordCountInText = createMapOfWords(inputFile);

        Deque<Integer> fontDeque = getFontDeque(wordCountInText, numberOfWords);
        createBodyHTML(fontDeque, wordCountInText, outputHTML);

        createFooterHTML(outputHTML);

        try {
            in.close();
            inputFile.close();
            System.out.close();
            outputHTML.close();
        } catch (IOException out) {
            System.err.println("Error closing streams: " + out);
            return;
        }
    }

}