using System.Windows.Controls;

namespace Membership
{
    public class AppNavigationViewModel : ViewModelBase
    {
        private UserControl activeWindow;
        public UserControl ActiveWindow
        {
            get { return activeWindow; }
            set { SetProperty(ref activeWindow, value); }
        }

        public AppNavigationViewModel(UserControl element)
        {

            activeWindow = element;
        }
    }
}

