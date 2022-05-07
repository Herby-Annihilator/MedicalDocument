using MedicalDocument.Infrastructure.Commands;
using MedicalDocument.Models.Entities;
using MedicalDocument.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalDocument.ViewModels
{
    public class DetailsWindowViewModel : ClosableViewModel
    {
        public DetailsWindowViewModel()
        {
            SaveChangesCommand = new LambdaCommand(OnSaveChangesCommandExecuted,
                CanSaveChangesCommandExecute);
            CancelCommand = new LambdaCommand(OnCancelCommandExecuted, CanCancelCommandExecute);
        }

        #region Properties

        private string _status = "";
        public string Status { get => _status; set => Set(ref _status, value); }

        private string _bedsCount = "";
        public string BedsCount { get => _bedsCount; set => Set(ref _bedsCount, value); }

        private string _bedsOnRepair = "";
        public string BedsOnRepair { get => _bedsOnRepair; set => Set(ref _bedsOnRepair, value); }

        public ObservableCollection<MedicalProfile> MedicalProfiles { get; }
        public MedicalProfile SelectedProfile { get; set; }

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
        public string AllDischargededPatientsCount { get => _allDischargededPatientsCount; set => Set(ref _allDischargededPatientsCount, value); }

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
            return !string.IsNullOrWhiteSpace(FreeFemaleBedsCount)
                && !string.IsNullOrWhiteSpace(FreeMaleBedsCount)
                && !string.IsNullOrWhiteSpace(CountOfMothersWithSickChildren)
                && !string.IsNullOrWhiteSpace(AllAdmittedPeopleCount)
                && !string.IsNullOrWhiteSpace(AllDischargededPatientsCount)
                && !string.IsNullOrWhiteSpace(BedsCount)
                && !string.IsNullOrWhiteSpace(BedsOnRepair)
                && !string.IsNullOrWhiteSpace(ChildrenCount)
                && !string.IsNullOrWhiteSpace(CountOfPatientsOnTheStartOfTheCurrentDay)
                && !string.IsNullOrWhiteSpace(CountOfPatientsOnTheStartOfThePreviousDay)
                && !string.IsNullOrWhiteSpace(DeadPatientsCount)
                && !string.IsNullOrWhiteSpace(OldPeopleCount)
                && !string.IsNullOrWhiteSpace(PeopleFromHospitalCount)
                && !string.IsNullOrWhiteSpace(PeopleFromVillageCount)
                && !string.IsNullOrWhiteSpace(TransferredFromAnotherDepartments)
                && !string.IsNullOrWhiteSpace(TransferredToAnotherDepartments)
                && !string.IsNullOrWhiteSpace(TransferredToAnotherHospitalsCount)
                && !string.IsNullOrWhiteSpace(TransferredToTheDailyHospitalCount)
                && !string.IsNullOrWhiteSpace(TransferredToTheHospitalCount)
                && SelectedProfile != null;
        }

        #endregion

        #region CancelCommand

        public ICommand CancelCommand { get; }
        private void OnCancelCommandExecuted(object p)
        {
            try 
            {
                Status = "";
                OnCloseWindow(new CloseWindowEventArgs(false));
            }
            catch (Exception ex)
            {
                Status = ex.Message;
            }
        }
        private bool CanCancelCommandExecute(object p) => true;

        #endregion

        #endregion

    }
}
