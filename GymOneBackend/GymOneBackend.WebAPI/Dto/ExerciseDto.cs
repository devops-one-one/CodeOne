using GymOneBackend.Core.Model;

namespace GymOneBackend.WebAPI.Dto
{
    public class ExerciseDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public MuscleGroup MuscleGroup { get; set; }
    }
}