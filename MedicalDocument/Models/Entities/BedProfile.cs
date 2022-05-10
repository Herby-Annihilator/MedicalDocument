using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDocument.Models.Entities
{
    public class BedProfile
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public BedProfile(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString() => Name;
    }
}
