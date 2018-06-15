using System;
using System.ComponentModel.DataAnnotations;

namespace Powerumc.RssFeeds.Database.Models
{
    public class RssFeed
    {
        [Key]
        public long Id { get; set; }
        
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