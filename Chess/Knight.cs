using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess {
    class Knight : Piece {
        public Knight(Square square, bool isWhite) : base(square, isWhite) {

        }
        public override List<Square> AvailableMoves() {
            throw new NotImplementedException();
        }

        public override bool CanMoveTo(Square square) {
            int xDist = square.RowNumber - this.square.RowNumber;
            int yDist = Board.colLabels.IndexOf(square.ColumnLabel) - Board.colLabels.IndexOf(this.square.ColumnLabel);
            if(Math.Abs(yDist) == 2 && Math.Abs(xDist) == 1) {
                return true;
            }
            else if(Math.Abs(yDist) == 1 && Math.Abs(xDist) == 2) {
                return true;
            }
            return false;
        }
    }
}
