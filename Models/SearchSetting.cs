using System;
using System.Collections.Generic;
using System.Text;

namespace GraduateWorkApplication.Models
{
    public class SearchSetting
    {
        public Group SelectedGroup;
        public bool DisplayAllEnrollees;

        public bool AdvSearch = false;

        public bool Statement = false;
        public bool Budget = true;
        public bool Home = false;

        public bool StatementEnabled = false;
        public bool BudgetEnabled = false;
        public bool HomeEnabled = false;

        public string SearchName;
        public string SearchAddress;
        //public string SearchPhone;
        public string SearchPassport;
        //public string SearchTax;
        //public string SearchIns;
        //public string SearchMed;
        public string SearchPrivilege;
        public string SearchCert;
        public string SearchSchool;
        //public string SearchYOI;
    }
}
