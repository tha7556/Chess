using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess {
    /// <summary>
    /// An 8x8 Chess board
    /// </summary>
    public class Board {
        private Dictionary<string, Square> squares;
        /// <summary>
        /// The label for each Column
        /// </summary>
        public static string colLabels = "ABCDEFGH";
        /// <summary>
        /// Creates a new Chess board
        /// </summary>
        public Board() {
            squares = new Dictionary<string, Square>(8 * 8);
            bool white = false;
            int startx = 0, starty = 0;
            int x = startx;
            int y = starty;
            for(int r = 8; r > 0; r--) {
                white = !white;
                Square square = null;
                for(int c = 0; c < 8; c++) {
                    square = new Square(colLabels[c], r, white, x, y);
                    squares.Add(square.ToString(), square);
                    Program.display.AddSquare(square);
                    white = !white;
                    x += square.Width;
                }
                x = startx;
                y += square.Height;
            }
            AddPieces();
        }
        /// <summary>
        /// Allows access to each square of the Board
        /// </summary>
        /// <param name="key">The key of the Square</param>
        /// <returns>The Square with the given key</returns>
        public Square this[string key] {
            get {
                return squares[key];
            }
            set {
                squares[key] = value;
            }
        }
       
        /// <summary>
        /// Adds all of the pieces to the board
        /// </summary>
        public void AddPieces() {
            Piece[] pieces = new Piece[32];
            //White pieces
            pieces[0] = new King(squares["E1"], true, 0);
            pieces[1] = new Queen(squares["D1"], true, 0);
            pieces[2] = new Bishop(squares["C1"], true, 1);
            pieces[3] = new Bishop(squares["F1"], true, 2);
            pieces[4] = new Knight(squares["B1"], true, 1);
            pieces[5] = new Knight(squares["G1"], true, 2);
            pieces[6] = new Rook(squares["A1"], true, 1);
            pieces[7] = new Rook(squares["H1"], true, 2);
            //Black pieces
            pieces[8] = new King(squares["E8"], false, 0);
            pieces[9] = new Queen(squares["D8"], false, 0);
            pieces[10] = new Bishop(squares["C8"], false, 1);
            pieces[11] = new Bishop(squares["F8"], false, 2);
            pieces[12] = new Knight(squares["B8"], false, 1);
            pieces[13] = new Knight(squares["G8"], false, 2);
            pieces[14] = new Rook(squares["A8"], false, 1);
            pieces[15] = new Rook(squares["H8"], false, 2);
            //White pawns
            for (int i = 1; i <= 8; i++)
                pieces[15 + i] = new Pawn(squares[colLabels[i - 1] + 2.ToString()], true, i);
            //Black pawns
            for (int i = 1; i <= 8; i++)
                pieces[23 + i] = new Pawn(squares[colLabels[i - 1] + 7.ToString()], false, i);

            foreach (Piece p in pieces)
                Program.display.AddPiece(p);
        }

    }
}
