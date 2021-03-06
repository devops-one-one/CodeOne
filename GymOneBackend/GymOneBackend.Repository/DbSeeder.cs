using System;
using System.Collections.Generic;
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

        public void SeedDevelopment(int boo)
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();

            var chest = _ctx.MuscleGroup
                .Add(new MuscleGroupEntity {MuscleGroupName = "the chest"}).Entity;
            
            var shoul = _ctx.MuscleGroup
                .Add(new MuscleGroupEntity {MuscleGroupName = "the shoulders"}).Entity;

            //_ctx.SaveChanges();
            
            var chestEx = CreateExercise(chest);
            var shoulEx = CreateExercise(shoul);

            //_ctx.SaveChanges();

            _ctx.Users.Add(new UserEntity() {Id = 1, Email = "@yourMom"});

            _ctx.SaveChanges();

            _ctx.ExerciseSet.Add(new ExerciseSetEntity{Exercise = chestEx[0], Reps = 7, UserEntityId = 1, Weight = 20.0, Time = DateTime.Now});
            _ctx.ExerciseSet.Add(new ExerciseSetEntity{Exercise = chestEx[1], Reps = 7, UserEntityId = 1, Weight = 20.0, Time = DateTime.Now});
            _ctx.ExerciseSet.Add(new ExerciseSetEntity{Exercise = shoulEx[0], Reps = 7, UserEntityId = 1, Weight = 20.0, Time = DateTime.Now});
            _ctx.ExerciseSet.Add(new ExerciseSetEntity{Exercise = shoulEx[1], Reps = 7, UserEntityId = 1, Weight = 20.0, Time = DateTime.Now});

            _ctx.SaveChanges();
        }

        private List<ExerciseEntity> CreateExercise(MuscleGroupEntity mG)
        {
            var list = new List<ExerciseEntity>();
            list
                .Add(_ctx.Exercise
                    .Add(new ExerciseEntity
                    {ExerciseName = "Exercise 1", MuscleGroupEntity = mG}).Entity);
            list.Add(_ctx.Exercise.Add(new ExerciseEntity
                {ExerciseName = "Exercise 2", MuscleGroupEntity = mG}).Entity);
            return list;
        }

        public  void SeedDevelopment()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();
            
            
            _ctx.Users.Add(new UserEntity() {Id = 1, Email = "@yourMom"});

            _ctx.SaveChanges();

            var muscleGroups = CreateMuscleGroups();
            foreach (var musclee in muscleGroups)
            {
                _ctx.MuscleGroup.Add(musclee);
            }

            _ctx.SaveChanges();

            var chestExercises = CreateChestExercies(muscleGroups[0]);
            var armExercies = CreateArmExercies(muscleGroups[3]);
            

            var exercise = new [] {chestExercises, armExercies};
            
            var exerciseSetEntities = new ExerciseSetEntity[GetLength(exercise)]; // chestExercises.Length+armExercies.Length
            for (int i = 0, k=0; i < exercise.Length; i++)
            {
                for (var j = 0; j < exercise[i].Length; j++)
                {
                    _ctx.Exercise.Add(exercise[i][j]);
                    exerciseSetEntities[k++] = new ExerciseSetEntity
                    {
                        Reps = new Random().Next(2, 5), // [2; 5)
                        Exercise = exercise[i][j],
                        Weight = new Random().Next(30, 90), // weight between [30; 90)
                        Time = DateTime.Now,
                        UserEntityId = 1
                    };
                }
            }

            foreach (var exerciseSet in exerciseSetEntities)
            {
                _ctx.ExerciseSet.Add(exerciseSet);
            }
            
            _ctx.SaveChanges();
        }
        

        private int GetLength(ExerciseEntity[][] exercise)
        {
            var res = 0;
            for (int i = 0; i < exercise.Length; i++)
            {
                res += exercise[i].Length;
            }

            return res;
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
                new MuscleGroupEntity {MuscleGroupName = "the chest"},
                new MuscleGroupEntity {MuscleGroupName = "the shoulders"},
                new MuscleGroupEntity {MuscleGroupName = "the back"},
                new MuscleGroupEntity {MuscleGroupName = "the arms"},
                new MuscleGroupEntity {MuscleGroupName = "the abs"},
                new MuscleGroupEntity {MuscleGroupName = "the legs"},
            };
        }
    }
}