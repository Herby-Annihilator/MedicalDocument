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
        public string PatientsGroupName { get; set; }
        public IEnumerable<Patient> Patients { get; set; }
        public int Count => Patients == null ? 0 : Patients.Count();
    }
}
