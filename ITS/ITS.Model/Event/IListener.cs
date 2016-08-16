namespace ITS.Model.Event
{
    public interface IListener
    {
        void callback(string msg);
    }
}