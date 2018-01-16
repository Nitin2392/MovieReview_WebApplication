using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieReview_Website_Adv_DotNet.Models
{
    public class Movie
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string Review { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int RatingScore { get; set; }
        //public bool IsUserWatched { get; set; }

        public virtual int CategoryId { get; set; }
        public virtual MovieCategory Category { get; set; }

    }
}