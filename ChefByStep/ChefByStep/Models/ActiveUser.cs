using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ChefByStep.Models
{
    public class ActiveUser
    {
        private User applicationUser;

        public User ApplicationUser
        {
            get { return applicationUser; }
            set
            {
                applicationUser = value;
                OnPropertyChanged(nameof(ApplicationUser));
            }
        }

        private static ActiveUser Instance { get; set; }

        private ActiveUser()
        {
        }

        public static ActiveUser GetInstance()
        {
            return Instance ?? (Instance = new ActiveUser());
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

        #endregion INotifyPropertyChanged
    }
}