﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace SportsTeamManager.Models
{
    public class Availability
    {
        [Key]
        public int AvailabilityID { get; set; }

        [ForeignKey("Player")] 
        [Required]
        public int PlayerID { get; set; }
        public Player Player { get; set; }              

        [ForeignKey("Match")]
        [Required]
        public int MatchID { get; set; }
        public Match Match { get; set; }


        public bool Available { get; set; }



        public Availability(int playerId, int matchId)      //Constructor called from match constructor 
        {
            this.PlayerID = playerId;                   //Gets to here and then PlayerId is not set to instance of an object??
            this.MatchID = matchId;
        }

        public Availability()
        {

        }
    }

    public class AvailabilityDBContext : DbContext
    {

        public AvailabilityDBContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer<AvailabilityDBContext>(new CreateDatabaseIfNotExists<AvailabilityDBContext>());     
        }
        public DbSet<Availability> Availabilitys { get; set; }

        public System.Data.Entity.DbSet<SportsTeamManager.Models.Match> Matches { get; set; }

        public System.Data.Entity.DbSet<SportsTeamManager.Models.Player> Players { get; set; }
    }
}