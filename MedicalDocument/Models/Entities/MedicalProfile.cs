using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDocument.Models.Entities
{
    public class MedicalProfile
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public MedicalProfile(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
