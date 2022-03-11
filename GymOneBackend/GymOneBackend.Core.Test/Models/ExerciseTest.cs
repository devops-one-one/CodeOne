using GymOneBackend.Core.Model;
using Xunit;

namespace GymOneBackend.Core.Test.Models
{
    public class ExerciseTest
    {
        private Exercise _exercise;
        [Fact]
        public void Test1()
        {
            _exercise = new Exercise();
        }
        
        [Fact]
        public void CustomerDetailClass_Exists()
        {
            Assert.NotNull(_exercise);
        }
        
        [Fact]
        public void ExerciseClass_HasId_WithTypeInt()
        {
            var expected = 1;
            _exercise.ExerciseId = 1;
            Assert.Equal(expected, _exercise.ExerciseId);
            Assert.True(_exercise.ExerciseId is int);
        }
    }
}