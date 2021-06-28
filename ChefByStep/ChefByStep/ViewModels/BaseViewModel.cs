namespace ChefByStep.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using ChefByStep.Models;

    public class BaseViewModel : INotifyPropertyChanged
    {
        public ActiveUser ActiveUser
        {
            get => this.activeUser;
            set
            {
                this.activeUser = value;
                this.OnPropertyChanged(nameof(this.activeUser));
            }
        }

        public BaseViewModel()
        {
            ActiveUser = ActiveUser.GetInstance();
        }

        bool isBusy = false;

        public bool IsBusy
        {
            get
            {
                return isBusy;
            }
            set
            {
                SetProperty(ref isBusy, value);
            }
        }

        string title = string.Empty;

        private ActiveUser activeUser;

        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                SetProperty(ref title, value);
            }
        }

        protected bool SetProperty<T>(
            ref T backingStore,
            T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}