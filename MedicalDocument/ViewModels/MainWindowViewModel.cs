using MedicalDocument.Models.Entities;
using MedicalDocument.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Markup;

namespace MedicalDocument.ViewModels
{
    [MarkupExtensionReturnType(typeof(MainWindowViewModel))]
    public class MainWindowViewModel : ViewModel
    {
        #region Properties
        private string _title = "Title";
        public string Title { get => _title; set => Set(ref _title, value); }

        private string _status = "Status";
        public string Status { get => _status; set => Set(ref _status, value); }

        private string _organizationName = "";
        public string OrganizationName { get => _organizationName; set => Set(ref _organizationName, value); }

        private string _departmentNumber = "";
        public string DepartmentNumber { get => _departmentNumber; set => Set(ref _departmentNumber, value); }

        private string _bedsGeneralProfile = "";
        public string BedsGeneralProfile { get => _bedsGeneralProfile; set => Set(ref _bedsGeneralProfile, value); }

        private int _admittedPatientsCount = 0;
        public int AdmittedPatientsCount { get => _admittedPatientsCount;
            set => Set(ref _admittedPatientsCount, value); }

        private int _admittedFromHospitalPatientsCount = 0;
        public int AdmittedFromHospitalPatientsCount { get => _admittedFromHospitalPatientsCount;
            set => Set(ref _admittedFromHospitalPatientsCount, value); }

        private int _dischargedPatientsCount = 0;
        public int DischargedPatientsCount
        {
            get => _dischargedPatientsCount;
            set => Set(ref _dischargedPatientsCount, value);
        }

        private int _transferredToAnotherDepartments = 0;
        public int TransferredToAnotherDepartments
        {
            get => _transferredToAnotherDepartments;
            set => Set(ref _transferredToAnotherDepartments, value);
        }

        private int _transferredToAnotherHospitals = 0;
        public int TransferredToAnotherHospitals
        {
            get => _transferredToAnotherHospitals;
            set => Set(ref _transferredToAnotherHospitals, value);
        }

        private int _deceasedPatients = 0;
        public int DeceasedPatients
        {
            get => _deceasedPatients;
            set => Set(ref _deceasedPatients, value);
        }

        private int _patientsOnTemporaryLeave = 0;
        public int PatientsOnTemporaryLeave
        {
            get => _patientsOnTemporaryLeave;
            set => Set(ref _patientsOnTemporaryLeave, value);
        }

        public ObservableCollection<Employee> Employees { get; private set; } = new ObservableCollection<Employee>();
        private Employee _selectedEmplyee;
        public Employee SelectedEmployee { get => _selectedEmplyee; set => Set(ref _selectedEmplyee, value); }


        public ObservableCollection<Patient> Patients { get; private set; } = new ObservableCollection<Patient>();


        public ObservableCollection<Bed> Beds { get; private set; } = new ObservableCollection<Bed>();
        private Bed _selectedBed;
        public Bed SelectedBed { get => _selectedBed; set => Set(ref _selectedBed, value); }

        public ObservableCollection<MedicalProfile> MedicalProfiles { get; private set; } 
            = new ObservableCollection<MedicalProfile>();

        private MedicalProfile _selectedMedicalProfile;
        public MedicalProfile SelectedMedicalProfile { get => _selectedMedicalProfile; 
            set => Set(ref _selectedMedicalProfile, value); }
        #endregion

        #region Commands

        #endregion
    }
}
