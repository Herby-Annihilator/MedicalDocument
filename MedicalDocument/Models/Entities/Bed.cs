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
        public BedProfile Profile { get; set; }

        public Bed(int id, BedProfile profile)
        {
            Id = id;
            Profile = profile;
        }
    }
}
