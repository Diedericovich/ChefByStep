using ChefByStep.Services.Repositories;
using ChefByStep.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChefByStep.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private UserRepository _userRepo;
        
        public Command LoginCommand { get; }
        public Command GuestCommand { get; }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { 
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { 
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public LoginViewModel()
        {
            _userRepo = new UserRepository();
            LoginCommand = new Command(OnLoginClicked);
            GuestCommand = new Command(GoToHomePage);
        }

        private async void OnLoginClicked(object obj)
        {
            //check for user
            Application.Current.MainPage = new AppShell();
            //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }

        private async void GoToHomePage()
        {
            Application.Current.MainPage = new AppShell();
            //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
