using System;
using GymOneBackend.Core.Model;
using Microsoft.VisualBasic;

namespace GymOneBackend.Repository.Entities
{
  public class ExerciseSetEntity
  {
    public int Id { get; set; }
    public UserEntity UserEntity { get; set; }
    public int UserEntityId { get; set; }
    public ExerciseEntity Exercise { get; set; }
    public int ExerciseId { get; set; }
    public double Weight { get; set; }
    public int  Reps { get; set; }
    public DateTime Time { get; set; }
  }
}