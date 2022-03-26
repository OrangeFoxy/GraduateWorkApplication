using GraduateWorkApplication.ViewModels.Base;
using System.Collections.Generic;

namespace GraduateWorkApplication.Models
{

    public class Group : ViewModelBase
    {
        // Все поля
        private int _Id;
        private string _ShortName;
        private string _FullName;
        private List<Enrollee> _Enrollees;

        public int Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }
        // Группа
        public string ShortName
        {
            get { return _ShortName; }
            set { SetProperty(ref _ShortName, value); }
        }
        // Специальность
        public string FullName
        {
            get { return _FullName; }
            set { SetProperty(ref _FullName, value); }
        }
        // Связь
        public List<Enrollee> Enrollees
        {
            get { return _Enrollees; }
            set { SetProperty(ref _Enrollees, value); }
        }
    }
}
