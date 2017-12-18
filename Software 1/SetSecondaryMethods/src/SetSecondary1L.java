import components.set.Set;
import components.set.Set1L;

/**
 * Layered implementations of secondary methods {@code add} and {@code remove}
 * for {@code Set}.
 *
 * @param <T>
 *            type of {@code Set} elements
 */
public final class SetSecondary1L<T> extends Set1L<T> {

    /**
     * Default constructor.
     */
    public SetSecondary1L() {
        super();
    }

    @Override
    public Set<T> remove(Set<T> s) {
        assert s != null : "Violation of: s is not null";
        assert s != this : "Violation of: s is not this";
        Set<T> remove = new Set1L<T>();
        if (s.size() != 0) {
            T sAny = s.removeAny();
            if (this.contains(sAny)) {
                this.remove(sAny);
                remove.add(sAny);
            }
            s.add(sAny);
        }
        return remove;
    }

    @Override
    public void add(Set<T> s) {
        if (s.size() != 0) {
            T sAny = s.removeAny();
            if (this.contains(sAny)) {
                s.add(sAny);
                this.add(s);
            } else {
                this.add(sAny);
            }
        }
    }

    public boolean isSubset(Set<T> s) {
        assert s != null : "Violation of: s is not null";
        assert s != this : "Violation of: s is not this";
        boolean isSubset = true;
        Set<T> temp = s.newInstance();
        temp.transferFrom(s);
        while (temp.size() > 0 && isSubset) {
            T sAny = temp.removeAny();
            isSubset = this.contains(sAny);
            s.add(sAny);
        }
        return isSubset;
    }
}
