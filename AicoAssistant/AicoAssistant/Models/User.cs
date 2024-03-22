namespace AicoAssistant.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //consent settings
        //list of linked accounts
        public int Age { get; set; }
        public DateOnly BirthDate { get; set; }
        //gender / pronouns
        //sexuality
        //origin
        public float Familiarity { get; set; }
        //list of interests
        //quirks
        //list of previous interactions
    }
}
