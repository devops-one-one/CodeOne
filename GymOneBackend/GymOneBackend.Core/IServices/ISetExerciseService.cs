using System;
using System.Collections.Generic;
using GymOneBackend.Core.Model;
using Microsoft.VisualBasic;

namespace GymOneBackend.Core.IServices
{
  public interface ISetExerciseService
  {
    List<ExerciseSet> GetSetsForDayAndUser(int userId, DateTime date);
    void CreateSetExercise(List<ExerciseSet> listSets);
  }
}