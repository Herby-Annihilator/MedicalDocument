using MedicalDocument.Models.DTO;
using MedicalDocument.Models.Entities;
using MedicalDocument.Models.ViewEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDocument.Models.Reports
{
    public class RecordSheet
    {
        public string OrganizationName { get; set; }
        public string DepartmentName { get; set; }
        public Employee Employee { get; set; }
        public IEnumerable<BedsTableRow> BedsTableRows { get; set; }
        public BedProfile GeneralProfile { get; set; }
        public Dictionary<string, SpecialGroupWindowDto> SpecialDtos { get; set; }
        public AdmittedPatientsWindowDto AdmittedPatientsDto { get; set; }
    }
}
