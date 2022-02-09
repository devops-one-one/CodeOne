using System.Collections.Generic;
using GymOneBackend.Core.Model;

namespace GymOneBackend.Domain.IRepositories
{
  public interface IExerciseRepository
  {
    List<Exercise> getAllExercises();
  }
}