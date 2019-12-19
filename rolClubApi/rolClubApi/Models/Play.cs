using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rolClubApi.Models
{
    public class Play
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime DateTime { get; set; }
        public String Difficulty { get; set; }
        public String Game { get; set; }
        public int CreatorId { get; set; }
        public Player Creator { get; set; }
        public ICollection<PlayerPlay> ListPlayers { get; set; }
    }
}
