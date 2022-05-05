using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDocument.Models.Entities
{
    public class Patient : Person
    {
        public bool IsFromVillage { get; set; }
    }
}
