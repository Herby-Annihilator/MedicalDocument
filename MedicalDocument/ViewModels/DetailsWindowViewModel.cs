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

        private int _bedsCount = 0;
        public int BedsCount { get => _bedsCount; set => Set(ref _bedsCount, value); }

        private int _bedsOnRepair = 0;
        public int BedsOnRepair { get => _bedsOnRepair; set => Set(ref _bedsOnRepair, value); }

        public ObservableCollection<MedicalProfile> MedicalProfiles { get; }
        public MedicalProfile SelectedProfile { get; set; }

        #region AdmittedPatients

        private int _childrenCount = 0;
        public int ChildrenCount { get => _childrenCount; set => Set(ref _childrenCount, value); }

        private int _oldPeopleCount = 0;
        public int OldPeopleCount { get => _oldPeopleCount; set => Set(ref _oldPeopleCount, value); }

        private int _peopleFromVillageCount = 0;
        public int PeopleFromVillageCount { get => _peopleFromVillageCount; set => Set(ref _peopleFromVillageCount, value); }

        private int _peopleFromHospitalCount = 0;
        public int PeopleFromHospitalCount { get => _peopleFromHospitalCount; set => Set(ref _peopleFromHospitalCount, value); }

        private int _allAdmittedPeopleCount = 0;
        public int AllAdmittedPeopleCount { get => _allAdmittedPeopleCount; set => Set(ref _allAdmittedPeopleCount, value); }

        #endregion

        #region DischargedPatients
        private int _transferredToAnotherHospitalsCount = 0;
        public int TransferredToAnotherHospitalsCount { get => _transferredToAnotherHospitalsCount; set => Set(ref _transferredToAnotherHospitalsCount, value); }

        private int _transferredToTheHospitalCount = 0;
        public int TransferredToTheHospitalCount { get => _transferredToTheHospitalCount; set => Set(ref _transferredToTheHospitalCount, value); }

        private int _transferredToTheDailyHospitalCount = 0;
        public int TransferredToTheDailyHospitalCount { get => _transferredToTheDailyHospitalCount; set => Set(ref _transferredToTheDailyHospitalCount, value); }

        private int _allDischargededPatientsCount = 0;
        public int AllDischargededPatientsCount { get => _allDischargededPatientsCount; set => Set(ref _allDischargededPatientsCount, value); }

        #endregion

        #region TransferredInsideHospital
        private int _transferredFromAnotherDepartments = 0;
        public int TransferredFromAnotherDepartments { get => _transferredFromAnotherDepartments; set => Set(ref _transferredFromAnotherDepartments, value); }

        private int _transferredToAnotherDepartments = 0;
        public int TransferredToAnotherDepartments { get => _transferredToAnotherDepartments; set => Set(ref _transferredToAnotherDepartments, value); }
        #endregion

        private int _deadPatientsCount = 0;
        public int DeadPatientsCount { get => _deadPatientsCount; set => Set(ref _deadPatientsCount, value); }

        private int _countOfPatientsOnTheStartOfThePreviousDay = 0;
        public int CountOfPatientsOnTheStartOfThePreviousDay { get => _countOfPatientsOnTheStartOfThePreviousDay; set => Set(ref _countOfPatientsOnTheStartOfThePreviousDay, value); }

        private int _countOfPatientsOnTheStartOfTheCurrentDay = 0;
        public int CountOfPatientsOnTheStartOfTheCurrentDay { get => _countOfPatientsOnTheStartOfTheCurrentDay; set => Set(ref _countOfPatientsOnTheStartOfTheCurrentDay, value); }

        private int _countOfMothersWithSickChildren = 0;
        public int CountOfMothersWithSickChildren { get => _countOfMothersWithSickChildren; set => Set(ref _countOfMothersWithSickChildren, value); }

        private int _freeMaleBedsCount = 0;
        public int FreeMaleBedsCount { get => _freeMaleBedsCount; set => Set(ref _freeMaleBedsCount, value); }

        private int _freeFemaleBedsCount = 0;
        public int FreeFemaleBedsCount { get => _freeFemaleBedsCount; set => Set(ref _freeFemaleBedsCount, value); }

        #endregion


        #region Commands

        #region SaveChangesCommand

        public ICommand SaveChangesCommand { get; }
        private void OnSaveChangesCommandExecuted(object p)
        {

        }
        private bool CanSaveChangesCommandExecute(object p)
        {
            return SelectedProfile != null;
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
