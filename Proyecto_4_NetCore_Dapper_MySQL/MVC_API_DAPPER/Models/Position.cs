using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_API_DAPPER.Models
{
    public class Position
    {
        public int PositionId { get; set; }
        public string Name { get; set; }
        public string Roll { get; set; }
        public string Message { get; set; }
    }
}
