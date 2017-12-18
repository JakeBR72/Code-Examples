import java.util.Comparator;
import java.util.Set;

import components.binarytree.BinaryTree;
import components.binarytree.BinaryTree1;
import components.map.Map;
import components.map.Map.Pair;
import components.naturalnumber.NaturalNumber;
import components.naturalnumber.NaturalNumber2;
import components.program.Program;
import components.queue.Queue;
import components.queue.Queue1L;
import components.sequence.Sequence;
import components.sequence.Sequence1L;
import components.simplereader.SimpleReader;
import components.simplereader.SimpleReader1L;
import components.simplewriter.SimpleWriter;
import components.simplewriter.SimpleWriter1L;
import components.stack.Stack;
import components.statement.Statement;
import components.statement.StatementKernel.Condition;
import components.tree.Tree;

/**
 * Homework.
 *
 * @author Jacob Ruth
 *
 */
public final class Homework {
    /**
     * Compare {@code String}s in lexicographic order.
     */
    private static class StringLT implements Comparator<String> {
        @Override
        public int compare(String o1, String o2) {
            return o1.compareTo(o2);
        }
    }

    /**
     * Private constructor so this utility class cannot be instantiated.
     */
    private Homework() {
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
        //////////////////////////////////////////

        //////////////////////////////////////////
        in.close();
        out.close();
    }

    private static void giveRaise(components.map.Map<String, Integer> map,
            char initial, int raisePercent) {
        Map<String, Integer> newMap = map.newInstance();
        while (map.size() > 1) {
            Pair<String, Integer> pair = map.removeAny();
            if (pair.key().startsWith("" + initial)) {
                newMap.add(pair.key(),
                        pair.value() + pair.value() * raisePercent);
            } else {
                newMap.add(pair.key(), pair.value());
            }
        }
        map.transferFrom(newMap);
    }

    private static void giveRaise(java.util.Map<String, Integer> map,
            char initial, int raisePercent) {
        Set<String> keySet = map.keySet();
        for (String key : keySet) {
            if (key.startsWith("" + initial)) {
                Integer value = map.remove(key);
                map.put(key, value + value * raisePercent);
            }
        }
    }

    private static final String SEPARATORS = " \t\n\r";

    private static String nextWordOrSeparator(String text, int position) {
        String returnString = "";
        int i = position;
        String test = "\t\n\r";
        if (SEPARATORS.indexOf(text.charAt(position)) == -1) {
            while (i < text.length()
                    && SEPARATORS.indexOf(text.charAt(i)) == -1) {
                i++;
            }
            returnString = text.substring(position, i);
        } else {
            while (i < text.length()
                    && SEPARATORS.indexOf(text.charAt(i)) != -1) {
                i++;
            }
            returnString = text.substring(position, i);
        }
        return returnString;
    }

    public static Queue<String> tokens(SimpleReader in) {
        Queue<String> tokens = new Queue1L<String>();
        String nextLine = in.nextLine();
        int position = 0;
        while (position < nextLine.length()) {
            String token = nextWordOrSeparator(nextLine, position);
            if (!SEPARATORS.contains(token)) {
                tokens.enqueue(token);
            }
            position += token.length();
        }
        return tokens;
    }

    public static void renameInstruction(Statement s, String oldName,
            String newName) {
        switch (s.kind()) {
            case BLOCK: {
                for (int i = 0; i < s.lengthOfBlock(); i++) {
                    Statement child = s.newInstance();
                    child = s.removeFromBlock(i);
                    renameInstruction(child, oldName, newName);
                    s.addToBlock(i, child);
                }
                break;
            }
            case IF: {
                Statement block = s.newInstance();
                Condition condition = s.disassembleIf(block);
                renameInstruction(block, oldName, newName);
                s.assembleIf(condition, block);
                break;
            }
            case IF_ELSE: {
                Statement blockLeft = s.newInstance();
                Statement blockRight = s.newInstance();
                Condition condition = s.disassembleIfElse(blockLeft,
                        blockRight);
                renameInstruction(blockLeft, oldName, newName);
                renameInstruction(blockRight, oldName, newName);
                s.assembleIfElse(condition, blockLeft, blockRight);
                break;
            }
            case WHILE: {
                Statement block = s.newInstance();
                Condition condition = s.disassembleWhile(block);
                renameInstruction(block, oldName, newName);
                s.assembleWhile(condition, block);
                break;
            }
            case CALL: {
                String call = s.disassembleCall();
                if (call.equals(oldName)) {
                    call = newName;
                }
                s.assembleCall(call);
                break;
            }
            default: {
                break;
            }
        }

    }

    public static void renameInstruction(Program p, String oldName,
            String newName) {

        Map<String, Statement> tempContext = p.newContext();
        Map<String, Statement> context = p.replaceContext(tempContext);

        Statement tempBody = p.newBody();
        Statement body = p.replaceBody(tempBody);

        renameInstruction(body, oldName, newName);

        while (context.size() > 0) {
            Pair<String, Statement> pair = context.removeAny();
            Statement newStatement = pair.value();
            renameInstruction(newStatement, oldName, newName);
            if (pair.key().equals(oldName)) {
                tempContext.add(newName, newStatement);
            } else {
                tempContext.add(pair.key(), newStatement);
            }
        }
        p.replaceContext(tempContext);
        p.replaceBody(body);
    }

    public static int countOfPrimitiveCalls(Statement s) {
        int count = 0;
        switch (s.kind()) {
            case BLOCK: {
                for (int i = 0; i < s.lengthOfBlock(); i++) {
                    Statement child = s.newInstance();
                    child = s.removeFromBlock(i);
                    count += countOfPrimitiveCalls(child);
                    s.addToBlock(i, child);
                }
                break;
            }
            case IF: {
                Statement block = s.newInstance();
                Condition condition = s.disassembleIf(block);
                count += countOfPrimitiveCalls(block);
                s.assembleIf(condition, block);
                break;
            }
            case IF_ELSE: {
                Statement blockLeft = s.newInstance();
                Statement blockRight = s.newInstance();
                Condition condition = s.disassembleIfElse(blockLeft,
                        blockRight);
                count += (countOfPrimitiveCalls(blockLeft)
                        + countOfPrimitiveCalls(blockRight));
                s.assembleIfElse(condition, blockLeft, blockRight);
                break;
            }
            case WHILE: {
                Statement block = s.newInstance();
                Condition condition = s.disassembleWhile(block);
                count += countOfPrimitiveCalls(block);
                s.assembleWhile(condition, block);
                break;
            }
            case CALL: {
                String call = s.disassembleCall();
                switch (call) {
                    case "move": {
                        count++;
                        break;
                    }
                    case "turnleft": {
                        count++;
                        break;
                    }
                    case "turnright": {
                        count++;
                        break;
                    }
                    case "infect": {
                        count++;
                        break;
                    }
                    case "skip": {
                        count++;
                        break;
                    }
                    default: {
                        break;
                    }

                }
                s.assembleCall(call);
                break;
            }
            default: {
                // this will never happen...can you explain why?
                break;
            }
        }
        return count;
    }

    public static <T> int size(Tree<T> t) {
//        int size = 0;
//        if (t.height() > 0) {
//            Sequence<Tree<T>> children = t.newSequenceOfTree();
//            T root = t.disassemble(children);
//            size++;
//            for (Tree<T> child : children) {
//                size += size(child);
//            }
//            t.assemble(root, children);
//        }
//        return size;
        int size = 0;
        for (T root : t) {
            size++;
        }
        return size;
    }

    public static <T> int height(Tree<T> t) {
        int height = 0;
        if (t.size() > 0) {
            Sequence<Tree<T>> children = t.newSequenceOfTree();
            T root = t.disassemble(children);
            height++;
            int largestChild = 0;
            for (Tree<T> child : children) {
                int returnedHeight = height(child);
                if (returnedHeight > largestChild) {
                    largestChild = returnedHeight;
                }
            }
            t.assemble(root, children);
        }
        return height;
    }

    public static int max(Tree<Integer> t) {
        int max = 0;
        if (t.height() > 0) {
            Sequence<Tree<Integer>> children = t.newSequenceOfTree();
            int root = t.disassemble(children);
            max = root;
            for (Tree<Integer> child : children) {
                int returnedMax = max(child);
                if (returnedMax > max) {
                    max = returnedMax;
                }
            }
            t.assemble(root, children);
        }
        return max;
    }

    public static void sort(Queue<String> q, Comparator<String> order) {
        if (q.length() > 1) {
            String partitioner = q.dequeue();
            Queue<String> front = q.newInstance();
            Queue<String> back = q.newInstance();
            partition(q, partitioner, front, back, order);
            front.sort(order);
            back.sort(order);
            q.append(front);
            q.enqueue(partitioner);
            q.append(back);
        }
    }

    private static <T> void partition(Queue<String> q, String partitioner,
            Queue<String> front, Queue<String> back, Comparator<String> order) {
        front.clear();
        back.clear();
        if (q.length() > 0) {
            String removed = q.dequeue();
            partition(q, partitioner, front, back, order);
            if (order.compare(removed, partitioner) <= 0) {
                front.enqueue(removed);
            } else {
                back.enqueue(removed);
            }
        }
    }

    public static void test(NaturalNumber a, NaturalNumber b) {
        b.multiplyBy10(5);
        a = new NaturalNumber2(12);
    }

    public static <T extends Comparable<T>> boolean isInTree(BinaryTree<T> t,
            T x) {
        boolean isInTree = false;
        if (t.height() > 0) {
            BinaryTree<T> left = t.newInstance();
            BinaryTree<T> right = t.newInstance();
            T root = t.disassemble(left, right);
            if (root.compareTo(x) == 0) {
                isInTree = true;
            } else if (root.compareTo(x) < 0) {
                isInTree = isInTree(left, x);
            } else {
                isInTree = isInTree(right, x);
            }
        }
        return isInTree;
    }

    private static <T> void insertInOrder(Queue<T> q, T x,
            Comparator<T> order) {
        Queue<T> tempQueue = q.newInstance();
        while (q.length() > 0) {
            T front = q.dequeue();
            if (order.compare(front, x) > 0) {
                tempQueue.enqueue(x);
            }
            tempQueue.enqueue(front);
        }
    }
//
//    public void sort(Comparator<T> order) {
//        Queue<T> sort = this.newInstance();
//        while (this.length() > 0) {
//            insertInOrder(sort, this.dequeue(), order);
//        }
//        this.transferFrom(sort);
//    }

    public static BinaryTree<String> copy(BinaryTree<String> t) {
        BinaryTree<String> copy = new BinaryTree1<String>();
        if (t.height() > 0) {
            BinaryTree<String> left = t.newInstance();
            BinaryTree<String> right = t.newInstance();
            String root = t.disassemble(left, right);
            String rootCopy = root;
            copy.assemble(rootCopy, copy(left), copy(right));
            t.assemble(root, left, right);
        }
        return copy;
    }

    public static <T> String treeToString(BinaryTree<T> t) {
        String treeToString = "";
        if (t.height() > 0) {
            BinaryTree<T> left = t.newInstance();
            BinaryTree<T> right = t.newInstance();
            T root = t.disassemble(left, right);

            treeToString += "(" + root;
            if (left.equals(t.newInstance())) {
                treeToString += "()";
            } else {
                treeToString += treeToString(left);
            }
            if (right.equals(t.newInstance())) {
                treeToString += "())";
            } else {
                treeToString += treeToString(right) + ")";
            }

            t.assemble(root, left, right);
        }
        return treeToString;
    }

    public static <T> int size(BinaryTree<T> t) {
        int size = 0;
        if (t.height() > 0) {
            size++;
            BinaryTree<T> left = t.newInstance();
            BinaryTree<T> right = t.newInstance();
            T root = t.disassemble(left, right);
            size += (size(left) + size(right));
            t.assemble(root, left, right);
        }
        return size;
    }

    public static <T> int sizeIt(BinaryTree<T> t) {
        int size = 0;
        for (T root : t) {
            size++;
        }
        return size;
    }

    private static int mod(int a, int b) {
        int mod = 0;
        if (a < 0) {
            mod += b + (a % b);
        } else {
            mod = a % b;
        }
        return mod;
    }

    private static <K, V> void moveToFront(Queue<K> q, K key) {
        for (int i = 0; !q.front().equals(key) && i < q.length(); i++, q
                .enqueue(q.dequeue())) {
        }
//        int count = 0;
//        while (q.front().key().equals(key) && count < q.length()) {
//            q.enqueue(q.dequeue());
//            count++;
//        }
    }

//    private static <T> void moveToFront(Queue<T> q, T x) {
//        T element = q.front();
//        int count = 0;
//        while (!element.equals(x) && count < q.length()) {
//            q.enqueue(q.dequeue());
//            element = q.front();
//            count++;
//        }
//    }

    private static int divideBy10(String rep) {

        String end = "";
        int toReturn = 0;

        if (!rep.equals("")) {
            end = rep.substring(rep.length() - 1);
            rep = rep.substring(0, rep.length() - 1);
            toReturn = Integer.parseInt(end);
        }
        System.out.println(rep);
        return toReturn;

    }

    private static void multiplyBy10(int k, String rep) {
        if (rep.length() >= 1) {
            rep += k;
        } else if (k > 0) {
            rep = Integer.toString(k);
        }
    }

    /**
     *  * Shifts entries between {@code leftStack} and {@code rightStack},
     * keeping  * reverse of the former concatenated with the latter fixed, and
     * resulting  * in length of the former equal to {@code newLeftLength}.  *
     *  * @param <T>  *            type of {@code Stack} entries  * @param
     * leftStack  *            the left {@code Stack}  * @param rightStack
     *  *            the right {@code Stack}  * @param newLeftLength
     *  *            desired new length of {@code leftStack}  * @updates
     * leftStack, rightStack  * @requires
     *
     * <pre>
      * 0 <= newLeftLength  and
      * newLeftLength <= |leftStack| + |rightStack|
      *
     * </pre>
     *
     *  * @ensures
     *
     * <pre>
      * rev(leftStack) * rightStack = rev(#leftStack) * #rightStack  and
      * |leftStack| = newLeftLength}
      *
     * </pre>
     *
     *  
     */
    private static <T> void setLengthOfLeftStack(Stack<T> leftStack,
            Stack<T> rightStack, int newLeftLength) {
        while (leftStack.length() != newLeftLength) {
            if (leftStack.length() > newLeftLength) {
                leftStack.flip();
                rightStack.push(leftStack.pop());
                leftStack.flip();
            } else {
                leftStack.flip();
                leftStack.push(rightStack.pop());
                leftStack.flip();
            }
        }
    }

    /**
     * Returns the integer average of two given {@code int}s.
     *
     * @param i
     *            the first of two integers to average
     * @param j
     *            the second of two integers to average
     * @return the integer average of j and k  
     * @ensures average = (j+k)/2  
     */
    public static int average(int i, int j) {
        int average = 0;
        if (i == j) {
            average = i;
        } else if (i >= 0 && j >= 0) {
            if ((Integer.MAX_VALUE - i) < j || (Integer.MAX_VALUE - j) < i) {
                average = (i / 2 + j / 2);
            } else {
                average = (i + j) / 2;
            }
        } else if (i < 0 && j < 0) {
            if ((Integer.MIN_VALUE - i) > j || (Integer.MIN_VALUE - j) > i) {
                average = -(i / 2 + j / 2);
            } else {
                average = (i + j) / 2;
            }
        } else {
            average = (i + j) / 2;
        }
        return average;
    }

    /**
     *  * Smooths a given {@code Sequence<Integer>}.  *  * @param s1
     *  *            the sequence to smooth  * @requires |s1| >= 1
     *
     * @return A sequence containing the smoothed result from s1  * @ensures
     *
     *         <pre>
      * |smooth| = |s1| - 1  and
      *  for all i, j: integer, a, b: string of integer
      *      where (s1 = a * <i> * <j> * b)
      *    (there exists c, d: string of integer
      *       (|c| = |a|  and
      *        smooth = c * <(i+j)/2> * d))
      *
     *         </pre>
     *
     *          
     */
    public static Sequence<Integer> smooth(Sequence<Integer> s1) {
        Sequence<Integer> smoothedSequence = new Sequence1L<Integer>();
        //Iterative Solution
        int i = 0;
        int j = 0;
        int length = s1.length();
        int count = 0;
        while (count < (length - 1)) {
            i = s1.remove(count);
            if (count < (length - 1)) {
                j = s1.remove(count);
            }
            if (i == j) {
                smoothedSequence.add(count, i);
            } else {
                smoothedSequence.add(count, (i + j) / 2);
            }
            s1.add(count, i);
            s1.add(count + 1, j);
            count++;
        }
        return smoothedSequence;
    }
}
