using ChefByStep.Models;
using ChefByStep.Services.Repositories;
using ChefByStep.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChefByStep.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private UserRepository _userRepo;
        
        public Command LoginCommand { get; }
        public Command GuestCommand { get; }

        public Task DisplayAlert { get; private set; }

        private string name;

        public string Name
        {
            get { return name; }
            set { 
                name = value;
                OnPropertyChanged(nameof(Name));
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

        private async void OnLoginClicked()
        {
            User user = await _userRepo.FindUserByFirstName(Name);

            if (user.Name !=null)
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
