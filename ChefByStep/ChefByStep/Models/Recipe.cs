namespace ChefByStep.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class Recipe : BaseModel
    {
        public int Id { get; set; }
        public int CategoryID { get; set; }
        public string CreatedByUser { get; set; }
        public int PrepTimeInMin { get; set; }
        public int CookTimeInMin { get; set; }
        public string CookingTime { get; set; }
        public int AverageRating { get; set; }

        public string Description { get; set; }

        public List<RecipeRating> Ratings { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public List<RecipeIngredient> Ingredients { get; set; }

        public List<Step> Steps { get; set; }
        private bool isFavorited;

        public bool IsFavorited
        {
            get { return isFavorited; }
            set
            {
                isFavorited = value;
                OnPropertyChanged(nameof(IsFavorited));
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

        #endregion INotifyPropertyChanged
    }
}