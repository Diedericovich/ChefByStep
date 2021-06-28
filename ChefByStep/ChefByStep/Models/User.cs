namespace ChefByStep.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class User : BaseModel
    {
        public int Id { get; set; }
        public int AccountId { get; set; }

        public int RoleId { get; set; }

        public string Name { get; set; }

        public List<Recipe> CreatedRecipe { get; set; }

        private ObservableCollection<Recipe> favoriteRecipes;

        public ObservableCollection<Recipe> FavoriteRecipes
        {
            get { return favoriteRecipes; }
            set
            {
                favoriteRecipes = value;
                OnPropertyChanged(nameof(FavoriteRecipes));
            }
        }

        public List<Recipe> CompletedRecipes { get; set; }

        public List<RecipeRating> Rating { get; set; }

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