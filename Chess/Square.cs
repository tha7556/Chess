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
