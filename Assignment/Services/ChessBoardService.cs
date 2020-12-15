using Assignment.Constants;
using Assignment.Entities;
using Assignment.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Services
{
    public class ChessService : IChessBoardService
    {
        private ChessBoard _chessBoard;

        public ChessService()
        {
            IntializeChessBoard();
        }
        public bool MovePiece(ChessPiece piece)
        {
            if (ValidateMove(piece))
            {
                var oppositionPiece = _chessBoard.Pieces.FirstOrDefault(x => x.Position == piece.Position && x.SetType != piece.SetType);
                if (oppositionPiece != null)
                {
                    _chessBoard.Pieces.Remove(oppositionPiece);
                    DisplayRemovedPiece(oppositionPiece);
                    if (oppositionPiece.Name == PIECE_NAME.KING)
                        return true;
                }
                var piecePosition = _chessBoard.Pieces.FindIndex(x => x.Id == piece.Id);
                if(piecePosition>=0)
                _chessBoard.Pieces[piecePosition].Position = piece.Position;
  
                //no need of invalid index catch as the user input is validated based on the avialable pice
                return false;
            }
            else
                throw new InvalidOperationException("This is not a valid move");
        }
        public void DisplayBoard()
        {
            throw new NotImplementedException("");
        }
        public void DisplayBoard(PIECE_TYPE currentSet)
        {
            //
            var pieces = _chessBoard.Pieces.Where(x => x.SetType == currentSet).ToList();
            Console.WriteLine("Your Available pieces are");
            foreach (var piece in pieces)
                Console.WriteLine($"Id:{piece.Id}, Name: {piece.Name} ");
        }
        public ChessPiece CheckSetType(int pieceId)
        {
           return _chessBoard.Pieces.FirstOrDefault(x => x.Id == pieceId);
        }

        #region  private methods
        private void DisplayRemovedPiece(ChessPiece piece)
        {
            Console.WriteLine($" Piece removed !! {piece.Name}: {piece.SetType} ");
        }
        private bool ValidateMove(ChessPiece piece)
        {
            //validate if mulitple pieces are being added to same location by same user
            var overlappingPiece = _chessBoard.Pieces.FirstOrDefault(x => x.Position == piece.Position && x.SetType == piece.SetType);
            if (overlappingPiece != null)
                return false;
            var currentPiece = _chessBoard.Pieces.FirstOrDefault(x => x.Id == piece.Id);
            var possibleMovePosition = 0;
            //validate move legality
            switch (piece.Name)
            {
                case PIECE_NAME.BISHOP:
                    int row = currentPiece.Position / 8;

                    if (currentPiece.Position < piece.Position)
                    {
                        while (possibleMovePosition <=64 )
                        {
                            // better approcah would be generate possible path seperatley and then check for the occupancy
                            possibleMovePosition = currentPiece.Position + (8* row);                  
                            var leftPos = possibleMovePosition - row;
                            var rightPos = possibleMovePosition + row;
                            //these 2 need to be considered seperatley
                            if ((checkIfPieceExist(leftPos, piece.SetType) && leftPos< piece.Position) || (checkIfPieceExist(rightPos, piece.SetType) && rightPos< piece.Position))
                                return false;
                            if (leftPos == piece.Position || rightPos == piece.Position)
                                return true;
                            row++;
                        }
                        return false;
                    }
                    else
                    {
                        while (possibleMovePosition >=0)
                        {
                            possibleMovePosition = (currentPiece.Position - 8*row);
                            var leftPos = possibleMovePosition - row;
                            var rightPos = possibleMovePosition + row;
                            //check if there is a element at thhis position
                            if (leftPos == piece.Position || rightPos == piece.Position)
                                return true;
                            row--;
                        }
                        return false;
                    }
                    
                case PIECE_NAME.KING:
                    //all piece moves need to be validated here
                    return true;
                default:
                    //for time beng added
                    return true;
            }
        }

        private void IntializeChessBoard()
        {
            _chessBoard = new ChessBoard();
            _chessBoard.Pieces = new List<ChessPiece>();
            //first set
            _chessBoard.Pieces.Add(new ChessPiece { Id = 1, Position = 1, SetType = PIECE_TYPE.BLACK, Name = PIECE_NAME.ROOK });
            _chessBoard.Pieces.Add(new ChessPiece { Id = 2, Position = 2, SetType = PIECE_TYPE.BLACK, Name = PIECE_NAME.KNIGHT });
            _chessBoard.Pieces.Add(new ChessPiece { Id = 3, Position = 3, SetType = PIECE_TYPE.BLACK, Name = PIECE_NAME.BISHOP });
            _chessBoard.Pieces.Add(new ChessPiece { Id = 4, Position = 4, SetType = PIECE_TYPE.BLACK, Name = PIECE_NAME.KING });
            _chessBoard.Pieces.Add(new ChessPiece { Id = 5, Position = 5, SetType = PIECE_TYPE.BLACK, Name = PIECE_NAME.QUEEN });
            _chessBoard.Pieces.Add(new ChessPiece { Id = 6, Position = 6, SetType = PIECE_TYPE.BLACK, Name = PIECE_NAME.BISHOP });
            _chessBoard.Pieces.Add(new ChessPiece { Id = 7, Position = 7, SetType = PIECE_TYPE.BLACK, Name = PIECE_NAME.KNIGHT });
            _chessBoard.Pieces.Add(new ChessPiece { Id = 8, Position = 8, SetType = PIECE_TYPE.BLACK, Name = PIECE_NAME.ROOK });
            for (int soliderId = 9; soliderId < 17; soliderId++)
                _chessBoard.Pieces.Add(new ChessPiece { Id = soliderId, Position = soliderId, SetType = PIECE_TYPE.BLACK, Name = PIECE_NAME.SOLDIER });
            //second set
            _chessBoard.Pieces.Add(new ChessPiece { Id = 57, Position = 57, SetType = PIECE_TYPE.WHITE, Name = PIECE_NAME.ROOK });
            _chessBoard.Pieces.Add(new ChessPiece { Id = 58, Position = 58, SetType = PIECE_TYPE.WHITE, Name = PIECE_NAME.KNIGHT });
            _chessBoard.Pieces.Add(new ChessPiece { Id = 59, Position = 59, SetType = PIECE_TYPE.WHITE, Name = PIECE_NAME.BISHOP });
            _chessBoard.Pieces.Add(new ChessPiece { Id = 60, Position = 60, SetType = PIECE_TYPE.WHITE, Name = PIECE_NAME.KING });
            _chessBoard.Pieces.Add(new ChessPiece { Id = 61, Position = 61, SetType = PIECE_TYPE.WHITE, Name = PIECE_NAME.QUEEN });
            _chessBoard.Pieces.Add(new ChessPiece { Id = 62, Position = 62, SetType = PIECE_TYPE.WHITE, Name = PIECE_NAME.BISHOP });
            _chessBoard.Pieces.Add(new ChessPiece { Id = 63, Position = 63, SetType = PIECE_TYPE.WHITE, Name = PIECE_NAME.KNIGHT });
            _chessBoard.Pieces.Add(new ChessPiece { Id = 64, Position = 64, SetType = PIECE_TYPE.WHITE, Name = PIECE_NAME.ROOK });
            for (int soliderId = 56; soliderId > 48; soliderId--)
                _chessBoard.Pieces.Add(new ChessPiece { Id = soliderId, Position = soliderId, SetType = PIECE_TYPE.WHITE, Name = PIECE_NAME.SOLDIER });
        }
        private bool checkIfPieceExist(int position, PIECE_TYPE pieceType)
        {
            var existingPiece = _chessBoard.Pieces.FirstOrDefault(x => x.SetType == pieceType && x.Position == position);
            if (existingPiece != null)
                return false;
            return true;
        }
        #endregion
    }
}
