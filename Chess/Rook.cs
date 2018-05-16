using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess {
    class Rook : Piece {
        public Rook(Square square, bool isWhite) : base(square,isWhite) {
            if (isWhite)
                Image = Properties.Resources.White_Rook;
            else
                Image = Properties.Resources.Black_Rook;
        }
        public override List<Square> AvailableMoves() {
            throw new NotImplementedException();
        }

        public override bool CanMoveTo(Square square) {
            if ((this.square.ColumnLabel.Equals(square.ColumnLabel) || this.square.RowNumber == square.RowNumber) && square.Piece == null) {
                return true;
            }
            return false;
        }
    }
}
