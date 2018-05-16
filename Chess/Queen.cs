using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess {
    /// <summary>
    /// The Queen chess Piece.
    /// </summary>
    class Queen : Piece {
        /// <summary>
        /// Creates a new Queen Piece on the given square
        /// </summary>
        /// <param name="square">The square to place the Queen</param>
        /// <param name="isWhite">True if the piece is white, false if black</param>
        public Queen(Square square, bool isWhite) : base(square, isWhite) {
            if (isWhite) {
                Image = Properties.Resources.White_Queen;
                selectedImage = Properties.Resources.White_Queen_Selected;
            }
            else {
                Image = Properties.Resources.Black_Queen;
                selectedImage = Properties.Resources.Black_Queen_Selected;
            }
            BaseImage = Image;
        }
        /// <summary>
        /// Gets all available moves that the Queen can move to
        /// </summary>
        /// <returns>A List of all available Squares</returns>
        public override List<Square> AvailableMoves() { //TODO: Implement
            throw new NotImplementedException();
        }
        /// <summary>
        /// Checks if the Queen can move to the specified Square
        /// </summary>
        /// <param name="square">The Square the Queen is moving to</param>
        /// <returns>True if the move is valid</returns>
        public override bool CanMoveTo(Square square) {
            if((IsDiagonalTo(square) || this.square.ColumnLabel.Equals(square.ColumnLabel) || this.square.RowNumber == square.RowNumber) && square.Piece == null) {
                return true;
            }
            return false;
        }
    }
}
