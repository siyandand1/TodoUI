using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using AutherService;

namespace LoginFlowMAUI.Pages
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly AutherService.AuthService _authService;
        private string _username;
        private string _password;
        private string _loginMessage;

        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        public string LoginMessage
        {
            get => _loginMessage;
            set
            {
                if (_loginMessage != value)
                {
                    _loginMessage = value;
                    OnPropertyChanged(nameof(LoginMessage));
                }
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel(AutherService.AuthService authService)
        {
            _authService = authService;
            LoginCommand = new Command(async () => await OnLogin());
        }

        private async Task OnLogin()
        {
            
            bool isAuthenticated = await _authService.LoginAsync(Username,Password);
            if (isAuthenticated)
            {
           
                await Application.Current.MainPage.DisplayAlert("Popup", "Login successful!", "OK");

                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Popup", "Invalid username or password.", "OK");

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
