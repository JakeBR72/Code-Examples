import java.util.Comparator;

import components.queue.Queue;
import components.queue.Queue1L;
import components.sequence.Sequence;
import components.simplereader.SimpleReader;
import components.simplereader.SimpleReader1L;
import components.simplewriter.SimpleWriter;
import components.simplewriter.SimpleWriter1L;
import components.stack.Stack;
import components.stack.Stack2;
import components.xmltree.XMLTree;

public final class Test {
    private static class StringLT implements Comparator<String> {
        @Override
        public int compare(String o1, String o2) {
            return o1.compareTo(o2);
        }
    }

    private Test() {
    }

    public static void main(String[] args) {
        SimpleReader in = new SimpleReader1L();
        SimpleWriter out = new SimpleWriter1L();
        ///////////////////////////////////////////
        String str1 = "~~     He has abdicated government here, by declaring us out of~     h ";
        String str2 = "ted government here, by declaring ";

        out.println(str1.indexOf(str2));
        out.println(str2.indexOf(str1));

        ///////////////////////////////////////////
        in.close();
        out.close();
    }

    public static void flip(Stack<String> th) {
        Stack<String> tempStack = new Stack2<String>();
        int length = th.length();
        for (int i = 1; i <= length; i++) {
            tempStack.push(th.pop());
        }
        th.transferFrom(tempStack);
    }

    public static void flip(Sequence<String> th) {
        if (th.length() > 1) {
            Sequence<String> tempSequence = th.newInstance();
            String last = th.entry(th.length() - 1);
            String first = th.replaceEntry(0, last);
            th.replaceEntry(th.length() - 1, first);
            th.extract(1, th.length() - 1, tempSequence);
            flip(tempSequence);
            th.insert(1, tempSequence);
        }
    }

    private static String removeMin(Queue<String> q, Comparator<String> order) {
        String min = q.front();
        boolean done = false;
        for (String toTest : q) {
            if (order.compare(toTest, min) < 0) {
                min = toTest;
            }
        }
        while (!done) {
            String test = q.dequeue();
            if (test.equals(min)) {
                done = true;
            } else {
                q.enqueue(test);
            }
        }
        return min;
    }

    public static void sort(Queue<String> q, Comparator<String> order) {
        Queue<String> sorted = new Queue1L<String>();
        while (q.length() > 0) {
            sorted.enqueue(removeMin(q, order));
        }
        q.transferFrom(sorted);
    }

    private static void flip(Queue<Integer> q) {
        if (q.length() != 0) {
            int k = q.dequeue();
            System.out.println(k);
            flip(q);
            System.out.println(k);
            q.enqueue(k);
        }
    }

    private static int min(Queue<Integer> q) {
        int min = Integer.MAX_VALUE;
        int qLength = q.length();
        for (int i = 0; i < qLength; i++) {
            int number = q.dequeue();
            if (number < min) {
                min = number;
            }
            q.enqueue(number);
        }
        return min;
    }

    private static int[] minAndMax(Queue<Integer> q) {
        int min = Integer.MAX_VALUE;
        int max = Integer.MIN_VALUE;
        int qLength = q.length();
        for (int i = 0; i < qLength; i++) {
            int num1 = q.dequeue();
            int num2 = q.dequeue();
            if (num1 > num2) {
                if (num1 > max) {
                    max = num1;
                }
                if (num2 < min) {
                    min = num2;
                }
            } else {
                if (num2 > max) {
                    max = num2;
                }
                if (num1 < min) {
                    min = num1;
                }
            }
            q.enqueue(num1);
            q.enqueue(num2);
        }
        int[] minAndMax = { min, max };
        return minAndMax;
    }

    private static boolean findTag(XMLTree xml, String tag) {
        boolean returnValue = false;
        if (xml.isTag()) {
            for (int i = 0; i < xml.numberOfChildren(); i++) {
                if (xml.label().equals(tag)) {
                    returnValue = true;
                    i = xml.numberOfChildren();
                } else {
                    returnValue = findTag(xml.child(i), tag);
                    if (returnValue == true) {
                        i = xml.numberOfChildren();
                    }
                }
            }
        }
        return returnValue;
    }
}
