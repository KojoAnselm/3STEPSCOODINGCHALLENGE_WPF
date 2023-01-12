using Membership.Data;
using Membership.ViewModels;
using Membership.Views;
using System.Windows;
using System.Windows.Controls;

namespace Membership
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static AppNavigationViewModel appViewModel = new(new MemberList());
        public MainWindow()
        {
            InitDB();
            InitializeComponent();
            this.DataContext = appViewModel;
        }
        public static void InitDB()
        {

            var context = new MemberDbContext();
            context.Database.EnsureCreated();
        }

    }
}
