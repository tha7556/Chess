using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess {
    /// <summary>
    /// A Square on the chess board. Extends Button to make it easier to display
    /// </summary>
    public class Square : Button {
        /// <summary>
        /// The Color used for white spaces
        /// </summary>
        public static readonly Color WHITE = Color.BurlyWood;
        /// <summary>
        /// The Color used for black spaces
        /// </summary>
        public static readonly Color BLACK = Color.SaddleBrown;
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
        /// The Board that this Square is on
        /// </summary>
        public Board Board { get; }
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
        /// <param name="x">The x coordinate for the Square</param>
        /// <param name="y">The y coordinate for the Square</param>
        /// <param name="board">The board the square is on</param>
        public Square(char column, int row, bool white, int x, int y, Board board) {
            columnLabel = column;
            rowNumber = row;
            this.white = white;
            if (white) 
                BackColor = WHITE;
            else
                BackColor = BLACK;
            Location = new Point(x, y);
            Size = new Size(75, 75);
            TabIndex = 0;
            Board = board;
        }
        /// <summary>
        /// Gets the Square to the left of the Square
        /// </summary>
        /// <returns>The Square to the left of the one</returns>
        public Square LeftOf() {
            int index = Board.colLabels.IndexOf(ColumnLabel);
            if (index - 1 == -1)
                return null;
            return Program.board[Board.colLabels[index - 1] + RowNumber.ToString()];
        }
        /// <summary>
        /// Gets the Square to the right of the Square
        /// </summary>
        /// <returns>The Square to the right of the one</returns>
        public Square RightOf() {
            int index = Board.colLabels.IndexOf(ColumnLabel);
            if (index + 1 == Board.colLabels.Length)
                return null;
            return Program.board[Board.colLabels[index + 1] + RowNumber.ToString()];
        }
        /// <summary>
        /// Gets the Square above the Square
        /// </summary>
        /// <returns>The Square above the Square</returns>
        public Square TopOf() {
            int row = RowNumber + 1;
            if (row == 9)
                return null;
            return Program.board[ColumnLabel + row.ToString()];
        }
        /// <summary>
        /// Gets the Square below the Square
        /// </summary>
        /// <returns>The Square to the left of the Square</returns>
        public Square BottomOf() {
            int row = RowNumber - 1;
            if (row == 0)
                return null;
            return Program.board[ColumnLabel + row.ToString()];
        }
        /// <summary>
        /// Gets the Square to the bottom left diagonal of the Square
        /// </summary>
        /// <returns>The Square to the bottom left diagonal of the Square</returns>
        public Square BottomLeftOf() {
            int index = Board.colLabels.IndexOf(ColumnLabel);
            int row = RowNumber - 1;
            if (index - 1 == -1 || row == 0)
                return null;
            return Program.board[Board.colLabels[index - 1] + row.ToString()];
        }
        /// <summary>
        /// Gets the Square to the bottom right diagonal of the Square
        /// </summary>
        /// <returns>The Square to the bottom right diagonal of the Square</returns>
        public Square BottomRightOf() {
            int index = Board.colLabels.IndexOf(ColumnLabel);
            int row = RowNumber - 1;
            if (index + 1 == Board.colLabels.Length || row == 0)
                return null;
            return Program.board[Board.colLabels[index + 1] + row.ToString()];
        }
        /// <summary>
        /// Gets the Square to the top left diagonal of the square
        /// </summary>
        /// <returns>The Square to the top left diagonal of the Square</returns>
        public Square TopLeftOf() {
            int index = Board.colLabels.IndexOf(ColumnLabel);
            int row = RowNumber + 1;
            if (index - 1 == -1 || row == 9)
                return null;
            return Program.board[Board.colLabels[index - 1] + row.ToString()];
        }
        /// <summary>
        /// Gets the Square to the top right diagonal of the square
        /// </summary>
        /// <returns>The Square to the rop right diagonal of the Square</returns>
        public Square TopRightOf() {
            int index = Board.colLabels.IndexOf(ColumnLabel);
            int row = RowNumber + 1;
            if (index + 1 == Board.colLabels.Length || row == 9)
                return null;
            return Program.board[Board.colLabels[index + 1] + row.ToString()];
        }
        /// <summary>
        /// Gets the String representation of the Square, the column label and the row number
        /// </summary>
        /// <returns>The column label + the row number</returns>
        public override string ToString() {
            return columnLabel + rowNumber.ToString();
        }
        /// <summary>
        /// Checks to see if this Square is equal with another
        /// </summary>
        /// <param name="obj">The Square to check</param>
        /// <returns>True if they are equal</returns>
        public override bool Equals(Object obj) {
            if (obj is Square square) {
                return rowNumber == square.rowNumber && columnLabel.Equals(square.columnLabel);
            }
            return false;
        }
        /// <summary>
        /// Gets the hash code of the Square
        /// </summary>
        /// <returns>The hash code</returns>
        public override int GetHashCode() {
            return int.Parse(Board.colLabels.IndexOf(ColumnLabel) + RowNumber.ToString());
        }
        /// <summary>
        /// Determines what happens when the Square is clicked on
        /// </summary>
        /// <param name="e">The click event</param>
        protected override void OnClick(EventArgs e) {
            if(Program.Selected != null && (Piece == null || Program.Selected.CanTake(Piece)) && Program.Selected.CanMoveTo(this)) {
                if (Piece != null)
                    Piece.Remove();
                Program.Selected.MoveTo(this);
            }
        }
    }
}
