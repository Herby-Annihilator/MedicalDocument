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
    public class AdmittedPatientsWindowViewModel : ClosableViewModel
    {
        // TODO: вполне возможна утечка памяти
        private AdmittedPatientsWindowDto _dto;
        public AdmittedPatientsWindowViewModel(AdmittedPatientsWindowDto dto) : this()
        {
            _dto = dto;
            PatientsFromHospital = dto.CountOfPatientsFromHospital;
            Patients = new ObservableCollection<PatientTransferredFromHospital>(dto.PatientTransferredFromHospital);
        }

        public AdmittedPatientsWindowViewModel()
        {
            SaveChangesCommand = new LambdaCommand(OnSaveChangesCommandExecuted,
                CanSaveChangesCommandExecute);
            CancelCommand = new LambdaCommand(OnCancelCommandExecuted,
                CanCancelCommandExecute);
            AddPatientCommand = new LambdaCommand(OnAddPatientCommandExecuted, CanAddPatientCommandExecute);
            RemoveSelectedPatient = new LambdaCommand(OnRemoveSelectedPatientExecuted, CanRemoveSelectedPatientExecute);
        }

        #region Properties

        private string _status = "";
        public string Status { get => _status; set => Set(ref _status, value); }

        private int _patientsFromHospital = 0;
        public int PatientsFromHospital { get => _patientsFromHospital; set => Set(ref _patientsFromHospital, value); }

        public ObservableCollection<PatientTransferredFromHospital> Patients { get; private set; }

        public PatientTransferredFromHospital SelectedPatient { get; set; }

        #endregion

        #region Commands

        #region SaveChangesCommand
        public ICommand SaveChangesCommand { get; }
        private void OnSaveChangesCommandExecuted(object p)
        {
            try
            {
                Status = "";
                PrepareData();
                OnCloseWindow(new CloseWindowEventArgs(true));
            }
            catch (Exception ex)
            {
                Status = ex.Message;
            }
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
                Patients.Add(new PatientTransferredFromHospital());
                Status = "Пациент добавлен";
            }
            catch (Exception ex)
            {
                Status = ex.Message;
            }
        }
        private bool CanAddPatientCommandExecute(object p) => true;
        #endregion

        #region RemoveSelectedPatient
        public ICommand RemoveSelectedPatient { get; }
        private void OnRemoveSelectedPatientExecuted(object p)
        {
            try
            {
                Status = "";
                Patients.Remove(SelectedPatient);
                Status = "Пациент добавлен";
            }
            catch (Exception ex)
            {
                Status = ex.Message;
            }
        }
        private bool CanRemoveSelectedPatientExecute(object p) => SelectedPatient != null && Patients.Count > 0;
        #endregion

        #endregion

        private void PrepareData()
        {
            _dto.PatientTransferredFromHospital.Clear();
            _dto.CountOfPatientsFromHospital = 0;
            foreach (var item in Patients)
            {
                _dto.PatientTransferredFromHospital.Add(item.Clone());
                if (item.IsFromHospital)
                    _dto.CountOfPatientsFromHospital++;
            }
        }
    }
}
