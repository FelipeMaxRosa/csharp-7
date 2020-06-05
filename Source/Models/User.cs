using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Codenation.Challenge.Models
{
  [Table("user")]
  public class User
  {
    [Key]
    [Column("id")]
    [Required]
    public int Id { get; set; }
    
    [Column("full_name")]
    [Required]
    public string FullName { get; set; }

    [Column("email")]
    [Required]
    public string Email { get; set; }

    [Column("nickname")]
    [Required]
    public string NickName { get; set; }

    [Column("password")]
    [Required]
    public string Password { get; set; }

    [Column("created_at")]
    [Required]
    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Candidate> Candidates { get; set; }
    public virtual ICollection<Submission> Submissions { get; set; }
  }
}
