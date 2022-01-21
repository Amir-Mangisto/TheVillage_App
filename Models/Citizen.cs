using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheVillage_App.Models
{
    public class Citizen
    {
        public Citizen(int id, string firstName, string fatherName, string gender, bool bornInVillage, bool birthDate)
        {
            Id = id;
            FirstName = firstName;
            FatherName = fatherName;
            Gender = gender;
            BornInVillage = bornInVillage;
            BirthDate = birthDate;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string  Gender { get; set; }
        public bool BornInVillage { get; set; }
        public bool BirthDate { get; set; }

        public Citizen()
        {

        }

    }
}