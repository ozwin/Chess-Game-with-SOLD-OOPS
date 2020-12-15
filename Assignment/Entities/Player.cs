using Assignment.Constants;
using Assignment.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Entities
{
    public class Player : User<int>, IPlayer<int>
    {
        public PIECE_TYPE SetName { get; set; }
    }
}
