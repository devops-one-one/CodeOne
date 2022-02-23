using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GymOneBackend.Core.Model;
using GymOneBackend.Domain.IRepositories;
using GymOneBackend.Repository.Entities;
using Microsoft.EntityFrameworkCore;
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
    
    public List<ExerciseSet> GetSetsForUserAndDate(int userId, DateTime date)
    {
      var br = _ctx.ExerciseSet.Select(e => new ExerciseSet()
        {
          UserId = e.UserEntityId,
          SetId = e.Id,
          Reps = e.Reps,
          Weight = e.Weight,
          Time = e.Time,
          ExerciseId = e.ExerciseId
        })
        .Where(m => m.UserId == userId)
        .Where(m => m.Time.Date == date.Date)
        .ToList();

      // Looking in the product of the select which is ExerciseSet Omg liturally took me like 10 sec to spot. 
      return br;
    }

    public void CreateSetExercise(List<ExerciseSet> listSets)
    {
      foreach (var set in listSets)
      {
        _ctx.ExerciseSet.Add(new ExerciseSetEntity()
        {
          UserEntityId = set.UserId,
          ExerciseId = set.ExerciseId,
          Reps = set.Reps,
          Weight = set.Weight,
          Time = set.Time,
        });
      }
    }
  }
}