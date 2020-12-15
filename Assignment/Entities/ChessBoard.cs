using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Entities
{
    public class ChessBoard
    {
        /// public List<ChessPiece> WhiteSet { get; set; }
        // public List<ChessPiece> BlackSet { get; set; }
          public List<ChessPiece> Pieces { get; set; }
          public ChessPiece[][] PieceSet { get; set; } 

    }
}
