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
            UpdatePatientsCountInDifferentGroups();
            _admittedPatientsDto = new AdmittedPatientsWindowDto();
            UpdateAdmittedPatientsProperties();
            ChangePatientGroupCommand = new LambdaCommand(OnChangePatientGroupCommandExecuted,
                CanChangePatientGroupCommandExecute);
            ClearPatientsGroupsCommand = new LambdaCommand(OnClearPatientsGroupsCommandExecuted,
                CanClearPatientsGroupsCommandExecute);
            ChangeAdmittedPatientGroupCommand = new LambdaCommand(OnChangeAdmittedPatientGroupCommandExecuted,
                CanChangeAdmittedPatientGroupCommandExecute);
            ClearAdmittedPatientsGroupsCommand = new LambdaCommand(OnClearAdmittedPatientsGroupsCommandExecuted,
                CanClearAdmittedPatientsGroupsCommandExecute);
        }

        #region Properties

        private Dictionary<string, SpecialGroupWindowDto> _dtos;
        private AdmittedPatientsWindowDto _admittedPatientsDto;

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
                    bool result = dialog.Edit(_dtos[key]);
                    if (result)
                    {
                        UpdatePatientsCountInDifferentGroups();  // TODO: написать такой метод, но для одного свойства
                        Status = "Группа изменена";
                    }
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

        #region ClearPatientsGroupsCommand

        public ICommand ClearPatientsGroupsCommand { get; }
        private void OnClearPatientsGroupsCommandExecuted(object p)
        {
            try
            {
                Status = "";
                if (p is string key)
                {
                    _dtos[key].Patients.Clear();
                    UpdatePatientsCountInDifferentGroups();  // TODO: написать такой метод, но для одного свойства
                    Status = "Группа очищена";
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
        private bool CanClearPatientsGroupsCommandExecute(object p) => true;

        #endregion

        #region ChangeAdmittedPatientGroupCommand

        public ICommand ChangeAdmittedPatientGroupCommand { get; }
        private void OnChangeAdmittedPatientGroupCommandExecuted(object p)
        {
            try
            {
                Status = "";
                IUserDialog<AdmittedPatientsWindowDto> dialog
                    = App.Services.GetRequiredService<AdmittedPatientsWindowUserDialog>();
                bool result = dialog.Edit(_admittedPatientsDto);
                if (result)
                {
                    UpdateAdmittedPatientsProperties();
                    Status = "Группа изменена";
                }
            }
            catch (Exception ex)
            {
                Status = ex.Message;
            }
        }
        private bool CanChangeAdmittedPatientGroupCommandExecute(object p) => true;

        #endregion

        #region ClearAdmittedPatientsGroupsCommand

        public ICommand ClearAdmittedPatientsGroupsCommand { get; }
        private void OnClearAdmittedPatientsGroupsCommandExecuted(object p)
        {
            try
            {
                _admittedPatientsDto.PatientTransferredFromHospital.Clear();
                UpdateAdmittedPatientsProperties(); 
                Status = "Группа очищена";
            }
            catch (Exception ex)
            {
                Status = ex.Message;
            }
        }
        private bool CanClearAdmittedPatientsGroupsCommandExecute(object p) => _admittedPatientsDto.Count > 0
            || _admittedPatientsDto.CountOfPatientsFromHospital > 0;

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

        private void UpdateAdmittedPatientsProperties()
        {
            AdmittedPatientsCount = _admittedPatientsDto.Count;
            AdmittedFromHospitalPatientsCount = _admittedPatientsDto.CountOfPatientsFromHospital;
        }
        #endregion
    }
}
