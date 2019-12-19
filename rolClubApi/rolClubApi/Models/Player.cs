using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rolClubApi.Models
{
    public class Player
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Mail { get; set; }
        public String Alias { get; set; }
        public ICollection<Play> ListPlays { get; set; }
        public ICollection<PlayerPlay> ListPlayerPlays { get; set; }
    }
}
