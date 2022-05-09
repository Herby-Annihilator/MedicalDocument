using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDocument.Models.Services.Interfaces
{
    public interface IExelExporter
    {
        void Export(object report);
    }
}
