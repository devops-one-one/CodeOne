using GymOneBackend.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymOneBackend.Repository
{
  public class MainDBContext : DbContext
  {
    public MainDBContext(DbContextOptions<MainDBContext> options): base(options)
    {
      
    }
    public DbSet<ExerciseEntity> Exercise { get; set; }
    public DbSet<MuscleGroupEntity> MuscleGroup { get; set; }
    public DbSet<ExerciseSetEntity> ExerciseSet { get; set; }
    public DbSet<UserEntity> Users { get; set; }
  }
}