﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SportsTeamManager.Models
{
    public enum Position { Prop, Hooker, SecondRow, Flanker, No8, ScrumHalf, OutHalf, Centre, Wing, Fullback }
    public class Player
    {
        [Key]
        public int PlayerID { get; set; }

        [Required] 
        public string IRFUNumber { get; set; }      //Rugby registration number unique and known by each player

        [Required] 
        public string Name { get; set; }
        public Position Position { get; set; }
    }

    public class PlayerDBContext : DbContext
    {
        public PlayerDBContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<PlayerDBContext>(new DropCreateDatabaseIfModelChanges<PlayerDBContext>());      //Only for the moment, to be changed only development is complete
        }

        public DbSet<Player> Players { get; set; }
    }
}