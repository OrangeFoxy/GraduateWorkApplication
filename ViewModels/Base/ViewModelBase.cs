using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GraduateWorkApplication.ViewModels.Base
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        protected delegate void Callback();

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool SetProperty<T>(ref T storage, T value, Callback callback = null, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;
            storage = value;
            callback?.Invoke();
            this.OnPropertyChanged(propertyName);
            return true;
        }
    }
}
