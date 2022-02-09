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
        throw new InvalidDataException("Exercise repo cannot be Null");
      }
      _repo = setExerciseRepository;
    }
    
    public List<ExerciseSet> GetSetsForDayAndUser(int userId, DateAndTime date)
    {
      return _repo.GetSetsForUserAndDate(userId, date);
    }
  }
}