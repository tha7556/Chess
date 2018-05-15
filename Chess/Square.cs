using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess {
    /// <summary>
    /// A Square on the chess board
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
        public Square(char column, int row, bool white, int x, int y) {
            columnLabel = column;
            rowNumber = row;
            this.white = white;
            if (white) 
                BackColor = WHITE;
            else
                BackColor = BLACK;
            Location = new System.Drawing.Point(x, y);
            Console.WriteLine(Location);
            Size = new System.Drawing.Size(75, 75);
            TabIndex = 0;
            UseVisualStyleBackColor = false;
        }
        public override string ToString() {
            return columnLabel + rowNumber.ToString();
        }
    }
}
