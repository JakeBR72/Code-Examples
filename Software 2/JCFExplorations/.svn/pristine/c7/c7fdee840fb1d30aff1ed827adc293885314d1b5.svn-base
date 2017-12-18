import java.util.Iterator;
import java.util.Map.Entry;

import components.map.Map;
import components.map.Map1L;
import components.naturalnumber.NaturalNumber;
import components.naturalnumber.NaturalNumber1L;
import components.set.Set;
import components.set.Set1L;

/**
 * Simple class to experiment with the Java Collections Framework and how it
 * compares with the OSU CSE collection components.
 *
 * @author Put your name here
 *
 */
public final class JCFExplorations {

    /**
     * Private constructor so this utility class cannot be instantiated.
     */
    private JCFExplorations() {
    }

    /**
     * Raises the salary of all the employees in {@code map} whose name starts
     * with the given {@code initial} by the given {@code raisePercent}.
     *
     * @param map
     *            the name to salary map
     * @param initial
     *            the initial of names of employees to be given a raise
     * @param raisePercent
     *            the raise to be given as a percentage of the current salary
     * @updates map
     * @requires [the salaries in map are positive] and raisePercent > 0
     * @ensures
     *
     *          <pre>
     * DOMAIN(map) = DOMAIN(#map)  and
     * [the salaries of the employees in map whose names start with the given
     *  initial have been increased by raisePercent percent (and truncated to
     *  the nearest integer); all other employees have the same salary]
     *          </pre>
     */
    public static void giveRaise(components.map.Map<String, Integer> map,
            char initial, int raisePercent) {
        assert map != null : "Violation of: map is not null";
        assert raisePercent > 0 : "Violation of: raisePercent > 0";

        // TODO - fill in body

        Map<String, Integer> duplicate = new Map1L<String, Integer>();

        while (map.size() > 0) {
            Map.Pair<String, Integer> element = map.removeAny();
            if (element.key().charAt(0) == initial) {
                String key = element.key();
                int value = element.value();
                double calculatedValue = (value * (raisePercent / 100.0))
                        + value;
                int calculatedValueInt = (int) calculatedValue;
                duplicate.add(key, calculatedValueInt);
            } else {
                String key = element.key();
                int value = element.value();
                duplicate.add(key, value);
            }
        }
        while (duplicate.size() > 0) {
            Map.Pair<String, Integer> element = duplicate.removeAny();
            String key = element.key();
            int value = element.value();
            map.add(key, value);
        }
    }

    /**
     * Raises the salary of all the employees in {@code map} whose name starts
     * with the given {@code initial} by the given {@code raisePercent}.
     *
     * @param map
     *            the name to salary map
     * @param initial
     *            the initial of names of employees to be given a raise
     * @param raisePercent
     *            the raise to be given as a percentage of the current salary
     * @updates map
     * @requires [the salaries in map are positive] and raisePercent > 0
     * @ensures
     *
     *          <pre>
     * DOMAIN(map) = DOMAIN(#map)  and
     * [the salaries of the employees in map whose names start with the given
     *  initial have been increased by raisePercent percent (and truncated to
     *  the nearest integer); all other employees have the same salary]
     *          </pre>
     */
    public static void giveRaise(java.util.Map<String, Integer> map,
            char initial, int raisePercent) {
        assert map != null : "Violation of: map is not null";
        assert raisePercent > 0 : "Violation of: raisePercent > 0";

        // TODO - fill in body
        for (Entry<String, Integer> entry : map.entrySet()) {
            String key = entry.getKey();
            Object value = entry.getValue();
            int castedValue = (int) value;
            if (key.charAt(0) == initial) {
                double calculatedValue = (castedValue * (raisePercent / 100.0))
                        + castedValue;
                int calculatedValueInt = (int) calculatedValue;
                map.put(key, calculatedValueInt);
            }
        }
    }

    /**
     * Increments by 1 every element in the given {@code Set}.
     *
     * @param set
     *            the set whose elements to increment
     * @updates set
     * @ensures
     *
     *          <pre>
     * DOMAIN(map) = DOMAIN(#map)  and
     * [set is the set of integers that are elements of #set incremented by 1]
     *          </pre>
     */
    public static void incrementAll(components.set.Set<NaturalNumber> set) {
        assert set != null : "Violation of: set is not null";

        // TODO - fill in body

        Set<NaturalNumber> duplicate = new Set1L<NaturalNumber>();
        NaturalNumber one = new NaturalNumber1L(1);
        while (set.size() > 0) {
            NaturalNumber element = set.removeAny();
            element.add(one);
            duplicate.add(element);
        }

        while (duplicate.size() > 0) {
            NaturalNumber element = duplicate.removeAny();
            set.add(element);
        }

    }

    /**
     * Increments by 1 every element in the given {@code Set}.
     *
     * @param set
     *            the set whose elements to increment
     * @updates set
     * @ensures
     *
     *          <pre>
     * DOMAIN(map) = DOMAIN(#map)  and
     * [set is the set of integers that are elements of #set incremented by 1]
     *          </pre>
     */
    public static void incrementAll(java.util.Set<NaturalNumber> set) {
        assert set != null : "Violation of: set is not null";
        Iterator<NaturalNumber> it = set.iterator();
        java.util.Set<NaturalNumber> newSet = new java.util.HashSet<NaturalNumber>();
        while (it.hasNext()) {
            NaturalNumber next = it.next();
            it.remove();
            NaturalNumber newNext = new NaturalNumber1L(next);
            newNext.increment();
            newSet.add(newNext);
        }
        Iterator<NaturalNumber> it2 = newSet.iterator();
        while (it2.hasNext()) {
            NaturalNumber next = it2.next();
            it2.remove();
            set.add(next);
        }
    }

}
