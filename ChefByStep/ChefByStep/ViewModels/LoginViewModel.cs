﻿namespace ChefByStep.ViewModels
{
    using System.Threading.Tasks;
    using System.Windows.Input;
    using ChefByStep.Models;
    using ChefByStep.Services.Repositories;
    using ChefByStep.Views;
    using Xamarin.Essentials;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        private UserRepository _userRepo;

        public Command LoginCommand { get; }

        public Command GuestCommand { get; }

        public ICommand TapCommand { get; }

        public Task DisplayAlert { get; private set; }

        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string password;

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public LoginViewModel()
        {
            _userRepo = new UserRepository();
            LoginCommand = new Command(OnLoginClicked);
            GuestCommand = new Command(GoToHomePage);
            TapCommand =  new Command<string>(async (url) => await Launcher.OpenAsync(url));
        }

        private async void OnLoginClicked()
        {
            User user = await _userRepo.FindUserByFirstName(Name);

            if (user.Name !=null && Password != null)
            {
                ActiveUser.ApplicationUser = user;
                Application.Current.MainPage = new AppShell();
                return;
            }

            await App.Current.MainPage.DisplayAlert("Welcome", "Wrong email or password, please try again", "Ok");
            Name = string.Empty;
            Password = string.Empty;
            Application.Current.MainPage = new LoginPage();

            //Application.Current.MainPage = new AppShell();
            //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }

        private async void GoToHomePage()
        {
            Application.Current.MainPage = new AppShell();
            //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}

    
