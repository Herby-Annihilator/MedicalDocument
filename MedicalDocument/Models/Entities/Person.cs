using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDocument.Models.Entities
{
    public class Person
    {
        public virtual Guid Id { get; set; } = Guid.NewGuid();
        public virtual string FirstName { get; set; } = "";
        public virtual string LastName { get; set; } = "";
        public virtual string? Patronymic { get; set; }
        public int Age { get; set; } = 25;
        public Sex Sex { get; set; } = Sex.Male;
    }

    public enum Sex
    {
        Male,
        Female,
    }
}
