using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//TODO: Implement taking pieces, currently only moving on blank spaces
//TODO: Check if there are pieces in the way
namespace Chess {
    /// <summary>
    /// Abstract Chess Piece
    /// </summary>
    public abstract class Piece : PictureBox {
        protected bool hasMoved;
        protected bool white;
        public Image BaseImage { get; set; }
        protected Image selectedImage;
        protected Square square;
        /// <summary>
        /// True if the Piece is white, false otherwise
        /// </summary>
        public bool IsWhite { get { return white; } }
        /// <summary>
        /// Creates a new Piece
        /// </summary>
        /// <param name="isWhite">True if the Piece should be white, false otherwise</param>
        /// <param name="square">The square the Piece should be put</param>
        public Piece(Square square, bool isWhite) {
            this.square = square;
            hasMoved = false;
            white = isWhite;
            if (square.IsWhite)
                BackColor = Square.WHITE;
            else
                BackColor = Square.BLACK;
            Location = new Point(square.Location.X+5, square.Location.Y+5);
            Size = new Size(65, 65);
            SizeMode = PictureBoxSizeMode.StretchImage;
            TabIndex = 0;
            this.BringToFront();

        }
        /// <summary>
        /// Determines if a move is legal for the Piece
        /// </summary>
        /// <param name="square">The square to move to</param>
        /// <returns>True if the move is legal</returns>
        public abstract bool CanMoveTo(Square square);
        /// <summary>
        /// Gets every Square available to move to
        /// </summary>
        /// <returns>A List of Squares the Piece can move to</returns>
        public abstract List<Square> AvailableMoves();
        /// <summary>
        /// Moves the Piece to the square
        /// </summary>
        /// <param name="square">The square to move to</param>
        /// <returns>True if it was successful</returns>
        public bool MoveTo(Square square) {
            if(this.square == null || CanMoveTo(square)) {
                this.square.Piece = null;
                this.square = square;
                square.Piece = this;
                hasMoved = true;
                Location = new Point(square.Location.X+5,square.Location.Y+5);
                if (square.IsWhite)
                    BackColor = Square.WHITE;
                else
                    BackColor = Square.BLACK;
                return true;
            }
            return false;
        }
        public bool IsDiagonalTo(Square square) {
            int xDir = this.square.RowNumber - square.RowNumber;
            int yDir = Board.colLabels.IndexOf(this.square.ColumnLabel) - Board.colLabels.IndexOf(square.ColumnLabel);
            if(xDir != 0 && Math.Abs(yDir/xDir) == 1) {
                return true;
            }
            return false;
        }
        protected override void OnClick(EventArgs e) {
            if (Program.Selected != null && Program.Selected.IsWhite != IsWhite) { //Taking enemy Piece
                Console.WriteLine("Trying to take piece");
            }
            else if(Program.Selected != null && Program.Selected.Equals(this)) {
                Image = BaseImage;
                Program.Selected = null;
            }
            else { //Selecting different Piece
                if (Program.Selected != null)
                    Program.Selected.Image = Program.Selected.BaseImage; //Unselect previous Piece
                Program.Selected = this;
                Image = selectedImage;
            }
           
        }

    }
}
