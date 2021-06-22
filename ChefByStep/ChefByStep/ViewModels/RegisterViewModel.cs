namespace ChefByStep.ViewModels
{
    using System.Threading.Tasks;

    using ChefByStep.Models;
    using ChefByStep.Services.Repositories;
    using ChefByStep.Views;

    using Xamarin.Forms;

    public class RegisterViewModel : BaseViewModel
    {
        private UserRepository _userRepo;

        public Command LoginCommand { get; }

        public Command GuestCommand { get; }

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

        public RegisterViewModel()
        {
            _userRepo = new UserRepository();
            LoginCommand = new Command(OnRegisterClicked);
            GuestCommand = new Command(GoToHomePage);
        }

        private async void OnRegisterClicked()
        {
            User user = await _userRepo.FindUserByFirstName(Name);

            if (user.Name != null && Password != null)
            {
                ActiveUser.ApplicationUser = user;
                Application.Current.MainPage = new AppShell();
                return;
            }

            await App.Current.MainPage.DisplayAlert("Welcome", "Wrong email or password, please try again", "Ok");
            Name = string.Empty;
            Password = string.Empty;
            Application.Current.MainPage = new RegisterPage();

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


