using MedicalDocument.Models.DTO;
using MedicalDocument.Models.Entities;
using MedicalDocument.Models.Services;
using MedicalDocument.Models.Services.Interfaces;
using MedicalDocument.ViewModels.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using System.Windows.Markup;
using System.Reflection;
using MedicalDocument.Infrastructure.Commands;

namespace MedicalDocument.ViewModels
{
    [MarkupExtensionReturnType(typeof(MainWindowViewModel))]
    public class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
            InitDtosDictionary();
            ChangePatientGroupCommand = new LambdaCommand(OnChangePatientGroupCommandExecuted,
                CanChangePatientGroupCommandExecute);
        }

        #region Properties

        private Dictionary<string, SpecialGroupWindowDto> _dtos;

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

        #region ChangePatientGroupCommand

        public ICommand ChangePatientGroupCommand { get; }
        private void OnChangePatientGroupCommandExecuted(object p)
        {
            try
            {
                Status = "";
                if (p is string key)
                {
                    IUserDialog<SpecialGroupWindowDto> dialog 
                        = App.Services.GetRequiredService<SpecialGroupWindowUserDialog>();
                    dialog.Edit(_dtos[key]);
                    UpdatePatientsCountInDifferentGroups();
                }
                else
                    throw new ArgumentException($"Тип параметра команды должен быть string," +
                        $" но получено {p.GetType()}");
            }
            catch (Exception ex)
            {
                Status = ex.Message;
            }
        }
        private bool CanChangePatientGroupCommandExecute(object p) => true;

        #endregion

        #endregion

        #region Methods
        private void InitDtosDictionary()
        {
            _dtos = new Dictionary<string, SpecialGroupWindowDto>();
            _dtos.Add(nameof(DischargedPatientsCount), new SpecialGroupWindowDto() { PatientsGroupName = "выписанных" });
            _dtos.Add(nameof(TransferredToAnotherDepartments), 
                new SpecialGroupWindowDto() { PatientsGroupName = "переведенных в другие отделения" });
            _dtos.Add(nameof(TransferredToAnotherHospitals), 
                new SpecialGroupWindowDto() { PatientsGroupName = "переведенных в другие стационары" });
            _dtos.Add(nameof(DeceasedPatients), new SpecialGroupWindowDto() { PatientsGroupName = "умерших" });
            _dtos.Add(nameof(PatientsOnTemporaryLeave), new SpecialGroupWindowDto() { PatientsGroupName = "во временном отпуске" });
        }
        private void UpdatePatientsCountInDifferentGroups()
        {
            IEnumerable<PropertyInfo> properties = GetType().GetRuntimeProperties();
            foreach (PropertyInfo property in properties)
            {
                foreach (var key in _dtos.Keys)
                {
                    if (property.Name == key)
                        property.SetValue(this, _dtos[key].Count);
                }   
            }           
        }
        #endregion
    }
}
