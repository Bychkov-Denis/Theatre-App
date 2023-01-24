using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WPF
{
    public class Context : DbContext
    {
        public DbSet<Film> Films { get; set; } // Таблица с фильмами
        public DbSet<Session> Sessions { get; set; } // Таблица с сеансами
        public Context() // Создание базы данных
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Подключение БД
        {
            optionsBuilder.UseSqlite("Data Source=kinoteatr.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
