using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDocument.Models.Entities
{
    public class PatientTransferredFromHospital : Patient
    {
        public virtual bool IsFromHospital { get; set; } = false;

        public override PatientTransferredFromHospital Clone()
        {
            PatientTransferredFromHospital result = new PatientTransferredFromHospital()
            {
                Age = Age,
                FirstName = (string)FirstName.Clone(),
                LastName = (string)LastName.Clone(),
                Patronymic = (string)Patronymic.Clone(),
                Id = Id,
                IsFromHospital = IsFromHospital,
                IsFromVillage = IsFromVillage,
                Sex = Sex,
            };
            return result;
        }
    }
}
