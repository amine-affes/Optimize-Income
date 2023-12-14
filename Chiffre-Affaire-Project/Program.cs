using Chiffre_Affaire_Project.Data;
using Chiffre_Affaire_Project.Entities;
using Chiffre_Affaire_Project.Services;

class Program
{
    static void Main()
    {
        Random random = new Random();
        int numberOfPassengers = random.Next(100, 201); // Set a range that fits the airplane's capacity

        RevenueCalculator revenueCalculator = new RevenueCalculator(200);
        var familiesList = new Dictionary<char, List<Passenger>>();

        for (int i = 1; i <= numberOfPassengers; i++)
        {
            Passenger randomPassenger = PassengerGenerator.GenerateRandomPassenger(i, familiesList);
            Console.WriteLine($"randomPassenger {i}: {randomPassenger.Type} {randomPassenger.RequiresTwoSeats} {randomPassenger.Family}");
            revenueCalculator.AddPassenger(randomPassenger);
        }


        revenueCalculator.OptimizeRevenue();
    }
}
