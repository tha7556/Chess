using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess {
    /// <summary>
    /// The Rook chess Piece
    /// </summary>
    class Rook : Piece {
        /// <summary>
        /// Creates a new Rook Piece
        /// </summary>
        /// <param name="square">The Square to place the Rook</param>
        /// <param name="isWhite">True if the Rook is white, false if black</param>
        /// /// <param name="id">The id used to identify the Rook</param>
        public Rook(Square square, bool isWhite, int id) : base(square,isWhite, id) {
            if (isWhite) {
                Image = Properties.Resources.White_Rook;
                selectedImage = Properties.Resources.White_Rook_Selected;
            }
            else {
                Image = Properties.Resources.Black_Rook;
                selectedImage = Properties.Resources.Black_Rook_Selected;
            }
            BaseImage = Image;
        }
        /// <summary>
        /// Gets all available moves that the Rook can move to
        /// </summary>
        /// <returns>A List of all available Squares</returns>
        public override List<Square> AvailableMoves() { //TODO: Implement
            throw new NotImplementedException();
        }
        /// <summary>
        /// Checks to see if the Rook can move to the specified Square
        /// </summary>
        /// <param name="square">The Square the Rook is moving to</param>
        /// <returns>True if the move is valid</returns>
        public override bool CanMoveTo(Square square) {
            if ((this.Square.ColumnLabel.Equals(square.ColumnLabel) || this.Square.RowNumber == square.RowNumber)) {
                return true;
            }
            return false;
        }
    }
}
