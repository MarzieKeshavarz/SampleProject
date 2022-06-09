using Common.Enums;

namespace Contract.Base.Model
{
    public class Message
    {
        public string Title { get; set; }

        public string Body { get; set; }

        public MessageType Type { get; set; }
    }
}
