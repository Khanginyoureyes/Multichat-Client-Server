using System.Configuration;
using System.Data;
using System.Windows;

namespace Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string IdCurrentUser {  get; set; }
        public static string NameCurrentUser { get; set; }
    }

}
