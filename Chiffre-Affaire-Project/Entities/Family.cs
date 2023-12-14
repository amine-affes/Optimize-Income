using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chiffre_Affaire_Project.Entities
{
    public class Family
    {
        public char FamilyName { get; }
        public List<Passenger> Members { get; }

        public Family(char familyName, List<Passenger> members)
        {
            FamilyName = familyName;
            Members = members;
        }
    }
}
