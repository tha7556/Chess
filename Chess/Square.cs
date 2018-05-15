using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess {
    /// <summary>
    /// A Square on the chess board
    /// </summary>
    class Square {
        private readonly bool white;
        /// <summary>
        /// True if the space is white, false otherwise
        /// </summary>
        public bool IsWhite { get { return white; } }
        private readonly char columnLabel;
        /// <summary>
        /// The label identifying the column
        /// </summary>
        public char ColumnLabel { get { return columnLabel; } }
        private readonly int rowNumber;
        /// <summary>
        /// The number identifying the row
        /// </summary>
        public int RowNumber { get { return rowNumber; } }
        /// <summary>
        /// The Piece that is currently on the square
        /// </summary>
        public Piece Piece { get; set; }
        /// <summary>
        /// Creates a new Square on a chess board
        /// </summary>
        /// <param name="column">The column label</param>
        /// <param name="row">The row number</param>
        /// <param name="white">True if white, false otherwise</param>
        public Square(char column, int row, bool white) {
            columnLabel = column;
            rowNumber = row;
            this.white = white;
        }
        public override string ToString() {
            return columnLabel + rowNumber.ToString();
        }
    }
}
