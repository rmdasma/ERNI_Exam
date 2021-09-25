using ERNI_Exam.Models;
using Prism.Navigation;
using System.Linq;

namespace ERNI_Exam.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        private UserModel user;

        public UserModel User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }

        public UserViewModel(
            INavigationService navigationService)
        : base(navigationService)
        {
            Title = "View User";
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.Any() && parameters["User"] != null)
                User = parameters["User"] as UserModel;
        }
    }
}