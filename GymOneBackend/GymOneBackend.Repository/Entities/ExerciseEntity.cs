namespace GymOneBackend.Repository.Entities
{
  public class ExerciseEntity
  {
    public int Id { get; set; }
    public string ExerciseName { get; set; }
    public MuscleGroupEntity MuscleGroupEntity { get; set; }
    public int MuscleGroupEntityId { get; set; }
  }
}