using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess {
    /// <summary>
    /// The Pawn chess Piece
    /// </summary>
    class Pawn : Piece {
        /// <summary>
        /// Creates a new Pawn Piece
        /// </summary>
        /// <param name="square">The Square to place the Pawn</param>
        /// <param name="isWhite">True if the Pawn is white, false if black</param>
        public Pawn(Square square, bool isWhite) : base(square, isWhite) {
            if (isWhite) {
                Image = Properties.Resources.White_Pawn;
                selectedImage = Properties.Resources.White_Pawn_Selected;
            }
            else {
                Image = Properties.Resources.Black_Pawn;
                selectedImage = Properties.Resources.Black_Pawn_Selected;
            }
            BaseImage = Image;
        }
        /// <summary>
        /// Gets all available moves that the Pawn can move to
        /// </summary>
        /// <returns>A List of all available Squares</returns>
        public override List<Square> AvailableMoves() { //TODO: Implement
            throw new NotImplementedException();
        }
        /// <summary>
        /// Checks to see if the Pawn can move to the specified location
        /// </summary>
        /// <param name="square">The Square the Pawn is moving to</param>
        /// <returns>True if the move is valid</returns>
        public override bool CanMoveTo(Square square) { //TODO: take pieces diagonally, Enpassant
            if(square.ColumnLabel == this.square.ColumnLabel) {
                int distance = square.RowNumber - this.square.RowNumber;
                if (distance == 1 && white && square.Piece == null)
                    return true;
                else if (distance == -1 && !white && square.Piece == null)
                    return true;
                else if (distance == 2 && white && !hasMoved && square.Piece == null)
                    return true;
                else if (distance == -2 && !white && !hasMoved && square.Piece == null)
                    return true;
            }
            return false;
        }

        
    }
}
