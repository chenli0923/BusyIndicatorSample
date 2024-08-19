using BusyIndicatorSample.Common;
using BusyIndicatorSample.Services;
using BusyIndicatorSample.Views;
using BusyIndicatorSample.Pages;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BusyIndicatorSample
{
    public partial class App : Application
    {

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NCaF5cXmZCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdnWXhccnVTQmBZV0B3W0M=");
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public static async Task<IBusyInfo> ShowBusyMessageAsync(string message)
        {
            var busyInfo = DependencyService.Get<IBusyInfo>();

            await Task.Run(() =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => busyInfo?.Show(message));
            });

            return busyInfo;
        }

        public static void HideBusyMessage(IBusyInfo busyInfo)
        {
            Xamarin.Forms.Device.BeginInvokeOnMainThread(() => busyInfo?.Hide());
        }
    }
}
