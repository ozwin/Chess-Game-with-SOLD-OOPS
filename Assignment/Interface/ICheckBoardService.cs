using Assignment.Constants;
using Assignment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Interface
{
    public interface IChessBoardService
    {
        bool MovePiece(ChessPiece piece);
        void DisplayBoard();
        void DisplayBoard(PIECE_TYPE currentSet);
        ChessPiece CheckSetType(int pieceId);
    }
}
