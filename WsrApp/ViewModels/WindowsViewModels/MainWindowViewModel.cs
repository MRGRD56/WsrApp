using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WsrApp.Model;
using WsrApp.Views.Pages;

namespace WsrApp.ViewModels.WindowsViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private string _pageTitle;
        private bool _isAuthorized;
        private User _currentUser;
        private string _currentUserPhoto;
        private bool _canGoBack;
        private bool _isMenuFullMode = false;

        public string PageTitle
        {
            get => _pageTitle;
            set
            {
                _pageTitle = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(WindowTitle));
            }
        }

        public string WindowTitle => $"АБвГДЕ - {PageTitle}";

        public bool IsAuthorized
        {
            get => _isAuthorized;
            set
            {
                _isAuthorized = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsNotAuthorized));
            }
        }

        public bool IsNotAuthorized => !IsAuthorized;

        public bool CanGoBack
        {
            get => _canGoBack;
            set
            {
                _canGoBack = value;
                OnPropertyChanged();
            }
        }

        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged();
            }
        }

        public string CurrentUserPhoto
        {
            get => _currentUserPhoto;
            set
            {
                _currentUserPhoto = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel()
        {
            Account.LoggedIn += Account_LoggedIn;
            Account.LoggedOut += Account_LoggedOut;
            if (Navigation.Frame == null) return;
            Navigation.Frame.Navigated += Frame_Navigated;
            Navigation.NavigateNew<LoginPage>();
        }

        private void Account_LoggedIn()
        {
            CurrentUser = Account.User;
            CurrentUserPhoto = Account.Photo;
            IsAuthorized = true;
            Navigation.ClearBackStack();
        }

        private void Account_LoggedOut()
        {
            CurrentUser = null;
            CurrentUserPhoto = null;
            IsAuthorized = false;
        }

        private Page _previousPage;

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            var page = (Page)e.Content;
            PageTitle = page.Title;
            CanGoBack = Navigation.Frame.CanGoBack 
                && page is not LoginPage 
                && _previousPage is not LoginPage;
            _previousPage = page;
        }

        public bool IsMenuFullMode
        {
            get => _isMenuFullMode;
            set
            {
                _isMenuFullMode = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsMenuMiniMode));
            }
        }

        public bool IsMenuMiniMode => !IsMenuFullMode;

        public Command ToggleMenuModeCommand => new(_ =>
        {
            IsMenuFullMode = !IsMenuFullMode;
        });

        public Command LogoutCommand => new(_ => 
        {
            var mbox = MessageBox.Show("Выйти из учётной записи?", "Выход", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (mbox != MessageBoxResult.OK) return;

            Account.Logout();
            Navigation.NavigateNew<LoginPage>();
            Navigation.ClearBackStack();
        });
    }
}
