using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Backend.Models;


namespace Backend.Models
{
    public class TodoContext : DbContext
        {
        public DbSet<Furniture> Furnitures { get; set; }//помогают получать из БД набор данных определенного тип
        public DbSet<Order> Orders { get; set; }//Фактически каждое свойство DbSet будет соотноситься с отдельной таблицей в базе данных
        public DbSet<Backend.Models.User> User { get; set; }
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
           // Database.EnsureDeleted();
            Database.EnsureCreated();//при отсутствии базы данных автоматически создает ее
        }
    }
}
