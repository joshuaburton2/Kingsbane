﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kingsbane.Database.Models
{
    public class CardUnit
    {
        public CardUnit()
        {
            Abilities = new HashSet<Ability>();
            UnitKeywords = new HashSet<UnitKeyword>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey(nameof(Card))]
        public int CardId { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string UnitTag { get; set; }

        public int Attack { get; set; }
        public int Health { get; set; }
        public int Protected { get; set; }
        public int Range { get; set; }
        public int Speed { get; set; }
        public int Empowered { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        // Related Entities

        public virtual Card Card { get; set; }              // Primary Client

        public virtual ICollection<Ability> Abilities { get; set; }
        public virtual ICollection<UnitKeyword> UnitKeywords { get; set; }
    }
}
