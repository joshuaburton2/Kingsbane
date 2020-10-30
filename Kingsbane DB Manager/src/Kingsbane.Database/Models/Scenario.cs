﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kingsbane.Database.Models
{
    public class Scenario
    {
        public Scenario()
        {
            ScenarioRuleSet = new HashSet<ScenarioRuleSet>();
            Objectives = new HashSet<Objective>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Decription { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string DeploymentMapName { get; set; }
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string ObjectiveMapName { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        // Related Entities
        public int EnemyDeckId { get; set; }
        public virtual Deck EnemyDeck { get; set; }

        public int MapId { get; set; }
        public virtual Map Map { get; set; }

        public virtual ICollection<ScenarioRuleSet> ScenarioRuleSet { get; set; }
        public virtual ICollection<Objective> Objectives { get; set; }
    }
}