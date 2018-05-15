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
            bool white = true;
            for(int c = 0; c < 8; c++) {
                white = !white;
                for(int r = 1; r <= 8; r++) {
                    Square square = new Square(colLabels[c], r, white);
                    squares.Add(square.ToString(), square);
                    white = !white;
                }
            }
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

    }
}
