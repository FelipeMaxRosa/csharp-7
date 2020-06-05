using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
  [Table("acceleration")]
  public class Acceleration
  {
    [Key]
    [Column("id")]
    [Required]
    public int Id { get; set; }

    [Column("name")]
    [Required]
    public string Name { get; set; }

    [Column("slug")]
    [Required]
    public string Slug { get; set; }
    
    [Column("created_at")]
    [Required]
    public DateTime CreatedAt { get; set; }
    
    [Column("challenge_id")]
    [Required]
    [ForeignKey("challenge_id")]
    public int ChallengeId { get; set; }

    public Challenge Challenge { get; set; }

    public List<Candidate> Candidates { get; set; }
  }
}
