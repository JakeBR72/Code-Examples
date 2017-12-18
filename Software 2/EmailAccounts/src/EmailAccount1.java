import components.map.Map;
import components.map.Map2;

/**
 * Implementation of {@code EmailAccount}.
 *
 * @author Put your name here
 *
 */
public final class EmailAccount1 implements EmailAccount {

    /*
     * Private members --------------------------------------------------------
     */

    private String nameRep;
    private String emailRep;
    private static Map<String, Integer> nameDot = new Map2<String, Integer>();

    /*
     * Constructor ------------------------------------------------------------
     */

    /**
     * Constructor.
     *
     * @param firstName
     *            the first name
     * @param lastName
     *            the last name
     */
    public EmailAccount1(String firstName, String lastName) {
        this.nameRep = firstName + " " + lastName;
        lastName = lastName.toLowerCase();
        if (EmailAccount1.nameDot.hasKey(lastName)) {
            this.emailRep = lastName + "."
                    + (EmailAccount1.nameDot.value(lastName) + 1) + "@osu.edu";
            EmailAccount1.nameDot.replaceValue(lastName,
                    EmailAccount1.nameDot.value(lastName) + 1);
        } else {
            this.emailRep = lastName + ".1@osu.edu";
            EmailAccount1.nameDot.add(lastName, 1);
        }

    }

    /*
     * Methods ----------------------------------------------------------------
     */

    @Override
    public String name() {
        return this.nameRep;
    }

    @Override
    public String emailAddress() {
        return this.emailRep;
    }

    @Override
    public String toString() {
        return "Name: " + this.nameRep + ", Email: " + this.emailRep;
    }

}
