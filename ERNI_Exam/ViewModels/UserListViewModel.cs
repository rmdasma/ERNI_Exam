using ERNI_Exam.Models;
using ERNI_Exam.Services;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ERNI_Exam.ViewModels
{
    public class UserListViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IUserService _userService;
        private ObservableCollection<UserModel> _userList;
        public ObservableCollection<UserModel> UserList
        {
            get { return _userList; }
            set { SetProperty(ref _userList, value); }
        }

        public DelegateCommand<UserModel> SelectUserCommand { get; private set; }

        public UserListViewModel(
            INavigationService navigationService,
            IUserService userService)
        : base(navigationService)
        {
            _navigationService = navigationService;
            _userService = userService;
            Title = "User List";
            UserList = new ObservableCollection<UserModel>();
            SelectUserCommand = new DelegateCommand<UserModel>(SelectUser);
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            await GetUsers();
        }

        private async Task GetUsers()
        {
            var result = await _userService.GetUsers();
            if (result.Any())
            {
                UserList = new ObservableCollection<UserModel>(result);
            }
        }

        private async void SelectUser(UserModel selectedUser)
        {
            var navigationParams = new NavigationParameters
            {
                { "User", selectedUser }
            };
            _ = await _navigationService.NavigateAsync("UserView", navigationParams);
        }
    }
}