using System;
using Microsoft.VisualBasic;

namespace GymOneBackend.Core.Model
{
  public class ExerciseSet
  {
    public int SetId { get; set; }
    public int UserId { get; set; }
    public int ExerciseId { get; set; }
    public double Weight { get; set; }
    public int  Reps { get; set; }
    public DateTime Time { get; set; }
  }
}