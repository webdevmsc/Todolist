using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using todolist.Models.Todo;

namespace todolist.Database
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<TodoItem> TodoItems { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TodoItem>(x =>
            {
                x.Property(y => y.Added);
                x.Property(y => y.Title);
                x.Property(y => y.Content);
                x.Property(y => y.UserId);
                x.Property(y => y.Tags);
            });
            var valueComparer = new ValueComparer<List<string>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList());
            builder.Entity<TodoItem>()
                .Property(e => e.Tags)
                .HasConversion(v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.None).ToList()).Metadata.SetValueComparer(valueComparer);
            base.OnModelCreating(builder);
        }
       
    }
}