using GraduateWorkApplication.ViewModels.Base;
using System;

namespace GraduateWorkApplication.Models
{
    public class Enrollee : ViewModelBase
    {
        // Все поля
        private string _Name;
        private int _Id;
        private DateTime _Date;
        private string _Address;
        private string _Phone;
        private string _Passport;
        private string _TaxpayerNumber;
        private string _InsurancePolicy;
        private string _MedicalPolicy;

        private bool _Statement;
        private bool _Budget;
        private bool _Home;
        private string _Privilege;

        private string _Certificate;
        private float _AverageScore;
        private string _School;
        private string _YearOfIssue;

        private Group _Group;

        public int Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }
        // ФИО
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }
        // Дата рождения
        public DateTime Date
        {
            get { return _Date; }
            set { SetProperty(ref _Date, value); }
        }
        // Адрес
        public string Address
        {
            get { return _Address; }
            set { SetProperty(ref _Address, value); }
        }
        // Телефон - 11 символов
        public string Phone
        {
            get { return _Phone; }
            set { SetProperty(ref _Phone, value); }
        }
        // Паспорт
        public string Passport
        {
            get { return _Passport; }
            set { SetProperty(ref _Passport, value); }
        }
        // ИНН
        public string TaxpayerNumber
        {
            get { return _TaxpayerNumber; }
            set { SetProperty(ref _TaxpayerNumber, value); }
        }
        // СНИЛС
        public string InsurancePolicy
        {
            get { return _InsurancePolicy; }
            set { SetProperty(ref _InsurancePolicy, value); }
        }
        // Полис
        public string MedicalPolicy
        {
            get { return _MedicalPolicy; }
            set { SetProperty(ref _MedicalPolicy, value); }
        }

        // Колледж

        // Электронное заявление
        public bool Statement
        {
            get { return _Statement; }
            set { SetProperty(ref _Statement, value); }
        }
        // Бюджет или внебюджет
        public bool Budget
        {
            get { return _Budget; }
            set { SetProperty(ref _Budget, value); }
        }
        // Общежитие
        public bool Home
        {
            get { return _Home; }
            set { SetProperty(ref _Home, value); }
        }
        // Льготы
        public string Privilege
        {
            get { return _Privilege; }
            set { SetProperty(ref _Privilege, value); }
        }

        // Школа

        // Аттестат

        public string Certificate
        {
            get { return _Certificate; }
            set { SetProperty(ref _Certificate, value); }
        }
        // Средний балл аттестата
        public float AverageScore
        {
            get { return _AverageScore; }
            set { SetProperty(ref _AverageScore, value); }
        }
        // Оконченная школа
        public string School
        {
            get { return _School; }
            set { SetProperty(ref _School, value); }
        }
        // Год выпуска
        public string YearOfIssue
        {
            get { return _YearOfIssue; }
            set { SetProperty(ref _YearOfIssue, value); }
        }

        public int GroupKey { get; set; }
        // Связь
        public Group Group
        {
            get { return _Group; }
            set { SetProperty(ref _Group, value); }
        }
    }
}
