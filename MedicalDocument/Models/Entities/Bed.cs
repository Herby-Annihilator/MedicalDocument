using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDocument.Models.Entities
{
    public class Bed
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public MedicalProfile Profile { get; set; }
    }
}
