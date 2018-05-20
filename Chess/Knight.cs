﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess {
    /// <summary>
    /// The Knight chess Piece
    /// </summary>
    class Knight : Piece {
        /// <summary>
        /// Creates a new Knight Piece
        /// </summary>
        /// <param name="square">The Square to place the Knight</param>
        /// <param name="isWhite">True if the Knight is white, false if black</param>
        /// /// <param name="id">The id used to identify the Knight</param>
        public Knight(Square square, bool isWhite, int id) : base(square, isWhite, id) {
            if (isWhite) {
                Image = Properties.Resources.White_Knight;
                selectedImage = Properties.Resources.White_Knight_Selected;
            }
            else {
                Image = Properties.Resources.Black_Knight;
                selectedImage = Properties.Resources.Black_Knight_Selected;
            }
            BaseImage = Image;
        }
        /// <summary>
        /// Gets all available moves that the Knight can move to
        /// </summary>
        /// <returns>A List of all available Squares</returns>
        public override List<Square> AvailableMoves() { //TODO: Implement
            throw new NotImplementedException();
        }
        /// <summary>
        /// Checks to see if the Knight can move to the specified Square
        /// </summary>
        /// <param name="square">The Square the Knight is moving to</param>
        /// <returns>True if the move is valid</returns>
        public override bool CanMoveTo(Square square) {
            int xDist = square.RowNumber - this.Square.RowNumber;
            int yDist = Board.colLabels.IndexOf(square.ColumnLabel) - Board.colLabels.IndexOf(this.Square.ColumnLabel);
            if(Math.Abs(yDist) == 2 && Math.Abs(xDist) == 1) {
                return true;
            }
            else if(Math.Abs(yDist) == 1 && Math.Abs(xDist) == 2) {
                return true;
            }
            return false;
        }

        public new bool PathIsClear(Square square) {
            return true;
        }
    }
}
