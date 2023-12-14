namespace Chiffre_Affaire_Project.Entities
{
    public class Passenger
    {
        public int Id { get; set; }
        public PassengerType Type { get; set; }
        public int Age { get; set; }
        public Family Family { get; set; }
        public bool RequiresTwoSeats { get; set; }

        public Passenger(int id, PassengerType type, int age, Family family, bool requiresTwoSeats)
        {
            Id = id;
            Type = type;
            Age = age;
            Family = family;
            RequiresTwoSeats = requiresTwoSeats;
        }
    }
}
