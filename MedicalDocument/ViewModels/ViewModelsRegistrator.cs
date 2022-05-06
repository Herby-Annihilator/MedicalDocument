using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalDocument.ViewModels
{
    public static class ViewModelsRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
           .AddSingleton<MainWindowViewModel>()
            .AddTransient<AdmittedPatientsWindowViewModel>()
            .AddTransient<DetailsWindowViewModel>()
            .AddTransient<SpecialGroupWindowViewModel>()
        ;
    }
}
