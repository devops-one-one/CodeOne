namespace GymOneBackend.Core.Model
{
  public class ExerciseSet
  {
    public int SetId { get; set; }
    public int UserId { get; set; }
    public MuscleGroup MuscleGroup { get; set; }
  }
}