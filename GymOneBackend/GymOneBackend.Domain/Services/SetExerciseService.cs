using System;
using System.Collections.Generic;
using System.IO;
using GymOneBackend.Core.IServices;
using GymOneBackend.Core.Model;
using GymOneBackend.Domain.IRepositories;
using Microsoft.VisualBasic;

namespace GymOneBackend.Domain.Services
{
  public class SetExerciseService : ISetExerciseService
  {
    private readonly ISetExerciseRepository _repo;

    public SetExerciseService(ISetExerciseRepository setExerciseRepository)
    {
      if (setExerciseRepository == null)
      {
        throw new InvalidDataException("SetExercise repo cannot be Null");
      }
      _repo = setExerciseRepository;
    }
    
    public List<ExerciseSet> GetSetsForDayAndUser(int userId, DateTime date)
    {
      return _repo.GetSetsForUserAndDate(userId, date);
    }

    public void CreateSetExercise(List<ExerciseSet> listSets)
    {
      _repo.CreateSetExercise(listSets);
    }
  }
}