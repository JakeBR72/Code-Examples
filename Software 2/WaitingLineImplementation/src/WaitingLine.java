/**
 * Put a short phrase describing the program here.
 *
 * @author Put your name here
 *
 */
public interface WaitingLine<T> extends WaitingLineKernel<T> {

    /**
     * Reports the position of the given {@code name} from within {@code this}.
     *
     * @return the position of the entry {@code name}
     * @aliases reference returned by {@code position}
     * @requires this /= <> and name is in this
     * @ensures position = int corresponding to pos in queue
     */
    int position(String name);

    /**
     * Removes and returns the entry with the name(@code name) from {@code this}
     * .
     *
     * @return the entry removed
     * @updates this
     * @requires this /= <>, x is in this
     * @ensures #this = <dequeue> * this
     */
    T dequeue(String name);

}