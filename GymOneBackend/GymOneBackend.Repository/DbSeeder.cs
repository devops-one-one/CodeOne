using System;
using GymOneBackend.Repository.Entities;

namespace GymOneBackend.Repository
{
    public class DbSeeder
    {
        private  readonly MainDBContext _ctx;
        
        public DbSeeder(MainDBContext ctx)
        {
            _ctx = ctx;
        }

        public  void SeedDevelopment()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();

            var muscleGroups = CreateMuscleGroups();
            foreach (var musclee in muscleGroups)
            {
                _ctx.MuscleGroup.Add(musclee);
            }

            var chestExercises = CreateChestExercies(muscleGroups[0]);
            var armExercies = CreateArmExercies(muscleGroups[3]);

            var exercise = new ExerciseEntity[][] {chestExercises, armExercies};
            ExerciseSetEntity[] exerciseSetEntities = new ExerciseSetEntity[exercise.Length];
            for (int i = 0, k=0; i < exercise.Length; i++)
            {
                for (int j = 0; j < exercise[i].Length; j++)
                {
                    var exercise1 = exercise[i][j];
                    _ctx.Exercise.Add(exercise1);
                    exerciseSetEntities[k++] = new ExerciseSetEntity
                    {
                        Reps = new Random().Next(2, 5), // [2; 5)
                        Exercise = exercise1,
                        Weight = new Random().Next(30, 90),
                        //idk what dates
                    };
                }
            }

            foreach (var exerciseSet in exerciseSetEntities)
            {
                _ctx.ExerciseSet.Add(exerciseSet);
            }
            
            _ctx.SaveChanges();
        }
        
        private ExerciseEntity[] CreateArmExercies(MuscleGroupEntity muscleGroup)
        {
            return new[]
            {
                new ExerciseEntity {ExerciseName = "Bench press", MuscleGroupEntity = muscleGroup},
                new ExerciseEntity {ExerciseName = "Bent-over row", MuscleGroupEntity = muscleGroup},
                new ExerciseEntity {ExerciseName = "Incline dumbbell flye", MuscleGroupEntity = muscleGroup},
                new ExerciseEntity {ExerciseName = "Lat pull-down", MuscleGroupEntity = muscleGroup},
                new ExerciseEntity {ExerciseName = "Dumbbell pull-over", MuscleGroupEntity = muscleGroup},
            };
        }

        private ExerciseEntity[] CreateChestExercies(MuscleGroupEntity muscleGroup)
        {
            return new[]
            {
                new ExerciseEntity {ExerciseName = "BARBELL BENCH PRESS", MuscleGroupEntity = muscleGroup},
                new ExerciseEntity {ExerciseName = "DUMBBELL INCLINE PRESS", MuscleGroupEntity = muscleGroup},
                new ExerciseEntity {ExerciseName = "BARBELL INCLINE BENCH PRESS", MuscleGroupEntity = muscleGroup},
                new ExerciseEntity {ExerciseName = "WEIGHTED DIPS (CHEST VERSION)", MuscleGroupEntity = muscleGroup},
                new ExerciseEntity {ExerciseName = "FLAT DUMBBELL PRESS", MuscleGroupEntity = muscleGroup},
            };
        }

        private MuscleGroupEntity[] CreateMuscleGroups()
        {
            return new[]
            {
                new MuscleGroupEntity {MuscleGroupId = "the chest"},
                new MuscleGroupEntity {MuscleGroupId = "the shoulders"},
                new MuscleGroupEntity {MuscleGroupId = "the back"},
                new MuscleGroupEntity {MuscleGroupId = "the arms"},
                new MuscleGroupEntity {MuscleGroupId = "the abs"},
                new MuscleGroupEntity {MuscleGroupId = "the legs"},
            };
        }
    }
}