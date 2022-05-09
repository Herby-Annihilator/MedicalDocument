using MedicalDocument.Models.DTO;
using MedicalDocument.Models.Services.Interfaces;
using MedicalDocument.ViewModels;
using MedicalDocument.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDocument.Models.Services
{
    public class AdmittedPatientsWindowUserDialog : IUserDialog<AdmittedPatientsWindowDto>
    {
        public bool Edit(AdmittedPatientsWindowDto editData)
        {
            var data = new AdmittedPatientsWindowViewModel(editData);
            var window = new AdmittedPatientsWindow();
            window.DataContext = data;
            data.CloseWindow += (_, e) =>
            {
                window.DialogResult = e.DialogResult;
            };
            return window.ShowDialog() ?? false;
        }
    }
}
