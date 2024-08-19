using System;
using System.Collections.Generic;
using System.Text;

namespace BusyIndicatorSample.Common
{
    public interface IScreenSize
    {
        double GetHeight();
        double GetWidth();
        event EventHandler SizeChanged;
    }

}
