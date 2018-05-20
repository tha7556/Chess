using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            else if(!hasMoved && Math.Abs(Board.colLabels.IndexOf(square.ColumnLabel) - Board.colLabels.IndexOf(Space.ColumnLabel)) == 2 && square.RowNumber == Space.RowNumber) { //Castling
                Piece rook;
                if (Board.colLabels.IndexOf(square.ColumnLabel) - Board.colLabels.IndexOf(Space.ColumnLabel) > 0) { //Moving right
                    rook = Program.board[Board.colLabels[Board.colLabels.IndexOf(Space.ColumnLabel) + 3] + Space.RowNumber.ToString()].Piece;
                }
                else { //Moving left
                    rook = Program.board[Board.colLabels[Board.colLabels.IndexOf(Space.ColumnLabel) - 4] + Space.RowNumber.ToString()].Piece;
                }
                if(rook is Rook && !rook.hasMoved && PathIsClear(square)) {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// MoveTo for Kings, used to implement Castling
        /// </summary>
        /// <param name="square">The Square to move to</param>
        /// <returns>True if the move was successful</returns>
        public override bool MoveTo(Square square) {
            bool b = base.MoveTo(square);
            if(Math.Abs(Board.colLabels.IndexOf(square.ColumnLabel) - Board.colLabels.IndexOf(Program.lastStartSpace.ColumnLabel)) == 2) { //Castling
                if (Board.colLabels.IndexOf(square.ColumnLabel) - Board.colLabels.IndexOf(Program.lastStartSpace.ColumnLabel) > 0) { //Moving right
                    Program.board[Board.colLabels[Board.colLabels.IndexOf(Program.lastStartSpace.ColumnLabel) + 3] + Program.lastStartSpace.RowNumber.ToString()].Piece.MoveTo(Space.LeftOf(),true);
                }
                else { //Moving left
                     Program.board[Board.colLabels[Board.colLabels.IndexOf(Program.lastStartSpace.ColumnLabel) - 4] + Program.lastStartSpace.RowNumber.ToString()].Piece.MoveTo(Space.RightOf(), true);
                }
            }
            return b;
        }
    }
}
