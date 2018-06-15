using System;

namespace Powerumc.RssFeeds
{
    public class TraceId
    {
        private readonly Guid _guid;
        
        private TraceId() { }

        private TraceId(Guid guid)
        {
            _guid = guid;
        }

        public static TraceId New()
        {
            return new TraceId(Guid.NewGuid());
        }

        public static TraceId New(Guid guid)
        {
            if (guid == Guid.Empty) 
                throw new ArgumentException(nameof(guid));
            
            return new TraceId(guid);
        }

        public override string ToString()
        {
            return _guid.ToString();
        }
    }
}