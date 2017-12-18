import components.sequence.Sequence;

/**
 * Implements method to smooth a {@code Sequence<Integer>}.
 *
 * @author Jacob Ruth
 *
 */
public final class SequenceSmooth {

    /**
     * Private constructor so this utility class cannot be instantiated.
     */
    private SequenceSmooth() {
    }

    /**
     * Smooths a given {@code Sequence<Integer>}.
     *
     * @param s1
     *            the sequence to smooth
     * @param s2
     *            the resulting sequence
     * @replaces s2
     * @requires |s1| >= 1
     * @ensures
     *
     *          <pre>
     * |s2| = |s1| - 1  and
     *  for all i, j: integer, a, b: string of integer
     *      where (s1 = a * <i> * <j> * b)
     *    (there exists c, d: string of integer
     *       (|c| = |a|  and
     *        s2 = c * <(i+j)/2> * d))
     *          </pre>
     */
    public static void smooth(Sequence<Integer> s1, Sequence<Integer> s2) {
        assert s1 != null : "Violation of: s1 is not null";
        assert s2 != null : "Violation of: s2 is not null";
        assert s1.length() >= 1 : "|s1| >= 1";
        //Recursive Solution
//        s2.clear();
//        int i = s1.remove(0);
//        if (s1.length() >= 1) {
//            int j = s1.remove(0);
//            s1.add(0, j);
//            smooth(s1, s2);
//            if (i == j) {
//                s2.add(0, i);
//            } else {
//                s2.add(0, (i + j) / 2);
//            }
//            s1.add(0, i);
//        } else {
//            s1.add(0, i);
//        }
        // Non-Recursive Solution
        s2.clear();
        int i = 0;
        int j = 0;
        int length = s1.length();
        int count = 0;
        while (count < (length - 1)) {
            i = s1.remove(count);
            if (count < (length - 1)) {
                j = s1.remove(count);
            } else {
                j = 0;
            }

            int average = 0;
            if (i == j) {
                average = i;
            } else if (i >= 0 && j >= 0) {
                if ((Integer.MAX_VALUE - i) < j
                        || (Integer.MAX_VALUE - j) < i) {
                    average = (i / 2 + j / 2);
                } else {
                    average = (i + j) / 2;
                }
            } else if (i < 0 && j < 0) {
                if ((Integer.MIN_VALUE - i) > j
                        || (Integer.MIN_VALUE - j) > i) {
                    average = -(i / 2 + j / 2);
                } else {
                    average = (i + j) / 2;
                }
            } else {
                average = (i + j) / 2;
            }

            s2.add(count, average);
            s1.add(count, i);
            s1.add(count + 1, j);
            count++;
        }
    }

}
