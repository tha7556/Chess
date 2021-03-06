﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess {
    /// <summary>
    /// Abstract Chess Piece. Extends a PictureBox to make it easier to display
    /// </summary>
    public abstract class Piece : PictureBox {
        protected int id;
        /// <summary>
        /// True if the Piece has already been moved, false otherwise
        /// </summary>
        public bool hasMoved;
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
        public Square Space;
        /// <summary>
        /// True if the Piece is white, false otherwise
        /// </summary>
        public bool IsWhite { get { return white; } }
        /// <summary>
        /// Creates a new Piece
        /// </summary>
        /// <param name="isWhite">True if the Piece should be white, false otherwise</param>
        /// <param name="square">The square the Piece should be put</param>
        /// /// <param name="id">The id used to identify the Piece</param>
        public Piece(Square square, bool isWhite, int id) {
            Space = square;
            this.id = id;
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
            BringToFront();
            square.Piece = this;

        }
        /// <summary>
        /// Determines if a move is legal for the Piece
        /// </summary>
        /// <param name="square">The square to move to</param>
        /// <returns>True if the move is legal</returns>
        public abstract bool CanMoveTo(Square square);
        /// <summary>
        /// Checks to see if this Piece can take the given Piece
        /// </summary>
        /// <param name="piece">The Piece to take</param>
        /// <returns>True if this Piece can take the given Piece</returns>
        public virtual bool CanTake(Piece piece) {
            return IsWhite != piece.IsWhite;
        }
        /// <summary>
        /// Checks if there are pieces in the way before moving
        /// </summary>
        /// <param name="square">The Square that the Piece is moving to</param>
        /// <returns>True if there are no other pieces in the way</returns>
        public bool PathIsClear(Square square) {
            if (this is Knight)
                return true;
            Square current = Space;
            int xDir = Board.colLabels.IndexOf(square.ColumnLabel) - Board.colLabels.IndexOf(current.ColumnLabel);
            int yDir = square.RowNumber - current.RowNumber;
            while (!current.Equals(square)) {
                if (xDir != 0 && yDir == 0) { //Moving on just x axis
                    if (xDir > 0) // moving right
                        current = current.RightOf();
                    else //moving left
                        current = current.LeftOf();
                }
                else if (xDir == 0 && yDir != 0) { //Moving on just y axis
                    if (yDir > 0) //moving up
                        current = current.TopOf();
                    else //moving down
                        current = current.BottomOf();
                }
                else { //Diagonal
                    if (yDir > 0) { //moving up
                        if (xDir > 0) //moving right
                            current = current.TopRightOf();
                        else //moving left
                            current = current.TopLeftOf();
                    }
                    else { //moving down
                        if (xDir > 0) //moving right
                            current = current.BottomRightOf();
                        else //moving left
                            current = current.BottomLeftOf();
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
        /// <param name="ignorePath">True if the piece should ignore pieces in between it and the square</param>
        /// <returns>True if it was successful</returns>
        public virtual bool MoveTo(Square square, bool ignorePath) {
            if(Space == null || this.PathIsClear(square) || ignorePath) {
                Space.Piece = null;
                Program.lastStartSpace = this.Space;
                Space = square;
                square.Piece = this;
                hasMoved = true;
                Location = new Point(square.Location.X+5,square.Location.Y+5);
                if (square.IsWhite)
                    BackColor = Square.WHITE;
                else
                    BackColor = Square.BLACK;
                Program.lastEndSpace = Space;
                Program.lastMoved = this;
                Program.Selected = null;
                Image = BaseImage;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Moves the Piece to the square
        /// </summary>
        /// <param name="square">The square to move to</param>
        /// <returns>True if it was successful</returns>
        public virtual bool MoveTo(Square square) {
            return MoveTo(square, false);
        }
        /// <summary>
        /// Checks to see if the Piece is located diagonally from the square
        /// </summary>
        /// <param name="square">The square being checked</param>
        /// <returns>True if the Piece is diagonal from the square</returns>
        public bool IsDiagonalTo(Square square) {
            int xDir = Space.RowNumber - square.RowNumber;
            int yDir = Board.colLabels.IndexOf(Space.ColumnLabel) - Board.colLabels.IndexOf(square.ColumnLabel);
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
                if (Program.Selected.CanTake(this) && Program.Selected.CanMoveTo(Space)) {
                    Remove();
                    Program.Selected.MoveTo(Space);
                }
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
        /// <summary>
        /// Removes this Piece from the Board
        /// </summary>
        public void Remove() {
            Space.Piece = null;
            Program.display.Controls.Remove(this);
        }
        /// <summary>
        /// Determines whether or not 2 Pieces are identical
        /// </summary>
        /// <param name="obj">The other Piece</param>
        /// <returns>True if they are equivalent</returns>
        public override bool Equals(Object obj) {
            if(obj.GetType().Equals(GetType())) {
                Piece p = (Piece)obj;
                if(p.IsWhite == IsWhite) {
                    if(id == p.id)
                    return id == p.id;
                }
            }
            return false;
        }
        /// <summary>
        /// Gets the Hash code for the Piece
        /// </summary>
        /// <returns>The Piece's Hash code</returns>
        public override int GetHashCode() {
            int b = 0;
            if (IsWhite)
                b = 1;
            int t = 0;
            switch(GetType().Name) {
                case ("Chess.Pawn"):
                    t = 1;
                    break;
                case ("Chess.Rook"):
                    t = 2;
                    break;
                case ("Chess.Knight"):
                    t = 3;
                    break;
                case ("Chess.Bishop"):
                    t = 4;
                    break;
                case ("Chess.King"):
                    t = 5;
                    break;
                case ("Chess.Queen"):
                    t = 6;
                    break;
            }
            return int.Parse(b.ToString() + t.ToString() + id.ToString());
        }
        /// <summary>
        /// Gets the string representation of the Piece
        /// </summary>
        /// <returns>The string representation of the Piece</returns>
        public override string ToString() {
            String result = "";
            if (IsWhite)
                result += "White ";
            else
                result += "Black ";
            result += GetType().Name;
                if (id > 0)
                    result += " " + id;
            return result;
        }

    }
}
