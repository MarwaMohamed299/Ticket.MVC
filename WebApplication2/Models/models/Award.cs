namespace WebApplication2.Models.models;

public class Award
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string?  Description { get; set; }

    public Award(int id, string name, string? description = null)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public static List<Award> GetAwards() => new()
    {

        new Award(1, "Pulitzer Prize", "A prize awarded for achievements in journalism, literature, and musical composition."),
        new Award(2, "Man Booker Prize", "A literary prize awarded for the best original novel written in English and published in the UK."),
        new Award(3, "Nobel Prize in Literature", "A prize awarded to an author who has produced outstanding work in the field of literature."),
        new Award(4, "National Book Award", "An American literary prize awarded to recognize outstanding literary work by US citizens."),
        new Award(5, "Hugo Award", "An award presented annually for the best science fiction or fantasy works and achievements from the previous year."),
        new Award(6, "Newbery Medal", "An American literary award given to the author of the most distinguished contribution to American literature for children."),
        new Award(7, "Caldecott Medal", "An American literary award given to the artist of the most distinguished American picture book for children."),
        new Award(8, "Guggenheim Fellowship", "An American fellowship awarded to individuals who have demonstrated exceptional scholarship or artistic abilities."),
        new Award(9, "Whiting Award", "An American literary award given to ten emerging writers in fiction, nonfiction, poetry, and drama."),
        new Award(10, "Costa Book Awards", "A series of literary awards given to authors based in the UK and Ireland."),
    };

    public override string ToString() => Name;
}
