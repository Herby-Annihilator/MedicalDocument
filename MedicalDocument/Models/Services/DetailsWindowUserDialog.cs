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
    public class DetailsWindowUserDialog : IUserDialog<DetailsWindowDto>
    {
        public bool Edit(DetailsWindowDto editData)
        {
            var data = new DetailsWindowViewModel(editData);
            var window = new DetailsWindow();
            window.DataContext = data;
            window.DataContext = data;
            window.Owner = App.Current.MainWindow;
            window.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            data.CloseWindow += (_, e) =>
            {
                window.DialogResult = e.DialogResult;
                window.Close();
            };
            return window.ShowDialog() ?? false;
        }
    }
}
