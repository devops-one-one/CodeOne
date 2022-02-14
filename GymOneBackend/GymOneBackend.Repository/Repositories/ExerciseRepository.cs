using System.Collections.Generic;
using System.IO;
using System.Linq;
using GymOneBackend.Core.Model;
using GymOneBackend.Domain.IRepositories;

namespace GymOneBackend.Repository.Repositories
{
  public class ExerciseRepository : IExerciseRepository
  {
    private readonly MainDBContext _ctx;

    public ExerciseRepository(MainDBContext ctx)
    {
      if (ctx == null)
      {
        throw new InvalidDataException("DbContext cannot be null");
      }
      _ctx = ctx;
    }
    public List<Exercise> getAllExercises()
    {
      return _ctx.Exercise
        .Select(e => new Exercise()
        {
          ExerciseId = e.Id,
          ExerciseName = e.ExerciseName,
          MuscleGroup = new MuscleGroup()
            {
              Id = e.MuscleGroupEntity.Id,
              MuscleGroupId = e.MuscleGroupEntity.MuscleGroupName
            }
        }).ToList();
    }
  }
}