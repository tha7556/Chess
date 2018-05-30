using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess {
    /// <summary>
    /// The Pawn chess Piece
    /// </summary>
    public class Pawn : Piece {
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
        public override bool CanMoveTo(Square square) {
            if (square.ColumnLabel == Space.ColumnLabel) { //Normal movement
                int distance = square.RowNumber - Space.RowNumber;
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
                    if (square.Equals(Space.TopLeftOf())) 
                        return true;
                    else if (square.Equals(Space.TopRightOf())) 
                        return true;
                }
                else {
                    if (square.Equals(Space.BottomLeftOf()))
                        return true;
                    else if (square.Equals(Space.BottomRightOf()))
                        return true;
                }
            }
            //En Passant
            else if ((Space.RightOf().Piece is Pawn || Space.LeftOf().Piece is Pawn) && 
                   ((Space.RightOf().Piece != null && Space.RightOf().Piece.IsWhite != IsWhite) || (Space.LeftOf().Piece != null && Space.LeftOf().Piece.IsWhite != IsWhite))) {
                if (Program.lastMoved.Space.Equals(Space.RightOf()) || Program.lastMoved.Space.Equals(Space.LeftOf())) {
                    if(Math.Abs(Program.lastEndSpace.RowNumber - Program.lastStartSpace.RowNumber) == 2) {
                        if(square.Piece == null && IsDiagonalTo(square)) {
                            if(IsWhite) {
                                if (square.RowNumber > Space.RowNumber)
                                    return true;
                            }
                            else {
                                if (square.RowNumber < Space.RowNumber)
                                    return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Determines whether or not the Pawn can take the given Piece
        /// </summary>
        /// <param name="piece">The Piece the Pawn is taking</param>
        /// <returns>True if the Pawn can take the given Piece</returns>
        public override bool CanTake(Piece piece) {
            return base.CanTake(piece) && IsDiagonalTo(piece.Space);
        }
        /// <summary>
        /// Moves the Pawn to the given Square. Modified to take other Pawns with En Passant
        /// </summary>
        /// <param name="square">The Square to move to</param>
        /// <returns>True if the move was successful</returns>
        public override bool MoveTo(Square square) {
            if(IsDiagonalTo(square) && square.Piece == null && CanMoveTo(square)) //En Passant taking pieces
                Program.lastEndSpace.Piece.Remove();
            //Pawn reaches other side
            if (square.RowNumber == 1 || square.RowNumber == 8) { //TODO: Add selection for pieces, not just queen
                Remove();
                Queen queen = new Queen(Space, IsWhite, id);
                Program.display.AddPiece(queen);
                return queen.MoveTo(square);
            }
            return base.MoveTo(square);
        }


    }
}
