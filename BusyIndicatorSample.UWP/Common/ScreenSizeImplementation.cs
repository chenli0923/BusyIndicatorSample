using BusyIndicatorSample.Common;
using BusyIndicatorSample.UWP.Common;
using System;
using Windows.UI.Xaml;
using Xamarin.Forms;

[assembly: Dependency(typeof(ScreenSizeImplementation))]
namespace BusyIndicatorSample.UWP.Common
{
    public class ScreenSizeImplementation : IScreenSize
    {
        public event EventHandler SizeChanged;

        public ScreenSizeImplementation()
        {
            Window.Current.SizeChanged += OnSizeChanged;
        }

        private void OnSizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            SizeChanged?.Invoke(this, EventArgs.Empty);
        }

        public double GetHeight()
        {
            return Window.Current.Bounds.Height;
        }

        public double GetWidth()
        {
            return Window.Current.Bounds.Width;
        }
    }
}
