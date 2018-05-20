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
        /// /// <param name="id">The id used to identify the Pawn</param>
        public Pawn(Square square, bool isWhite, int id) : base(square, isWhite, id) {
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
        public override bool CanMoveTo(Square square) { //TODO: Enpassant
            if (square.ColumnLabel == this.Square.ColumnLabel) { //Normal movement
                int distance = square.RowNumber - this.Square.RowNumber;
                if (distance == 1)
                    return true;
                else if (distance == -1 && !white)
                    return true;
                else if (distance == 2 && white && !hasMoved)
                    return true;
                else if (distance == -2 && !white && !hasMoved)
                    return true;
            }
            else if (square.Piece != null && IsDiagonalTo(square)) { //Taking Pieces
                if (IsWhite) {
                    if (square.Equals(Square.TopLeftOf())) {
                        return true;
                    }
                    else if (square.Equals(Square.TopRightOf())) {
                        return true;
                    }
                }
                else {
                    if (square.Equals(Square.BottomLeftOf())) {
                        return true;
                    }
                    else if (square.Equals(Square.BottomRightOf())) {
                        return true;
                    }
                }
            }
            //En Passant
            else if ((Square.RightOf().Piece is Pawn || Square.LeftOf().Piece is Pawn) && 
                   ((Square.RightOf().Piece != null && Square.RightOf().Piece.IsWhite != IsWhite) || (Square.LeftOf().Piece != null && Square.LeftOf().Piece.IsWhite != IsWhite))) {
                if (Program.lastMoved.Square.Equals(Square.RightOf()) || Program.lastMoved.Square.Equals(Square.LeftOf())) {
                    if(Math.Abs(Program.lastEndSpace.RowNumber - Program.lastStartSpace.RowNumber) == 2) {
                        if(square.Piece == null && IsDiagonalTo(square)) {
                            if(IsWhite) {
                                if (square.RowNumber > Square.RowNumber)
                                    return true;
                            }
                            else {
                                if (square.RowNumber < Square.RowNumber)
                                    return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        public override bool CanTake(Piece piece) {
            return base.CanTake(piece) && IsDiagonalTo(piece.Square);
        }
        public override bool MoveTo(Square square) {
            if(IsDiagonalTo(square) && square.Piece == null && CanMoveTo(square)) { //En Passant taking pieces
                Program.lastEndSpace.Piece.Remove();
            }
            return base.MoveTo(square);
        }


    }
}
