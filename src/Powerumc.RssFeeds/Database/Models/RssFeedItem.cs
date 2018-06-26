using System;
using System.ComponentModel.DataAnnotations;
using Powerumc.RssFeeds.Domain;

namespace Powerumc.RssFeeds.Database.Models
{
    public class RssFeedItem : Entity
    {
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Url { get; set; }
        
        public long Likes { get; set; }
        
        [Required]
        public DateTime CreatedDate { get; set; }
        
        [Required]
        public DateTime ModifiedDate { get; set; }
        
        public long RssFeedId { get; set; }
        public RssFeed RssFeed { get; set; }
    }
}