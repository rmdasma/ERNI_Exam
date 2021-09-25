using ERNI_Exam.Services;
using ERNI_Exam.ViewModels;
using ERNI_Exam.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using Xamarin.Forms;

namespace ERNI_Exam
{
    public partial class App : PrismApplicationBase
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override IContainerExtension CreateContainerExtension()
        {
            return new UnityContainerExtension();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            _ = await NavigationService.NavigateAsync("NavigationPage/UserListView");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IUserService, UserService>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<UserListView, UserListViewModel>();
            containerRegistry.RegisterForNavigation<UserView, UserViewModel>();
        }
    }
}