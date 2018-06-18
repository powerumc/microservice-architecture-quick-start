using System;
using System.ComponentModel.DataAnnotations;
using Powerumc.RssFeeds.Domain;

namespace Powerumc.RssFeeds.Database.Models
{
    public class RssFeed : Entity
    {
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Url { get; set; }
        
        [Required]
        public DateTime CreateDate { get; set; }
        
        [Required]
        public DateTime ModifyDate { get; set; }
    }
}