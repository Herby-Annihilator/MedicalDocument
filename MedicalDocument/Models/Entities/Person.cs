using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalDocument.Models.Entities
{
    public class Person
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; } = "";
        public virtual string LastName { get; set; } = "";
        public virtual string? Patronymic { get; set; }
        public int Age { get; set; } = 25;
        public Sex Sex { get; set; } = Sex.Male;

        public virtual Person Clone()
        {
            return new Person()
            {
                Id = Id,
                FirstName = (string)FirstName.Clone(),
                LastName = (string)LastName.Clone(),
                Patronymic = (string)Patronymic.Clone(),
                Age = Age,
                Sex = Sex,
            };
        }
    }

    public enum Sex
    {
        Male,
        Female,
    }
}
