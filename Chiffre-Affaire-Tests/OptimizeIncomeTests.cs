using Chiffre_Affaire_Project.Data;
using Chiffre_Affaire_Project.Entities;
using Chiffre_Affaire_Project.Services;

[TestClass]
public class OptimizeIncomeTests
{
    [TestMethod]
    public void TestPassengerGeneration()
    {
        var familyMembers = new Dictionary<char, List<Passenger>>();
        for (int i = 1; i <= 100; i++)
        {
            var passenger = PassengerGenerator.GenerateRandomPassenger(i, familyMembers);
            Assert.IsNotNull(passenger);
            Assert.IsTrue(Enum.IsDefined(typeof(PassengerType), passenger.Type));
            Assert.IsNotNull(passenger.Family);
        }
    }

    [TestMethod]
    public void TestFamilyConstraints()
    {
        var familyMembers = new Dictionary<char, List<Passenger>>();
        for (int i = 1; i <= 100; i++)
        {
            var passenger = PassengerGenerator.GenerateRandomPassenger(i, familyMembers);
            //Family family = familyMembers[passenger.Family.FamilyName];
            Family family = new Family(passenger.Family.FamilyName, familyMembers[passenger.Family.FamilyName]);
            if (passenger.Type == PassengerType.Adulte)
            {
                Assert.IsTrue(family.Members.Count(p => p.Type == PassengerType.Adulte) <= 2);
            }
            else if (passenger.Type == PassengerType.Enfant)
            {
                Assert.IsTrue(family.Members.Count(p => p.Type == PassengerType.Enfant) <= 3);
            }
        }
    }

    [TestMethod]
    public void TestOptimizeRevenue()
    {
        var airplane = new RevenueCalculator(200);

        for (int i = 1; i <= 200; i++)
        {
            var passenger = PassengerGenerator.GenerateRandomPassenger(i, new Dictionary<char, List<Passenger>>());
            airplane.AddPassenger(passenger);
        }

        airplane.OptimizeRevenue();
    }
    [TestMethod]
    public void TestCapacityLimit()
    {
        var airplane = new RevenueCalculator(200);

        for (int i = 1; i <= 250; i++) // Trying to add more passengers than the airplane's capacity
        {
            var passenger = PassengerGenerator.GenerateRandomPassenger(i, new Dictionary<char, List<Passenger>>());
            airplane.AddPassenger(passenger);
        }

        Assert.AreEqual(200, airplane.Passengers.Count); // Ensure the number of passengers does not exceed the capacity
    }

    [TestMethod]
    public void TestPassengerRevenueCalculation()
    {
        var airplane = new RevenueCalculator(200);
        var familyMembers = new List<Passenger>()
        {
            new Passenger(1, PassengerType.Adulte, 30, new Family('A', new List<Passenger>()), false),
            new Passenger(2, PassengerType.Adulte, 35, new Family('A', new List<Passenger>()), false),
            new Passenger(3, PassengerType.Enfant, 10, new Family('A', new List<Passenger>()), false),
            new Passenger(4, PassengerType.Enfant, 8, new Family('A', new List<Passenger>()), false),
            new Passenger(5, PassengerType.Enfant, 5, new Family('A', new List<Passenger>()), false),
            new Passenger(6, PassengerType.Adulte, 45, new Family('B', new List<Passenger>()), true),
            new Passenger(7, PassengerType.Enfant, 12, new Family('B', new List<Passenger>()), false),
            new Passenger(8, PassengerType.Adulte, 50, new Family('C', new List<Passenger>()), true)
        };

        foreach (var passenger in familyMembers)
        {
            airplane.AddPassenger(passenger);
        }

        int totalRevenue = 0;
        foreach (var familyGroup in airplane.Passengers.GroupBy(p => p.Family))
        {
            totalRevenue += airplane.CalculateFamilyRevenue(familyGroup.ToList());
        }

        Assert.AreEqual(2100, totalRevenue); // Expected revenue based on the provided family members
    }
}
