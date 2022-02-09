using Microsoft.VisualBasic;

namespace GymOneBackend.Core.Model
{
  public class Exercise
  {
    public int ExerciseId { get; set; }
    public string ExerciseName { get; set; }
    public MuscleGroup MuscleGroup { get; set; }
  }
}