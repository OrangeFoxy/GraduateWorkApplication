using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkApplication.Models
{
    class CRUD
    {
        private EnrolleeContext db;
        private SearchSetting setting;
        public CRUD(EnrolleeContext db, SearchSetting setting)
        {
            this.db = db;
            this.setting = setting;
        }

        // Create
        public void CreateRecordEnrollee(Enrollee record)
        {
            if (record == null)
            {
                return;
            }
            db.Enrollees.Add(record);
            Save();
        }
        public void CreateRecordGroup(Group record)
        {
            if (record == null)
            {
                return;
            }
            db.Groups.Add(record);
            Save();
        }

        // Read
        public ObservableCollection<Group> Groups =>
            new ObservableCollection<Group>(db.Groups.ToList());
        public ObservableCollection<Enrollee> ReadTableEnrollee()
        {
            List<Enrollee> enrollees = db.Enrollees.Include(e => e.Group).ToList();
            enrollees = (from e in enrollees
                        where CheckEnrollee(e)
                        select e).ToList();
            return new ObservableCollection<Enrollee>(enrollees);
        }
        // Проверка для вывода
        private bool CheckEnrollee(Enrollee enrollee)
        {

            Group grp = setting.SelectedGroup;
            bool all = setting.DisplayAllEnrollees;

            if (grp != null && enrollee != null)
            {
                if (grp == enrollee.Group || all)
                {
                    // Проверка на расширенный поиск
                    if (setting.AdvSearch)
                    {
                        return CheckString(enrollee.Name, setting.SearchName) &&
                               CheckString(enrollee.Address, setting.SearchAddress) &&
                               CheckString(enrollee.Passport, setting.SearchPassport) &&
                               CheckString(enrollee.Privilege, setting.SearchPrivilege) &&
                               CheckString(enrollee.Certificate, setting.SearchCert) &&
                               CheckString(enrollee.School, setting.SearchSchool) &&
                               CheckBool(enrollee.Budget, setting.Budget, setting.BudgetEnabled) &&
                               CheckBool(enrollee.Statement, setting.Statement, setting.StatementEnabled) &&
                               CheckBool(enrollee.Home, setting.Home, setting.HomeEnabled);
                    } else
                    {
                        return CheckString(enrollee.Name, setting.SearchName);
                    }
                }
            }
            return false;

        }
        // Проверка строки
        // Если пустая, то вовзращает true
        // Иначе проверяется подстрока
        private bool CheckString(string str, string sub)
        {
            if (sub == "" || sub == null)
            {
                return true;
            }
            else
            {
                if (str != null)
                {
                    return str.ToLower().Contains(sub.ToLower());
                }
                return false;
            }
        }
        private bool CheckBool(bool enrollee, bool setting, bool enabled)
        {
            return !enabled || (enrollee == setting);
        }

        // Update
        public void UpdateRecordEnrollee(Enrollee record)
        {
            if (record == null)
            {
                return;
            }
            db.Enrollees.Update(record);
            Save();

        }
        public void UpdateRecordGroup(Group record)
        {
            if (record == null)
            {
                return;
            }
            db.Groups.Update(record);
            Save();
        }

        // Delete
        public void DeleteRecordEnrollee(Enrollee record)
        {
            if (record == null)
            {
                return;
            }
            db.Enrollees.Remove(record);
            Save();
        }
        public void DeleteRecordGroup(Group record)
        {
            if (record == null)
            {
                return;
            }
            db.Groups.Remove(record);
            Save();
        }

        // Метод для сохранения
        private void Save()
        {
            //try
            //{
            //    await Task.Run(() => db.SaveChanges());
            //}
            //catch (System.InvalidOperationException)
            //{

            //    throw;
            //}
            db.SaveChanges();
        }
    }
}
