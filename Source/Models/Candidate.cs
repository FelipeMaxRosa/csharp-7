using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
  [Table("candidate")]
  public class Candidate
  {
    [ForeignKey("User")]
    [Column("user_id", Order = 1)]
    public int UserId { get; set; }
    public virtual User User { get; set; }

    [ForeignKey("Acceleration")]
    [Column("acceleration_id", Order = 2)]
    public int AccelerationId { get; set; }
    public virtual Acceleration Acceleration { get; set; }

    [ForeignKey("Company")]
    [Column("company_id", Order = 3)]
    public int CompanyId { get; set; }
    public virtual Company Company { get; set; }

    [Required]
    [Column("status")]
    public int Status { get; set; }

    [Required]
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
    
  }
}
