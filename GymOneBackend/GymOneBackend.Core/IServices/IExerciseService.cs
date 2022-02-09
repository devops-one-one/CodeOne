using System.Collections.Generic;
using GymOneBackend.Core.Model;

namespace GymOneBackend.Core.IServices
{
  public interface IExerciseService
  {
    List<Exercise> GetAllExercises();

    Exercise CreateExercise(Exercise exercise);
  }
}