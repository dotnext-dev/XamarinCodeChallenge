
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XCC.Contracts;
using XCC.Data;
using XCC.DemoApp.Controls;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XCC.DemoApp
{
    public partial class App : Application
    {
        public App()
        {
            var mainViewModel = new MainViewModel();
            mainViewModel.InitializeFrom(SampleDataSets.Sample1);

            MainPage = new MainPage
            {
                BindingContext = mainViewModel
            };
        }
    }
}