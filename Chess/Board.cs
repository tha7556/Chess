using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess {
    /// <summary>
    /// An 8x8 Chess board
    /// </summary>
    class Board {
        private Dictionary<string, Square> squares;
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
        public Square LeftOf(Square square) {
            int index = colLabels.IndexOf(square.ColumnLabel);
            if (index - 1 == -1)
                return null;
            return squares[colLabels[index - 1] + square.RowNumber.ToString()];
        }
        public Square RightOf(Square square) {
            int index = colLabels.IndexOf(square.ColumnLabel);
            if (index + 1 == colLabels.Length)
                return null;
            return squares[colLabels[index - 1] + square.RowNumber.ToString()];
        }
        public Square BottomLeftOf(Square square) {
            int index = colLabels.IndexOf(square.ColumnLabel);
            int row = square.RowNumber - 1;
            if (index - 1 == -1 || row == 0)
                return null;
            return squares[colLabels[index - 1] + row.ToString()];
        }
        public Square BottomRightOf(Square square) {
            int index = colLabels.IndexOf(square.ColumnLabel);
            int row = square.RowNumber - 1;
            if (index + 1 == colLabels.Length || row == 0)
                return null;
            return squares[colLabels[index + 1] + row.ToString()];
        }
        public Square TopLeftOf(Square square) {
            int index = colLabels.IndexOf(square.ColumnLabel);
            int row = square.RowNumber + 1;
            if (index - 1 == -1 || row == 9)
                return null;
            return squares[colLabels[index - 1] + row.ToString()];
        }
        public Square TopRightOf(Square square) {
            int index = colLabels.IndexOf(square.ColumnLabel);
            int row = square.RowNumber + 1;
            if (index + 1 == colLabels.Length || row == 9)
                return null;
            return squares[colLabels[index + 1] + row.ToString()];
        }
        public void AddPieces() {
            Piece[] pieces = new Piece[32];
            //White pieces
            pieces[0] = new King(squares["E1"], true);
            pieces[1] = new Queen(squares["D1"], true);
            pieces[2] = new Bishop(squares["C1"], true);
            pieces[3] = new Bishop(squares["F1"], true);
            pieces[4] = new Knight(squares["B1"], true);
            pieces[5] = new Knight(squares["G1"], true);
            pieces[6] = new Rook(squares["A1"], true);
            pieces[7] = new Rook(squares["H1"], true);
            //Black pieces
            pieces[8] = new King(squares["E8"], false);
            pieces[9] = new Queen(squares["D8"], false);
            pieces[10] = new Bishop(squares["C8"], false);
            pieces[11] = new Bishop(squares["F8"], false);
            pieces[12] = new Knight(squares["B8"], false);
            pieces[13] = new Knight(squares["G8"], false);
            pieces[14] = new Rook(squares["A8"], false);
            pieces[15] = new Rook(squares["H8"], false);
            //White pawns
            for (int i = 1; i <= 8; i++)
                pieces[15 + i] = new Pawn(squares[colLabels[i - 1] + 2.ToString()], true);
            //Black pawns
            for (int i = 1; i <= 8; i++)
                pieces[23 + i] = new Pawn(squares[colLabels[i - 1] + 7.ToString()], false);

            foreach (Piece p in pieces)
                Program.display.AddPiece(p);
        }

    }
}
