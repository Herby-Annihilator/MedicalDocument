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
            .AddTransient<IUserDialog<SpecialGroupWindowDto>, SpecialGroupWindowUserDialog>()
            .AddTransient<IUserDialog<AdmittedPatientsWindowDto>, AdmittedPatientsWindowUserDialog>()
        // Register your services here
        ;
    }
}
