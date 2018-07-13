using FYHomeV1.Models;
using FYHomeV1.Services;
using FYHomeV1.Utils;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FYHomeV1.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {       

        private string _email;
        private string _passphrase;
        private string _message;


        public string Email
        {
            get { return _email; }
            set
            {
                SetProperty(ref _email, value);
            }
        }
        public string PassPhrase
        {
            get { return _passphrase; }
            set
            {
                SetProperty(ref _passphrase, value);
            }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                SetProperty(ref _message, value);
            }
        }

        public DelegateCommand LoginCommand { get; set; }
        public DelegateCommand RegisterCommand { get; set; }

        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Login";
            this._navigationService = navigationService;
            this.LoginCommand = new DelegateCommand(Login);
            this.RegisterCommand = new DelegateCommand(RegisterAsync);
        }

        private async void RegisterAsync()
        {
            await this._navigationService.NavigateAsync("NavigationPage/RegisterPage");
        }

        private async void Login()
        {
            var user = new Person
            {
                Email = Email,
                Passphrase = PassPhrase
            };

            var userLogin = UserService.GetUser(user);
            if (userLogin == null)
            {
                Message = "Dados de login incorretos";
            }
            else
            {
                UserUtil.SetUserLogin(userLogin);


            }
        }

        //public event PropertyChangedEventHandler PropertyChanged;
    }
}
