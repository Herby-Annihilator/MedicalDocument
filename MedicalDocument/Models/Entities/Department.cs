using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDocument.Models.Entities
{
    public class Department
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = "";
        public int Number { get; set; } = 0;
        public MedicalProfile GeneralProfile { get; set; }
        public List<Bed> Beds { get; set; } = new List<Bed>();
    }
}
