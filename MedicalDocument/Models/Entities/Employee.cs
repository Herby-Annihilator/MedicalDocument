using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDocument.Models.Entities
{
    public class Employee : Person
    {
        public virtual string Position { get; set; } = "";

        public string FullName => $"{FirstName} {LastName} {Patronymic}";
    }
}
