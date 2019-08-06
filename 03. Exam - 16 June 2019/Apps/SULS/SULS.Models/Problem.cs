using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SULS.Models
{
    public class Problem
    {
        public Problem()
        {
            this.Submissions = new HashSet<Submition>();
        }

        [Key]
        public string Id { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public int Points { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public virtual ICollection<Submition> Submissions { get; set; }
    }
}