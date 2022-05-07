using MedicalDocument.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDocument.Models.DTO
{
    public class SpecialGroupWindowDto
    {
        public virtual string PatientsGroupName { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
        public virtual int Count => Patients == null ? 0 : Patients.Count();
    }
}
