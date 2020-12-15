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
    public class GameService : IGameService
    {
        public GameService()
        {

        }
        #region public methods
        public void Run()
        {

            IChessBoardService chessService = new ChessService();
            #region User Intialization
            Console.WriteLine("Enter first player name ");
            string userName1 = Console.ReadLine();
            Console.WriteLine("Enter second player name ");
            string userName2 = Console.ReadLine();
            var player1 = new Player() { Name = userName1, Id = 1, SetName = PIECE_TYPE.BLACK };
            var player2 = new Player() { Name = userName2, Id = 2, SetName = PIECE_TYPE.WHITE };
            #endregion
            int currentPlayerId = 1, pieceId = 0, gridLocation = 0;
            bool gameStatus = false;
            IPlayer<int> currentUser = player1;
            while (true)
            {
                try
                {
                    // chessService.DisplayBoard(); //grid view
                    switch (currentPlayerId)
                    {
                        case 1:
                            currentUser = player1;
                            currentPlayerId++;
                            break;
                        case 2:
                            currentUser = player2;
                            currentPlayerId--;
                            break;
                    }
                    Console.WriteLine($"{currentUser.Name} your next move ");
                    chessService.DisplayBoard(currentUser.SetName);
                    Console.WriteLine($"{currentUser.Name} , please enter piece Id ");
                    pieceId = ReadUserResponse();
                    Console.WriteLine($"{currentUser.Name} position  ");
                    gridLocation = ReadUserResponse();
                    #region validat piece
                    var currentUserPiece= chessService.CheckSetType(pieceId);
                    if(currentUserPiece.SetType!= currentUser.SetName)
                    {
                        throw new InvalidOperationException("You have selected other player's piece");
                    }
                    #endregion
                    gameStatus = chessService.MovePiece(new ChessPiece() { Id = pieceId, Position = gridLocation, SetType = currentUser.SetName,Name= currentUserPiece.Name });
                    if (gameStatus)
                    {
                        Console.WriteLine($"You won the game!! {currentUser.Name}");
                        break;
                    }

                }
                catch (InvalidOperationException ex)
                {
                    //give one more chance to current active user
                    if (currentUser.Id == 1)
                        currentPlayerId--;
                    else
                        currentPlayerId++;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("That was a illegal move !!");
                    Console.ForegroundColor = ConsoleColor.Green;
                    continue;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unexpected error occured!");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
        }
        #endregion 
        #region private methods
        private int ReadUserResponse()
        {
            try
            {
                int inputOption = int.Parse(Console.ReadLine());
                return inputOption;
            }
            catch (FormatException exception)
            {
                throw new FormatException("Please enter only numbers.");
            }
            catch (Exception exception)
            {
                throw new Exception("Unhandled Exception occured.");
            }
        }
        #endregion
    }
}
