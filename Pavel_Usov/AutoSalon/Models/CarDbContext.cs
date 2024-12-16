using System.Collections.Generic;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace AutoSalon.Models
{
    public class CarDbContext: DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Auto> Autos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auto>(entity =>
            {
                entity.HasKey(a => a.IdAuto);
                entity.HasOne(a => a.User) // Измените здесь
                .WithMany(u => u.Autos)
                .HasForeignKey(a => a.IdUser)
                .IsRequired(); // Укажите, что связь обязательная
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(a => a.IdUser);
            });
        }

        public async Task<List<Auto>> GetAllAutoAsync()
        {
            List<Auto> AllAuto = new List<Auto>();

            // Получаем данные из всех таблиц

            var autoRecord = await Autos.ToListAsync();

            // Заполняем список таблиц
            foreach (var auto in autoRecord)
            {
                AllAuto.Add(auto);
            }       

            return AllAuto;
        }

        public async Task<List<Users>> GetAllUserAsync()
        {
            List<Users> AllUser = new List<Users>();

            // Получаем данные из всех таблиц

            var userRecord = await Users.ToListAsync();

            // Заполняем список таблиц
            foreach (var user in userRecord)
            {
                AllUser.Add(user);
            }

            return AllUser;
        }

        public async Task<Users> FoundUserSever(int IdUser)
        {
            var user = await Users.SingleOrDefaultAsync(u => u.IdUser == IdUser);

            return user;
        }
    }
}
