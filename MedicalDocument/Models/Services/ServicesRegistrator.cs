using MedicalDocument.Models.DTO;
using MedicalDocument.Models.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalDocument.Models.Services
{
    public static class ServicesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddTransient<SpecialGroupWindowUserDialog>()
            .AddTransient<AdmittedPatientsWindowUserDialog>()
            .AddTransient<DetailsWindowUserDialog>()
            .AddTransient<IExelExporter, ExelExporter>()
        // Register your services here
        ;
    }
}
