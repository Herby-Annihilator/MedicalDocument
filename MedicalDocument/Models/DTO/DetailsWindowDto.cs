using MedicalDocument.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDocument.Models.DTO
{
    public class DetailsWindowDto
    {
        public int BedsCount { get; set; }

        public int BedsOnRepair { get; set; }

        public BedProfile SelectedProfile { get; set; }

        #region AdmittedPatients

        public int ChildrenCount { get; set; }

        public int OldPeopleCount { get; set; }

        public int PeopleFromVillageCount { get; set; }

        public int PeopleFromHospitalCount { get; set; }

        public int AllAdmittedPeopleCount { get; set; }

        #endregion

        #region DischargedPatients
        public int TransferredToAnotherHospitalsCount { get; set; }

        public int TransferredToTheHospitalCount { get; set;}

        public int TransferredToTheDailyHospitalCount { get; set;}

        public int AllDischargededPatientsCount { get; set;}

        #endregion

        #region TransferredInsideHospital
        public int TransferredFromAnotherDepartments { get; set;}

        public int TransferredToAnotherDepartments { get; set;}
        #endregion

        public int DeadPatientsCount { get; set;}

        public int CountOfPatientsOnTheStartOfThePreviousDay { get; set;}

        public int CountOfPatientsOnTheStartOfTheCurrentDay { get; set;}

        public int CountOfMothersWithSickChildren { get; set;}

        public int FreeMaleBedsCount { get; set;}

        public int FreeFemaleBedsCount { get; set;}
    }
}
