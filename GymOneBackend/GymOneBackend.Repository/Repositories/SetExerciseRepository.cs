using System.Collections.Generic;
using System.IO;
using GymOneBackend.Core.Model;
using GymOneBackend.Domain.IRepositories;
using Microsoft.VisualBasic;

namespace GymOneBackend.Repository.Repositories
{
  public class SetExerciseRepository : ISetExerciseRepository
  {
    
    private readonly MainDBContext _ctx;

    public SetExerciseRepository(MainDBContext ctx)
    {
      if (ctx == null)
      {
        throw new InvalidDataException("DbContext cannot be null");
      }
      _ctx = ctx;
    }
    
    public List<ExerciseSet> GetSetsForUserAndDate(int userId, DateAndTime date)
    {
      throw new System.NotImplementedException();
    }

    public void CreateSetExercise(List<ExerciseSet> listSets)
    {
      throw new System.NotImplementedException();
    }
  }
}