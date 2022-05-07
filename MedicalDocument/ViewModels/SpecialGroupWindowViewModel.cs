using MedicalDocument.Infrastructure.Commands;
using MedicalDocument.Models.DTO;
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
    public class SpecialGroupWindowViewModel : ClosableViewModel
    {
        // TODO: вполне возможна утечка памяти
        private SpecialGroupWindowDto _groupWindowDto;
        public SpecialGroupWindowViewModel(SpecialGroupWindowDto dto) : this()
        {
            _groupWindowDto = dto;
            Patients = new ObservableCollection<Patient>(dto.Patients);
            PatientsGroupName = dto.PatientsGroupName;
        }

        public SpecialGroupWindowViewModel()
        {
            SaveChangesCommand = new LambdaCommand(OnSaveChangesCommandExecuted,
                CanSaveChangesCommandExecute);
            CancelCommand = new LambdaCommand(OnCancelCommandExecuted,
                CanCancelCommandExecute);
            AddPatientCommand = new LambdaCommand(OnAddPatientCommandExecuted,
                CanAddPatientCommandExecute);
            RemoveSelectedPatientCommand = new LambdaCommand(OnRemoveSelectedPatientCommandExecuted,
                CanRemoveSelectedPatientCommandExecute);
        }

        #region Propeties
        private string _status = "";
        public string Status { get => _status; set => Set(ref _status, value); }

        private string _patientsGroupName = "";
        public string PatientsGroupName { get => _patientsGroupName; set => Set(ref _patientsGroupName, value); }
        public ObservableCollection<Patient> Patients { get; }     
        public Patient SelectedPatient { get; set; }
        
        #endregion

        #region Commands

        #region SaveChangesCommand
        public ICommand SaveChangesCommand { get; }
        private void OnSaveChangesCommandExecuted(object p)
        {
            PrepareData();
            OnCloseWindow(new CloseWindowEventArgs(true));
        }
        private bool CanSaveChangesCommandExecute(object p) => true;
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

        #region AddPatientCommand
        public ICommand AddPatientCommand { get; }
        private void OnAddPatientCommandExecuted(object p)
        {
            try
            {
                Status = "";
                Patients.Add(new Patient());
                Status = "Пациент добавлен";
            }
            catch (Exception ex)
            {
                Status = ex.Message;
            }
        }
        private bool CanAddPatientCommandExecute(object p) => true;
        #endregion

        #region RemoveSelectedPatientCommand
        public ICommand RemoveSelectedPatientCommand { get; }
        private void OnRemoveSelectedPatientCommandExecuted(object p)
        {
            try
            {
                Status = "";
                Patients.Remove(SelectedPatient);
                Status = "Пациент удален";
            }
            catch (Exception ex)
            {
                Status = ex.Message;
            }
        }
        private bool CanRemoveSelectedPatientCommandExecute(object p) 
            => SelectedPatient is not null && Patients.Count > 0;
        #endregion

        #endregion

        private void PrepareData()
        {
            _groupWindowDto.Patients.Clear();
            foreach (var item in Patients)
            {
                _groupWindowDto.Patients.Add(item.Clone());
            }
        }
    }
}
