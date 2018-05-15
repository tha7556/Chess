using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//TODO: Implement taking pieces, currently only moving on blank spaces
namespace Chess {
    /// <summary>
    /// Abstract Chess Piece
    /// </summary>
    public abstract class Piece {
        protected bool hasMoved;
        protected bool white;
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
            if(CanMoveTo(square)) {
                this.square = square;
                square.Piece = this;
                hasMoved = true;
                return true;
            }
            return false;
        }
        public bool IsDiagonalTo(Square square) {
            int xDir = this.square.RowNumber - square.RowNumber;
            int yDir = Board.colLabels.IndexOf(this.square.ColumnLabel) - Board.colLabels.IndexOf(square.ColumnLabel);
            if(xDir != 0 && yDir/xDir == 1) {
                return true;
            }
            return false;
        }
    }
}
