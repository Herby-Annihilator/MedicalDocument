using MedicalDocument.Models.DTO;
using MedicalDocument.Models.Services.Interfaces;
using MedicalDocument.ViewModels;
using MedicalDocument.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDocument.Models.Services
{
    public class SpecialGroupWindowUserDialog : IUserDialog<SpecialGroupWindowDto>
    {
        public bool Edit(SpecialGroupWindowDto editData)
        {
            var data = new SpecialGroupWindowViewModel(editData);
            var window = new SpecialGroupWindow();
            window.DataContext = data;
            data.CloseWindow += (_, e) =>
            {
                window.DialogResult = e.DialogResult;
            };
            return window.ShowDialog() ?? false;
        }
    }
}
