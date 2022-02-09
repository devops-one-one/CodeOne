using System.Collections.Generic;
using GymOneBackend.Core.IServices;
using GymOneBackend.Core.Model;
using GymOneBackend.Domain.IRepositories;
using GymOneBackend.WebAPI.Dto;
using Microsoft.AspNetCore.Mvc;

namespace GymOneBackend.WebAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ExerciseController: ControllerBase
  {
    private readonly IExerciseService _service;
    
    
    [HttpGet]
    public ActionResult<List<Exercise>> GetAllExercises()
    {
      return _service.GetAllExercises();
    }

    [HttpPost]
    public ActionResult<Exercise> CreateExercise(ExerciseDto exerciseDto)
    {
      var exercise = new Exercise()
      {
        ExerciseId = exerciseDto.Id,
        ExerciseName = exerciseDto.Name,
        MuscleGroup = exerciseDto.MuscleGroup
      };
      return _service.CreateExercise(exercise);
    }
   
  }
}