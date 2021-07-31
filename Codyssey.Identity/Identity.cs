using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Codyssey.Identity
{
    /// <summary>
    /// Entity framework record type.
    /// </summary>
    [Index(nameof(Context), IsUnique=true)]
    public class Identity
    {
        [Key]
        [Required]
        public long ID { get; set; }

        [Required]
        public string Context { get; set; }

        [Required]
        public long NextID { get; set; }
    }
}
