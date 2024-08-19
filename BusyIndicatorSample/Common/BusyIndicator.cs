using BusyIndicatorSample.Common;
using Syncfusion.SfBusyIndicator.XForms;
using Syncfusion.XForms.PopupLayout;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(BusyIndicator))]
namespace BusyIndicatorSample.Common
{
    public class BusyIndicator : IBusyInfo
    {
        private SfBusyIndicator _busyIndicator;
        private SfPopupLayout _popupLayout;
        private IScreenSize _screenSize;

        public BusyIndicator()
        {
            _screenSize = DependencyService.Get<IScreenSize>();

            if (_screenSize != null)
            {
                _screenSize.SizeChanged += OnSizeChanged;
            }

            InitializePopupLayout();
        }

        private void InitializePopupLayout()
        {
            _busyIndicator = new SfBusyIndicator
            {
                AnimationType = AnimationTypes.HorizontalPulsingBox,
                ViewBoxWidth = 100,
                ViewBoxHeight = 100,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                TitlePlacement = TitlePlacement.Bottom,
                TextColor = Color.Blue
            };

            var displayInfo = DeviceDisplay.MainDisplayInfo;

            _popupLayout = new SfPopupLayout
            {
                PopupView =
                {
                    BackgroundColor = Color.FromRgba(0, 0, 0, 0.1),
                    ShowHeader = false,
                    ShowCloseButton = false,
                    ShowFooter = false,
                    IsFullScreen = true,
                    ContentTemplate = new DataTemplate(() =>
                    {
                        var grid = new Grid
                        {
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalOptions = LayoutOptions.Center
                        };
                        grid.Children.Add(_busyIndicator);
                        return grid;
                    })
                }
            };
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                _popupLayout.PopupView.HeightRequest = _screenSize.GetHeight();
                _popupLayout.PopupView.WidthRequest = _screenSize.GetWidth();
            });
        }

        public void Show(string text)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                _busyIndicator.Title = text;
                _popupLayout.IsOpen = true;
            });
        }

        public void Update(string text)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                _busyIndicator.Title = text;
            });
        }

        public void Hide()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                _popupLayout.IsOpen = false;
            });
        }
    }
}
