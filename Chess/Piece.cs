using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//TODO: Implement taking pieces, currently only moving on blank spaces
namespace Chess {
    /// <summary>
    /// Abstract Chess Piece. Extends a PictureBox to make it easier to display
    /// </summary>
    public abstract class Piece : PictureBox {
        /// <summary>
        /// True if the Piece has already been moved, false otherwise
        /// </summary>
        protected bool hasMoved;
        /// <summary>
        /// True if the Piece is white, false otherwise
        /// </summary>
        protected bool white;
        /// <summary>
        /// The Base Image of the Piece
        /// </summary>
        public Image BaseImage { get; set; }
        /// <summary>
        /// The Selected Image of the Piece
        /// </summary>
        protected Image selectedImage;
        /// <summary>
        /// The Square that the Piece is on
        /// </summary>
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
            square.Piece = this;

        }
        /// <summary>
        /// Determines if a move is legal for the Piece
        /// </summary>
        /// <param name="square">The square to move to</param>
        /// <returns>True if the move is legal</returns>
        public abstract bool CanMoveTo(Square square);
        /// <summary>
        /// Checks if there are pieces in the way before moving
        /// </summary>
        /// <param name="square">The Square that the Piece is moving to</param>
        /// <returns>True if there are no other pieces in the way</returns>
        public bool PathIsClear(Square square) {
            if (this is Knight)
                return true;
            Square current = this.square;
            int xDir = Board.colLabels.IndexOf(square.ColumnLabel) - Board.colLabels.IndexOf(current.ColumnLabel);
            int yDir = square.RowNumber - current.RowNumber;
            while (!current.Equals(square)) {
                if (xDir != 0 && yDir == 0) { //Moving on just x axis
                    if (xDir > 0) // moving right
                        current = current.Board.RightOf(current);
                    else //moving left
                        current = current.Board.LeftOf(current);
                }
                else if (xDir == 0 && yDir != 0) { //Moving on just y axis
                    if (yDir > 0) //moving up
                        current = current.Board.TopOf(current);
                    else //moving down
                        current = current.Board.BottomOf(current);
                }
                else { //Diagonal
                    if (yDir > 0) { //moving up
                        if (xDir > 0) //moving right
                            current = current.Board.TopRightOf(current);
                        else //moving left
                            current = current.Board.TopLeftOf(current);
                    }
                    else { //moving down
                        if (xDir > 0) //moving right
                            current = current.Board.BottomRightOf(current);
                        else //moving left
                            current = current.Board.BottomLeftOf(current);
                    }
                }
                if (!current.Equals(square) && current.Piece != null)
                    return false;
            }
            return true;
        }
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
            if(this.square == null || (CanMoveTo(square) && this.PathIsClear(square))) {
                this.square.Piece = null;
                Program.lastStartSpace = this.square;
                this.square = square;
                square.Piece = this;
                hasMoved = true;
                Location = new Point(square.Location.X+5,square.Location.Y+5);
                if (square.IsWhite)
                    BackColor = Square.WHITE;
                else
                    BackColor = Square.BLACK;
                Program.lastEndSpace = this.square;
                Program.lastMoved = this;
                Program.Selected = null;
                Image = BaseImage;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Checks to see if the Piece is located diagonally from the square
        /// </summary>
        /// <param name="square">The square being checked</param>
        /// <returns>True if the Piece is diagonal from the square</returns>
        public bool IsDiagonalTo(Square square) {
            int xDir = this.square.RowNumber - square.RowNumber;
            int yDir = Board.colLabels.IndexOf(this.square.ColumnLabel) - Board.colLabels.IndexOf(square.ColumnLabel);
            if(xDir != 0 && Math.Abs(yDir/xDir) == 1) {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Handles what happens when a Piece is clicked on
        /// </summary>
        /// <param name="e">The click event</param>
        protected override void OnClick(EventArgs e) {
            if (Program.Selected != null && Program.Selected.IsWhite != IsWhite) { //Taking enemy Piece
                Console.WriteLine("Trying to take piece");
            }
            else if(Program.Selected != null && Program.Selected.Equals(this)) { //Unselect Piece
                Image = BaseImage;
                Program.Selected = null;
            }
            else { //Selecting different Piece
                if (Program.Selected != null)
                    Program.Selected.Image = Program.Selected.BaseImage; //Unselect previous Piece
                if (Program.lastMoved == null || Program.lastMoved.IsWhite != IsWhite) { //Forcing turns
                    Program.Selected = this;
                    Image = selectedImage;
                }
            }
           
        }

    }
}
