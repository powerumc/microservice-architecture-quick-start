using System;
using System.ComponentModel.DataAnnotations;

namespace Powerumc.RssFeeds.Database.Models
{
    public class RssFeedItem
    {
        [Key]
        public long Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Url { get; set; }
        
        public long Likes { get; set; }
        
        [Required]
        public DateTime CreateDate { get; set; }
        
        [Required]
        public DateTime ModifyDate { get; set; }
        
        public long RssFeedId { get; set; }
        public RssFeed RssFeed { get; set; }
    }
}