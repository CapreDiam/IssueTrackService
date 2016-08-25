namespace ITS.Model.Event
{
    public interface IListener
    {
        void Callback(string msg);
    }
}