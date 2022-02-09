using System.Collections.Generic;
using System.IO;
using GymOneBackend.Core.IServices;
using GymOneBackend.Core.Model;
using GymOneBackend.Domain.IRepositories;

namespace GymOneBackend.Domain.Services
{
  public class ExerciseService : IExerciseService
  {
    private readonly IExerciseRepository _repo;

    public ExerciseService(IExerciseRepository exerciseRepository)
    {
      if (exerciseRepository == null)
      {
        throw new InvalidDataException("Exercise repo cannot be Null");
      }
      _repo = exerciseRepository;
    }
    
    public List<Exercise> GetAllExercises()
    {
      return _repo.getAllExercises();
    }
  }
}