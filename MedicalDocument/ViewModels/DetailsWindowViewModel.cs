using MedicalDocument.Infrastructure.Commands;
using MedicalDocument.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalDocument.ViewModels
{
    public class DetailsWindowViewModel : ViewModel
    {
        public DetailsWindowViewModel()
        {
            SaveChangesCommand = new LambdaCommand(OnSaveChangesCommandExecuted,
                CanSaveChangesCommandExecute);
            CancelCommand = new LambdaCommand(OnCancelCommandExecuted, CanCancelCommandExecute);
        }

        #region Properties
        private string _bedsCount = "";
        public string BedsCount { get => _bedsCount; set => Set(ref _bedsCount, value); }

        #region AdmittedPatients

        private string _childrenCount = "";
        public string ChildrenCount { get => _childrenCount; set => Set(ref _childrenCount, value); }

        private string _oldPeopleCount = "";
        public string OldPeopleCount { get => _oldPeopleCount; set => Set(ref _oldPeopleCount, value); }

        private string _peopleFromVillageCount = "";
        public string PeopleFromVillageCount { get => _peopleFromVillageCount; set => Set(ref _peopleFromVillageCount, value); }

        private string _peopleFromHospitalCount = "";
        public string PeopleFromHospitalCount { get => _peopleFromHospitalCount; set => Set(ref _peopleFromHospitalCount, value); }

        private string _allAdmittedPeopleCount = "";
        public string AllAdmittedPeopleCount { get => _allAdmittedPeopleCount; set => Set(ref _allAdmittedPeopleCount, value); }

        #endregion

        #region DischargedPatients
        private string _transferredToAnotherHospitalsCount = "";
        public string TransferredToAnotherHospitalsCount { get => _transferredToAnotherHospitalsCount; set => Set(ref _transferredToAnotherHospitalsCount, value); }

        private string _transferredToTheHospitalCount = "";
        public string TransferredToTheHospitalCount { get => _transferredToTheHospitalCount; set => Set(ref _transferredToTheHospitalCount, value); }

        private string _transferredToTheDailyHospitalCount = "";
        public string TransferredToTheDailyHospitalCount { get => _transferredToTheDailyHospitalCount; set => Set(ref _transferredToTheDailyHospitalCount, value); }

        private string _allDischargededPatientsCount = "";
        public string AllDischargededPatientsCount { get => _transferredToTheDailyHospitalCount; set => Set(ref _transferredToTheDailyHospitalCount, value); }

        #endregion

        #region TransferredInsideHospital
        private string _transferredFromAnotherDepartments = "";
        public string TransferredFromAnotherDepartments { get => _transferredFromAnotherDepartments; set => Set(ref _transferredFromAnotherDepartments, value); }

        private string _transferredToAnotherDepartments = "";
        public string TransferredToAnotherDepartments { get => _transferredToAnotherDepartments; set => Set(ref _transferredToAnotherDepartments, value); }
        #endregion

        private string _deadPatientsCount = "";
        public string DeadPatientsCount { get => _deadPatientsCount; set => Set(ref _deadPatientsCount, value); }

        private string _countOfPatientsOnTheStartOfThePreviousDay = "";
        public string CountOfPatientsOnTheStartOfThePreviousDay { get => _countOfPatientsOnTheStartOfThePreviousDay; set => Set(ref _countOfPatientsOnTheStartOfThePreviousDay, value); }

        private string _countOfPatientsOnTheStartOfTheCurrentDay = "";
        public string CountOfPatientsOnTheStartOfTheCurrentDay { get => _countOfPatientsOnTheStartOfTheCurrentDay; set => Set(ref _countOfPatientsOnTheStartOfTheCurrentDay, value); }

        private string _countOfMothersWithSickChildren = "";
        public string CountOfMothersWithSickChildren { get => _countOfMothersWithSickChildren; set => Set(ref _countOfMothersWithSickChildren, value); }

        private string _freeMaleBedsCount = "";
        public string FreeMaleBedsCount { get => _freeMaleBedsCount; set => Set(ref _freeMaleBedsCount, value); }

        private string _freeFemaleBedsCount = "";
        public string FreeFemaleBedsCount { get => _freeFemaleBedsCount; set => Set(ref _freeFemaleBedsCount, value); }

        #endregion


        #region Commands

        #region SaveChangesCommand

        public ICommand SaveChangesCommand { get; }
        private void OnSaveChangesCommandExecuted(object p)
        {

        }
        private bool CanSaveChangesCommandExecute(object p)
        {
            return true;
        }

        #endregion

        #region CancelCommand

        public ICommand CancelCommand { get; }
        private void OnCancelCommandExecuted(object p)
        {

        }
        private bool CanCancelCommandExecute(object p) => true;

        #endregion

        #endregion

    }
}
