namespace CSGizmoBox.LocalCache
{
    public class Content
    {
        public object _value { get; set; }
        public long ttl { get; set; }


        public override string ToString()
        {
            return $"Value: {_value} / TTL:{ttl}";
        }


    }
}
