﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess {
    class Rook : Piece {
        public Rook(Square square, bool isWhite) : base(square,isWhite) {

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
