using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess {
    /// <summary>
    /// The Bishop chess Piece
    /// </summary>
    public class Bishop : Piece {
        /// <summary>
        /// Creates a new Bishop Piece
        /// </summary>
        /// <param name="square">The Square to place the Bishop</param>
        /// <param name="isWhite">True if the Bishop is white, false if black</param>
        /// <param name="id">The id used to identify the Bishop</param>
        public Bishop(Square square, bool isWhite, int id) : base(square,isWhite, id) {
            if (isWhite) {
                Image = Properties.Resources.White_Bishop;
                selectedImage = Properties.Resources.White_Bishop_Selected;
            }

            else {
                Image = Properties.Resources.Black_Bishop;
                selectedImage = Properties.Resources.Black_Bishop_Selected;
            }
            BaseImage = Image;
        }
        /// <summary>
        /// Gets all available moves that the Bishop can move to
        /// </summary>
        /// <returns>A List of all available Squares</returns>
        public override List<Square> AvailableMoves() { //TODO: Implement
            throw new NotImplementedException();
        }
        /// <summary>
        /// Checks if the Bishop can move to the specified Square
        /// </summary>
        /// <param name="square">The Square the Bishop is moving to</param>
        /// <returns>True if the move is valid</returns>
        public override bool CanMoveTo(Square square) {
            if(IsDiagonalTo(square)) {
                return true;
            }
            return false;
        }
    }
}
