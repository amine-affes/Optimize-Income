using Chiffre_Affaire_Project.Entities;

namespace Chiffre_Affaire_Project.Services
{
    public class RevenueCalculator
    {
        public List<Passenger> Passengers { get; set; } = new List<Passenger>();
        public int Capacity { get; }

        public RevenueCalculator(int capacity)
        {
            Capacity = capacity;
        }

        public void AddPassenger(Passenger passenger)
        {
            if (Passengers.Count < Capacity)
            {
                Passengers.Add(passenger);
            }
        }

        public void OptimizeRevenue()
        {
            var groupedByFamily = Passengers.GroupBy(p => p.Family).OrderByDescending(group => group.Count());

            int totalRevenue = 0;

            foreach (var familyGroup in groupedByFamily)
            {
                var familyMembers = familyGroup.ToList();
                int familyRevenue = CalculateFamilyRevenue(familyMembers);
                totalRevenue += familyRevenue;
            }

            Console.WriteLine($"Optimal Distribution of Passengers:\nTotal Revenue: {totalRevenue} €");
        }

        public int CalculateFamilyRevenue(List<Passenger> familyMembers)
        {
            int revenue = 0;

            int adultRevenue = familyMembers.Count(p => p.Type == PassengerType.Adulte && p.RequiresTwoSeats == false) * 250;
            revenue += adultRevenue;

            int childRevenue = familyMembers.Count(p => p.Type == PassengerType.Enfant) * 150;
            revenue += childRevenue;

            int requiringTwoSeatsRevenue = familyMembers.Count(p => p.RequiresTwoSeats == true) * 500;
            revenue += requiringTwoSeatsRevenue;

            Console.WriteLine($"Family: {familyMembers.First().Family.FamilyName}, Adults: {adultRevenue / 250}, Children: {childRevenue / 150}, Adult Requiring Two Seats: {requiringTwoSeatsRevenue / 500}, Revenue: {revenue} €");

            return revenue;
        }
    }
}
