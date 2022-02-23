using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymOneBackend.Core.IServices;
using GymOneBackend.Core.Model;
using GymOneBackend.WebAPI.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymOneBackend.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseSetController : ControllerBase
    {
      private readonly ISetExerciseService _service;

      public ExerciseSetController(ISetExerciseService service)
      {
        _service = service;
      }

      [HttpGet]
      public ActionResult<List<ExerciseSet>> GetExerciseSetUserDate(int userId)
      {
        if (userId != null)
        {
          // Todo for now only gets stuff from today, we can change to any date with data from the front
          return Ok(_service.GetSetsForDayAndUser(userId, DateTime.Today));
        }

        return BadRequest("missing userId");
      }

      [HttpPost]
      public void AddExerciseSets(List<AddExSetDto> listOfSetsDto)
      {
        var listModels = listOfSetsDto.Select(t => new ExerciseSet()
        {
          UserId = t.UserId,
          ExerciseId = t.ExerciseId,
          Reps = t.Reps,
          Weight = t.Weight,
          Time = t.DateTime
        }).ToList();
        _service.CreateSetExercise(listModels);
      }
    }
}