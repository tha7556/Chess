using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess {
    class King : Piece {
        public King(Square square, bool isWhite) : base(square, isWhite) {
            if (isWhite)
                Image = Properties.Resources.White_King;
            else
                Image = Properties.Resources.Black_King;
        }
        public override List<Square> AvailableMoves() {
            throw new NotImplementedException();
        }

        public override bool CanMoveTo(Square square) { //TODO: Shouldn't be able to move if the move puts the King in check
            if(square.Piece == null && Math.Abs(square.RowNumber - this.square.RowNumber) <= 1 && Math.Abs(Board.colLabels.IndexOf(square.ColumnLabel) - Board.colLabels.IndexOf(this.square.ColumnLabel)) <= 1 ) {
                return true;
            }
            return false;
        }
    }
}
