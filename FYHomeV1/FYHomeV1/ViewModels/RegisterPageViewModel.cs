using FYHomeV1.Models;
using FYHomeV1.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FYHomeV1.ViewModels
{
	public class RegisterPageViewModel : ViewModelBase
    {
        private string _name;
        private string _email;
        private string _birthday;
        private string _cpf;
        private string _phone;
        private string _passphrase;
        private string _confirmPassphrase;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                SetProperty(ref _name, value);
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                SetProperty(ref _email, value);
            }
        }

        public string Birthday
        {
            get { return _birthday; }
            set
            {
                _birthday = value;
                SetProperty(ref _birthday, value);
            }
        }

        public string CPF
        {
            get { return _cpf; }
            set
            {
                _cpf = value;
                SetProperty(ref _cpf, value);
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                SetProperty(ref _phone, value);
            }
        }

        public string PassPhrase
        {
            get { return _passphrase; }
            set
            {
                _passphrase = value;
                SetProperty(ref _passphrase, value);
            }
        }

        public string ConfirmPassphrase
        {
            get { return _confirmPassphrase; }
            set
            {
                _confirmPassphrase = value;
                SetProperty(ref _confirmPassphrase, value);
            }
        }

        public DelegateCommand RegisterUserCommand { get; set; }

        private readonly IPageDialogService _pageDialogService;
        private readonly INavigationService _navigationService;

        public RegisterPageViewModel(IPageDialogService pageDialogService, 
                                        INavigationService navigationService) : base(navigationService)
        {
            Title = "Cadastrar";
            this._pageDialogService = pageDialogService;
            this._navigationService = navigationService;
            RegisterUserCommand = new DelegateCommand(RegisterUser);
        }

        private async void RegisterUser()
        {
            if (PassPhrase != ConfirmPassphrase)
            {
                await this._pageDialogService.DisplayAlertAsync("Atenção", "Senhas não conferem!", "OK");
            }
            else
            {
                var user = new Person
                {
                    Name = Name,
                    Email = Email,
                    BirthdayDate = DateTime.Parse(Birthday),
                    CPF = CPF,
                    Phone = Phone,
                    Passphrase = PassPhrase
                };

                var userLogin = UserService.PostUser(user);
                if (userLogin == null)
                {
                    await this._pageDialogService.DisplayAlertAsync("Erro", "Ocorreu um erro ao registrar", "OK");
                }
                else
                {
                    await _navigationService.GoBackAsync();
                }
            }
        }
    }
}
