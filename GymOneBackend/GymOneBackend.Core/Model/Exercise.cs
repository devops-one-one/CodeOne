using Microsoft.VisualBasic;

namespace GymOneBackend.Core.Model
{
  public class Exercise
  {
    public int ExerciseId { get; set; }
    public string ExerciseName { get; set; }
    public Exercise ExerciseType { get; set; }
    public double Weight { get; set; }
    public int  Reps { get; set; }
    public DateAndTime Time { get; set; }
  }
}