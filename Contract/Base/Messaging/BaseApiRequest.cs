namespace Contract.Base.Messaging
{
    public abstract class BaseApiRequest<T> : BaseApiRequest
    {
        public string DoerId { get; set; }

        public T ViewModel { get; set; }
    }

    public abstract class BaseApiRequest
    {
    }
}