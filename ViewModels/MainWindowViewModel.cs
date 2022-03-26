using GraduateWorkApplication.Models;
using GraduateWorkApplication.ViewModels.Base;
using GraduateWorkApplication.Views.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;

namespace GraduateWorkApplication.ViewModels
{
    public enum OpenedPopup { Default, AddEnrollee, EditEnrollee, AddGroup, EditGroup, RemovePopup }
    public class MainWindowViewModel : ViewModelBase
    {
        private CRUD crud;
        private SearchSetting searchSetting = new SearchSetting();
        private OpenedPopup op = OpenedPopup.Default;

        private ObservableCollection<Enrollee> _Enrollees;
        private Enrollee _SelectedEnrollee;
        private Enrollee _BindedEnrollee;

        private ObservableCollection<Group> _Groups;
        private Group _BindedGroup;

        private RelayCommand _ShowAddPopupEnrolleeCommand;
        private RelayCommand _ShowEditPopupEnrolleeCommand;
        private RelayCommand _ShowAddPopupGroupCommand;
        private RelayCommand _ShowEditPopupGroupCommand;
        private RelayCommand _ShowRemovePopupEnrolleeCommand;
        private RelayCommand _ShowRemovePopupGroupCommand;

        private RelayCommand _ShowMainWindow;

        private RelayCommand _ClickAddEnrolleeCommand;
        private RelayCommand _ClickEditEnrolleeCommand;
        private RelayCommand _ClickAddGroupCommand;
        private RelayCommand _ClickRemoveCommand;

        private MessageInfo _BindedMessage;
        private MessageInfo _RemoveEnrolleeMessage = new MessageInfo(MessageInfo.TypeOfMessage.RemoveEnrollee, "Удалить выделенного абитуриента?");
        private MessageInfo _RemoveGroupMessage = new MessageInfo(MessageInfo.TypeOfMessage.RemoveGroup, "Удалить выделенную группу?");

        public MainWindowViewModel()
        {
            crud = new CRUD(new EnrolleeContext(), searchSetting);

            ReadGroupTable();
            if (Groups.Count > 0)
            {
                SelectedGroup = Groups[0];
            }
        }

        // Обновление списка абитуриентов для отображения
        public void ReadEnrolleeTable()
        {
            // Вывод всех абитуриентов по настройкам поиска (группа входит в поиск)
            Enrollees = crud.ReadTableEnrollee();
            foreach (Enrollee e in Enrollees)
            {
                e.PropertyChanged += UpdateRecordEnrollee;
            }
        }
        public void ReadGroupTable()
        {
            // Вывод всех абитуриентов по настройкам поиска (группа входит в поиск)
            Groups = crud.Groups;
            foreach (Group e in Groups)
            {
                e.PropertyChanged += UpdateRecordGroup;
            }
        }

        // Обновление записей при событии
        public void UpdateRecordEnrollee(object sender, PropertyChangedEventArgs e)
        {
            crud.UpdateRecordEnrollee((Enrollee)sender);
        }
        public void UpdateRecordGroup(object sender, PropertyChangedEventArgs e)
        {
            crud.UpdateRecordGroup((Group)sender);
        }

        // Свойства
        public ObservableCollection<Enrollee> Enrollees
        {
            get { return _Enrollees; }
            set { SetProperty(ref _Enrollees, value); }
        }
        public Enrollee SelectedEnrollee
        {
            get { return _SelectedEnrollee; }
            set { SetProperty(ref _SelectedEnrollee, value); }
        }
        public Enrollee BindedEnrollee
        {
            get { return _BindedEnrollee; }
            set { SetProperty(ref _BindedEnrollee, value); }
        }

        public ObservableCollection<Group> Groups
        {
            get { return _Groups; }
            set { SetProperty(ref _Groups, value); }
        }
        public Group SelectedGroup
        {
            get { return searchSetting.SelectedGroup; }
            set { SetProperty(ref searchSetting.SelectedGroup, value, ReadEnrolleeTable); }
        }
        public Group BindedGroup
        {
            get { return _BindedGroup; }
            set { SetProperty(ref _BindedGroup, value); }
        }
        public OpenedPopup OP
        {
            get { return op; }
            set { SetProperty(ref op, value); }
        }
        public MessageInfo BindedMessage
        {
            get { return _BindedMessage; }
            set { SetProperty(ref _BindedMessage, value); }
        }
        // Поиск по всем группам
        public bool AllEnrollees
        {
            get { return searchSetting.DisplayAllEnrollees; }
            set { SetProperty(ref searchSetting.DisplayAllEnrollees, value, ReadEnrolleeTable); }
        }
        // Расширенный поиск
        public bool AdvSearch
        {
            get { return searchSetting.AdvSearch; }
            set { SetProperty(ref searchSetting.AdvSearch, value, ReadEnrolleeTable); }
        }
        // Поиск
        public string SearchName
        {
            get { return searchSetting.SearchName; }
            set { SetProperty(ref searchSetting.SearchName, value, ReadEnrolleeTable); }
        }
        public bool Budget
        {
            get { return searchSetting.Budget; }
            set { SetProperty(ref searchSetting.Budget, value, ReadEnrolleeTable); }
        }
        public bool Statement
        {
            get { return searchSetting.Statement; }
            set { SetProperty(ref searchSetting.Statement, value, ReadEnrolleeTable); }
        }
        public bool Home
        {
            get { return searchSetting.Home; }
            set { SetProperty(ref searchSetting.Home, value, ReadEnrolleeTable); }
        }
        // Настройка
        public bool BudgetEnabled
        {
            get { return searchSetting.BudgetEnabled; }
            set { SetProperty(ref searchSetting.BudgetEnabled, value, ReadEnrolleeTable); }
        }
        public bool StatementEnabled
        {
            get { return searchSetting.StatementEnabled; }
            set { SetProperty(ref searchSetting.StatementEnabled, value, ReadEnrolleeTable); }
        }
        public bool HomeEnabled
        {
            get { return searchSetting.HomeEnabled; }
            set { SetProperty(ref searchSetting.HomeEnabled, value, ReadEnrolleeTable); }
        }
        public string SearchAddress
        {
            get { return searchSetting.SearchAddress; }
            set { SetProperty(ref searchSetting.SearchAddress, value, ReadEnrolleeTable); }
        }
        public string SearchPassport
        {
            get { return searchSetting.SearchPassport; }
            set { SetProperty(ref searchSetting.SearchPassport, value, ReadEnrolleeTable); }
        }
        public string SearchPrivilege
        {
            get { return searchSetting.SearchPrivilege; }
            set { SetProperty(ref searchSetting.SearchPrivilege, value, ReadEnrolleeTable); }
        }
        public string SearchCert
        {
            get { return searchSetting.SearchCert; }
            set { SetProperty(ref searchSetting.SearchCert, value, ReadEnrolleeTable); }
        }
        public string SearchSchool
        {
            get { return searchSetting.SearchSchool; }
            set { SetProperty(ref searchSetting.SearchSchool, value, ReadEnrolleeTable); }
        }

        // Команды
        // Открытие всплавыющих окон
        public RelayCommand ShowAddPopupEnrolleeCommand
        {
            get => _ShowAddPopupEnrolleeCommand ??
                (_ShowAddPopupEnrolleeCommand = new RelayCommand(obj =>
                {
                    BindedEnrollee = new Enrollee()
                    {
                        Date = new DateTime(2000, 1, 1),
                        Group = SelectedGroup,
                        AverageScore = 1.0f
                    };

                    OP = OpenedPopup.AddEnrollee;
                }));
        }
        public RelayCommand ShowEditPopupEnrolleeCommand
        {
            get => _ShowEditPopupEnrolleeCommand ??
                (_ShowEditPopupEnrolleeCommand = new RelayCommand(obj =>
                {
                    BindedEnrollee = SelectedEnrollee;
                    BindedEnrollee.PropertyChanged += UnselectRecord;
                    OP = OpenedPopup.EditEnrollee;
                }, CanClickButtonEnrollee));
        }

        // Вызывается при изменении группы у выделенной записи
        public void UnselectRecord(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Group")
            {
                SelectedEnrollee = null;
            }
        }

        public RelayCommand ShowAddPopupGroupCommand
        {
            get => _ShowAddPopupGroupCommand ??
                (_ShowAddPopupGroupCommand = new RelayCommand(obj =>
                {
                    BindedGroup = new Group();
                    OP = OpenedPopup.AddGroup;
                }));
        }
        public RelayCommand ShowEditPopupGroupCommand
        {
            get => _ShowEditPopupGroupCommand ??
                (_ShowEditPopupGroupCommand = new RelayCommand(obj =>
                {
                    BindedGroup = SelectedGroup;
                    OP = OpenedPopup.EditGroup;
                }, CanClickButtonGroup));
        }
        public RelayCommand ShowRemovePopupEnrolleeCommand
        {
            get => _ShowRemovePopupEnrolleeCommand ??
                (_ShowRemovePopupEnrolleeCommand = new RelayCommand(obj =>
                {
                    BindedMessage = _RemoveEnrolleeMessage;
                    OP = OpenedPopup.RemovePopup;
                }, CanClickButtonEnrollee));
        }
        public RelayCommand ShowRemovePopupGroupCommand
        {
            get => _ShowRemovePopupGroupCommand ??
                (_ShowRemovePopupGroupCommand = new RelayCommand(obj =>
                {
                    BindedMessage = _RemoveGroupMessage;
                    OP = OpenedPopup.RemovePopup;
                }, CanClickButtonGroup));
        }

        private bool CanClickButtonEnrollee(object o)
        {
            return SelectedEnrollee != null;
        }
        private bool CanClickButtonGroup(object o)
        {
            return SelectedGroup != null;
        }

        // Открытие главного окна
        public RelayCommand ShowMainWindow
        {
            get => _ShowMainWindow ??
                (_ShowMainWindow = new RelayCommand(obj =>
                {
                    ReadEnrolleeTable();
                    ReadGroupTable();
                    BindedEnrollee = null;
                    BindedGroup = null;
                    OP = OpenedPopup.Default;
                }));
        }

        // Кнопка добавления записи из всплывающего окна
        public RelayCommand ClickAddEnrolleeCommand
        {
            get => _ClickAddEnrolleeCommand ??
                (_ClickAddEnrolleeCommand = new RelayCommand(obj =>
                {
                    crud.CreateRecordEnrollee(BindedEnrollee);
                    ShowMainWindow.Execute(obj);
                }));
        }
        public RelayCommand ClickEditEnrolleeCommand
        {
            get => _ClickEditEnrolleeCommand ??
                (_ClickEditEnrolleeCommand = new RelayCommand(obj =>
                {
                    BindedEnrollee.PropertyChanged -= UnselectRecord;
                    ShowMainWindow.Execute(obj);
                }));
        }
        public RelayCommand ClickAddGroupCommand
        {
            get => _ClickAddGroupCommand ??
                (_ClickAddGroupCommand = new RelayCommand(obj =>
                {
                    crud.CreateRecordGroup(BindedGroup);
                    ShowMainWindow.Execute(obj);
                }));
        }
        public RelayCommand ClickRemoveCommand
        {
            get => _ClickRemoveCommand ??
                (_ClickRemoveCommand = new RelayCommand(obj =>
                {
                    if (BindedMessage.Action == MessageInfo.TypeOfMessage.RemoveEnrollee)
                    {
                        crud.DeleteRecordEnrollee(SelectedEnrollee);
                    }
                    if (BindedMessage.Action == MessageInfo.TypeOfMessage.RemoveGroup)
                    {
                        crud.DeleteRecordGroup(SelectedGroup);
                    }
                    ShowMainWindow.Execute(obj);
                    if (Groups.Count > 0 && BindedMessage.Action == MessageInfo.TypeOfMessage.RemoveGroup)
                    {
                        SelectedGroup = Groups[0];
                    }
                }));
        }
    }
}
