using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalDocument.ViewModels
{
    public class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();
        public AdmittedPatientsWindowViewModel AdmittedPatientsWindowViewModel
            => App.Services.GetRequiredService<AdmittedPatientsWindowViewModel>();
        public SpecialGroupWindowViewModel SpecialGroupWindowViewModel
            => App.Services.GetRequiredService<SpecialGroupWindowViewModel>();
        public DetailsWindowViewModel DetailsWindowViewModel
            => App.Services.GetRequiredService<DetailsWindowViewModel>();
    }
}
