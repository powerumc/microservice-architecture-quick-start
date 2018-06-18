using System.ComponentModel.DataAnnotations;

namespace Powerumc.RssFeeds.Domain
{
    public class Entity
    {
        [Key]
        public long Id { get; set; }
    }
}