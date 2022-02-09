using GymOneBackend.Core.Model;
using Microsoft.VisualBasic;

namespace GymOneBackend.Repository.Entities
{
  public class ExerciseSetEntity
  {
    public int SetId { get; set; }
    public int UserId { get; set; }
    public ExerciseEntity Exercise { get; set; }
    public int ExerciseId { get; set; }
    public double Weight { get; set; }
    public int  Reps { get; set; }
    public DateAndTime Time { get; set; }
  }
}