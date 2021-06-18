namespace ChefByStep.ViewModels
{
    using ChefByStep.Models;
    using ChefByStep.Services.Repositories;

    using Xamarin.Essentials;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        private UserRepository _userRepo;

        public Command LoginCommand { get; }

        public Command GuestCommand { get; }

        private string firstName;

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
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
        }

        private async void OnLoginClicked(object obj)
        {
            User tempuser = await _userRepo.GetUser(1);

            if (_userRepo.GetUser(1) == null)
            {
                await Application.Current.MainPage.DisplayAlert("Login Failed", "Id or Password incorrect", "OK");
            }
            else
            {
                await SecureStorage.SetAsync("isLogged", "1");
                Application.Current.MainPage = new AppShell();
            }
        }

        private async void GoToHomePage()
        {
            Application.Current.MainPage = new AppShell();
            //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}

    
