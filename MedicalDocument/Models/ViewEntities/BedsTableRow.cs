using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MedicalDocument.Models.Entities;

namespace MedicalDocument.Models.ViewEntities
{
    public class BedsTableRow : INotifyPropertyChanged
    {
        private BedProfile _profile;
        public BedProfile SelectedProfile
        {
            get => _profile;
            set
            {
                if (Equals(value, _profile)) return;
                _profile = value;
                Code = _profile.Id;
                OnPropertyChanged();
            }
        }
        public IEnumerable<BedProfile> Profiles { get; set; }
        private int _code = 0;
        public int Code
        {
            get => _code;
            set
            {
                if (Equals(_code, value)) return;
                _code = value;
                OnPropertyChanged();
            }
        }

        public BedsTableRow()
        {
            List<BedProfile> profiles = new List<BedProfile>();
            profiles.Add(new BedProfile(1, "Терапевтический"));
            profiles.Add(new BedProfile(2, "Хирургический"));
            profiles.Add(new BedProfile(3, "Венерологический"));
            profiles.Add(new BedProfile(4, "Кардиологический"));
            profiles.Add(new BedProfile(5, "Инфекционный"));
            profiles.Add(new BedProfile(6, "Неврологический"));
            profiles.Add(new BedProfile(7, "Нейрохирургический"));
            Profiles = profiles;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null) 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
    }
}
