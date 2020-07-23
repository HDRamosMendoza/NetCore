using Microsoft.EntityFrameworkCore;
using Proyecto_1_CRUD_ASPNET_CORE_21.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_1_CRUD_ASPNET_CORE_21.Data
{
    /*IDbContext */
    public class YoutubeContext:DbContext
    {
        public YoutubeContext(DbContextOptions<YoutubeContext> options): base(options)
        {

        }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Video> Videos { get; set; }

    }
}
