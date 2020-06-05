using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
  [Table("challenge")]
  public class Challenge
  {
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("name")]
    public string Name { get; set; }

    [Required]
    [Column("slug")]
    public string Slug { get; set; }

    [Required]
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Acceleration> Accelerations { get; set; }
    public virtual ICollection<Submission> Submissions { get; set; }

  }
}
