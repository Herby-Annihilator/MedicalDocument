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
    public class AdmittedPatientsWindowViewModel : ViewModel
    {
        public AdmittedPatientsWindowViewModel()
        {
            SaveChangesCommand = new LambdaCommand(OnSaveChangesCommandExecuted,
                CanSaveChangesCommandExecute);
            CancelCommand = new LambdaCommand(OnCancelCommandExecuted,
                CanCancelCommandExecute);
        }

        #region Properties

        private int _patientsFromHospital = 0;
        public int PatientsFromHospital { get => _patientsFromHospital; set => Set(ref _patientsFromHospital, value); }

        public ObservableCollection<Patient> Patients { get; private set; } = new ObservableCollection<Patient>();

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
