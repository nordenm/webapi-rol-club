using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rolClubApi.Models
{
    public class PlayerPlay
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int PlayId { get; set; }
        public Play Play { get; set; }
    }
}
