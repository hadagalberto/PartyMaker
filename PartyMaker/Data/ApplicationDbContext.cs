﻿using System;
using System.Collections.Generic;
using System.Text;
using Churras.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PartyMaker.Models;

namespace PartyMaker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Recurso> Recursos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Usuario>()
                .HasMany(u => u.Eventos)
                .WithOne(e => e.Usuario);
            builder.Entity<Evento>()
                .HasMany(e => e.Participantes)
                .WithOne(p => p.Evento);
            builder.Entity<Evento>()
                .HasMany(e => e.Recursos)
                .WithOne(r => r.Evento);
        }
    }
}