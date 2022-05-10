using MedicalDocument.Models.Reports;
using MedicalDocument.Models.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDocument.Models.Services
{
    public class ExelExporter : IExelExporter
    {
        public void Export(object report)
        {
            if (report == null)
                throw new ArgumentNullException(nameof(report));
            if (report is RecordSheet recordSheet)
            {

            }
            else
                throw new ArgumentException($"Ожидался '{typeof(RecordSheet)}', но получено '{report.GetType()}'");
        }
    }
}
