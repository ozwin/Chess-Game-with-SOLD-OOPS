using Assignment.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Entities
{
    public class ChessPiece
    {
        public PIECE_TYPE SetType { get; set; }
        public PIECE_NAME Name { get; set; }
        public int Id { get; set; }
        public int Position { get; set; }

    }
}
