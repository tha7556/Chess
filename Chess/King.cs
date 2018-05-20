using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//TODO: implement Castling
namespace Chess {
    /// <summary>
    /// The King chess Piece
    /// </summary>
    public class King : Piece {
        /// <summary>
        /// Creates a new King Piece
        /// </summary>
        /// <param name="square">The Square to place the King</param>
        /// <param name="isWhite">True if the King is white, false if black</param>
        /// /// <param name="id">The id used to identify the King</param>
        public King(Square square, bool isWhite, int id) : base(square, isWhite, id) {
            if (isWhite) {
                Image = Properties.Resources.White_King;
                selectedImage = Properties.Resources.White_King_Selected;
            }
            else {
                Image = Properties.Resources.Black_King;
                selectedImage = Properties.Resources.Black_King_Selected;
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
        /// Checks to see if the King can move to the specified Square
        /// </summary>
        /// <param name="square">The Square the King is moving to</param>
        /// <returns>True if the move is valid</returns>
        public override bool CanMoveTo(Square square) { //TODO: Shouldn't be able to move if the move puts the King in check
            if(Math.Abs(square.RowNumber - Space.RowNumber) <= 1 && Math.Abs(Board.colLabels.IndexOf(square.ColumnLabel) - Board.colLabels.IndexOf(Space.ColumnLabel)) <= 1 ) {
                return true;
            }
            return false;
        }
    }
}
