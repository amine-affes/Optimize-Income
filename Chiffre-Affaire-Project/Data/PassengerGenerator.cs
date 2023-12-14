using Chiffre_Affaire_Project.Entities;

namespace Chiffre_Affaire_Project.Data
{
    public static class PassengerGenerator
    {
        private static Random random = new Random();

        public static Passenger GenerateRandomPassenger(int id, Dictionary<char, List<Passenger>> familyMembers)
        {
            PassengerType[] types = { PassengerType.Enfant, PassengerType.Adulte, PassengerType.Enfant, PassengerType.Enfant, PassengerType.Enfant, PassengerType.Enfant };

            char randomFamily = GetRandomFamily();

            if (!familyMembers.ContainsKey(randomFamily))
            {
                familyMembers[randomFamily] = new List<Passenger>();
            }

            Family family = familyMembers[randomFamily].Count > 0 ? familyMembers[randomFamily][0].Family : new Family(randomFamily, familyMembers[randomFamily]);
            //Family family = new Family(randomFamily);

            if (family.Members.Count >= 5 && randomFamily != '-')
            {
                return GenerateRandomPassenger(id, familyMembers);
            }

            int adultsCount = family.Members.Count(p => p.Type == PassengerType.Adulte);
            int childrenCount = family.Members.Count(p => p.Type == PassengerType.Enfant);
            int requiringTwoSeatsCount = family.Members.Count(p => p.RequiresTwoSeats == true);

            PassengerType randomType = types[random.Next(types.Length)];

            // Ensure a maximum of two adults and 3 children and no children alone
            while ((randomType == PassengerType.Adulte && adultsCount >= 2) ||
                   (randomType == PassengerType.Enfant && (childrenCount >= 3 || adultsCount == 0)) && randomFamily != '-')
            {
                randomType = types[random.Next(types.Length)];
            }

            int age = randomType == PassengerType.Enfant ? random.Next(1, 18) : random.Next(18, 101);
            bool requiresTwoSeats = (randomType == PassengerType.Adulte) ? random.Next(0, 2) == 1 : false;

            var passenger = new Passenger(id, randomFamily == '-' ? PassengerType.Adulte : randomType, age, family, requiresTwoSeats);
            family.Members.Add(passenger);

            return passenger;
        }
        public static char GetRandomFamily()
        {
            char[] familyNames = { '-', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L',
                'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '1', '2', '3',
                '4', '5', '6', '7', '8', '9', '0', '/', '*' };
            Random random = new Random();
            return familyNames[random.Next(familyNames.Length)];
        }
    }
}
