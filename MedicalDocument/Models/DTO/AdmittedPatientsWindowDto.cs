using MedicalDocument.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDocument.Models.DTO
{
    public class AdmittedPatientsWindowDto
    {
        public virtual ICollection<PatientTransferredFromHospital> PatientTransferredFromHospital { get; set; } 
            = new List<PatientTransferredFromHospital>();
        public virtual int Count => PatientTransferredFromHospital == null ? 0 : PatientTransferredFromHospital.Count;
        public virtual int CountOfPatientsFromHospital { get; set; }
    }
}
