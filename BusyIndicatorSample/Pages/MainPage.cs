using BusyIndicatorSample.Common;
using BusyIndicatorSample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BusyIndicatorSample.Pages
{
    public class MainPage : MasterDetailPage
    {
        private bool _firstTime = true;

        private IBusyInfo busyMessage;

        public MainPage()
        {
            var flyoutPage = new ContentPage
            {
                Title = "Menu",
                Content = new StackLayout
                {
                    Children = { new Label { Text = "Menu Item 1" }, new Label { Text = "Menu Item 2" } }
                }
            };

            var detailPage = new ContentPage
            {
                Title = "Main Page",
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = { CreateShowBusyButton() }
                }
            };

            Flyout = flyoutPage;
            Detail = new NavigationPage(detailPage);
        }

        private Button CreateShowBusyButton()
        {
            var showBusyButton = new Button
            {
                Text = "Show Busy Message"
            };

            showBusyButton.Clicked += async (sender, args) =>
            {
                busyMessage = await App.ShowBusyMessageAsync("Loading, please wait...");
                await Task.Delay(5000); // Wait for 5 seconds
                App.HideBusyMessage(busyMessage);
            };

            return showBusyButton;
        }
    }
}
