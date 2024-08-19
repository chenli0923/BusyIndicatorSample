namespace BusyIndicatorSample.Common
{
    public interface IBusyInfo
    {
        void Show(string Text);
        void Update(string Text);
        void Hide();
    }
}
