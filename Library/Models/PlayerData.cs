using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Library.Models
{
    public class PlayerData
    {
        [Required]
        [StringLength(25, ErrorMessage = "Name is too long.")]
        public string PlayerName { get; set; }

        [Required]
        public string CharacterId { get; set; }
    }
}
