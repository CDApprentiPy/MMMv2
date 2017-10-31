using System;

namespace restauranter.Models
{
    public abstract class BaseEntity{}
    public class Review : BaseEntity
    {
        public int id { get; set; }
        public string reviewer { get; set; }
        public string restaurant { get; set; }
        public string review { get; set; }
        public int stars { get; set; }
        public DateTime visited { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}