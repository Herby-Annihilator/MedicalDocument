using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDocument.Models.Entities
{
    public class Bed
    {
        public int Id { get; set; }
        public MedicalProfile Profile { get; set; }

        public Bed(int id, MedicalProfile profile)
        {
            Id = id;
            Profile = profile;
        }
    }
}
