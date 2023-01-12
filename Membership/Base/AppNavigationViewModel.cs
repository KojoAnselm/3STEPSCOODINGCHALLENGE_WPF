using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

