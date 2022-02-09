using System.Collections.Generic;
using System.IO;
using GymOneBackend.Core.Model;
using GymOneBackend.Domain.IRepositories;

namespace GymOneBackend.Repository.Repositories
{
  public class ExerciseRepository : IExerciseRepository
  {
    private readonly MainDBContext _ctx;

    ExerciseRepository(MainDBContext ctx)
    {
      if (ctx == null)
      {
        throw new InvalidDataException("DbContext cannot be null");
      }
      _ctx = ctx;
    }
    public List<Exercise> getAllExercises()
    {
      throw new System.NotImplementedException();
    }
  }
}