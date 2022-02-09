using System.Collections.Generic;
using GymOneBackend.Core.Model;
using Microsoft.VisualBasic;

namespace GymOneBackend.Domain.IRepositories
{
  public interface ISetExerciseRepository
  {
    List<ExerciseSet> GetSetsForUserAndDate(int userId, DateAndTime date);
  }
}