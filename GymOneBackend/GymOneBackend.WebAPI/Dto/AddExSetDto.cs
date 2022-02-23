using System;

namespace GymOneBackend.WebAPI.Dto
{
  public class AddExSetDto
  {
    public int UserId { get; set; }
    public int ExerciseId { get; set; }
    public double Weight { get; set; }
    public int Reps { get; set; }
    public DateTime DateTime { get; set; }
  }
}