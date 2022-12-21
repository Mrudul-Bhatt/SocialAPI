using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocialAPI.Models
{
    [Table("Photos")]
    public class Photo
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public bool IsMain { get; set; }
        public string? PublicId { get; set; }

        //these are added to make sure that the photo is associated with a user 
        public int AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        // public string? Description { get; set; }
        // public DateTime DateAdded { get; set; } = DateTime.UtcNow;
    }
}