import components.naturalnumber.NaturalNumber;
import components.naturalnumber.NaturalNumber2;
import components.simplereader.SimpleReader;
import components.simplereader.SimpleReader1L;
import components.simplewriter.SimpleWriter;
import components.simplewriter.SimpleWriter1L;

public class randomCode {
    public static void main(String[] args) {
        SimpleReader in = new SimpleReader1L();
        SimpleWriter out = new SimpleWriter1L();
        //////////////////////////////////////////////

        String input = "TeStLoL";
        // String input = in.nextLine(); // HW 5 a->e
        String returnString = "";
        for (int i = 0; i < input.length(); i++) {
            if (Character.isUpperCase(input.charAt(i))) {
                returnString += input.charAt(i);
            }
        }
        out.println(returnString);
        returnString = "";
        for (int i = 0; i < input.length(); i++) {
            if (i % 2 > 0) {
                returnString += input.charAt(i);
            }
        }
        out.println(returnString);
        returnString = "";
        for (int i = 0; i < input.length(); i++) {
            if ("AEIOUaeiou".indexOf(input.charAt(i)) > 0) {
                returnString += '_';
            } else {
                returnString += input.charAt(i);
            }

        }
        out.println(returnString);
        int numVowels = 0;
        for (int i = 0; i < input.length(); i++) {
            if ("AEIOUaeiou".indexOf(input.charAt(i)) > 0) {
                out.print("[" + i + "] ");
            }
        } // end

        // finds min and max values from an array
        int[] a = { 1, 531, -5, 4, 5, 4, 6, 1, 23, 54 };
        int max = Integer.MIN_VALUE;
        int min = Integer.MAX_VALUE;
        for (int count = 0; count < a.length; count++) {
            if (a[count] > max) {
                max = a[count];
            } else if (a[count] < min) {
                min = a[count];
            }
        }
        out.println("[" + max + "] [" + min + "]");

        ////////////////////////////////////
        in.close();
        out.close();

    }

    private static int numberOfDigits(NaturalNumber n) {
        int digit = n.divideBy10();
        int numberOfDigits = 0;
        if (!n.isZero() || digit != 0) {
            numberOfDigits++;
            numberOfDigits += numberOfDigits(n);
            n.multiplyBy10(digit);
        }
        return numberOfDigits;
    }

    private static int sumOfDigits(NaturalNumber n) {
        int digit = n.divideBy10();
        int sumOfDigits = 0;
        if (!n.isZero() || digit != 0) {
            sumOfDigits += digit;
            sumOfDigits += sumOfDigits(n);
            n.multiplyBy10(digit);
        }
        return sumOfDigits;
    }

    private static NaturalNumber sumOfDigits2(NaturalNumber n) {
        NaturalNumber digit = new NaturalNumber2(n.divideBy10());
        NaturalNumber sumOfDigits = new NaturalNumber2();
        if (!n.isZero() || !digit.isZero()) {
            sumOfDigits.add(digit);
            sumOfDigits.add(sumOfDigits2(n));
            n.multiplyBy10(digit.toInt());
        }
        return sumOfDigits;
    }

    private static void divideBy2(NaturalNumber n) {
        int digit = n.divideBy10();
        if (!n.isZero() || digit != 0) {
            if (digit == 0) {
                digit = 5;
            } else {
                digit /= 2;
                int temp = n.divideBy10();
                if (temp == 1) {
                    digit += 5;
                    n.multiplyBy10(temp);
                    n.decrement();
                } else if (temp % 2 > 0 && temp != 1) {
                    digit += 5;
                    n.multiplyBy10(temp);
                } else {
                    n.multiplyBy10(temp);
                }
            }
            divideBy2(n);
            n.multiplyBy10(digit);
        }
    }

    private static boolean isPalindrome(String s) {
        boolean returnValue = true;
        if (returnValue == true && s.length() > 1) {
            if (s.charAt(0) == s.charAt(s.length() - 1)) {
                s = s.substring(1, s.length() - 1);
                returnValue = isPalindrome(s);
            } else {
                returnValue = false;
            }
        }
        return returnValue;
    }

}
