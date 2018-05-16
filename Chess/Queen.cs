﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess {
    class Queen : Piece {
        public Queen(Square square, bool isWhite) : base(square, isWhite) {
            if (isWhite) {
                Image = Properties.Resources.White_Queen;
                selectedImage = Properties.Resources.White_Queen_Selected;
            }
            else {
                Image = Properties.Resources.Black_Queen;
                selectedImage = Properties.Resources.Black_Queen_Selected;
            }
            BaseImage = Image;
        }
        public override List<Square> AvailableMoves() {
            throw new NotImplementedException();
        }

        public override bool CanMoveTo(Square square) {
            if((IsDiagonalTo(square) || this.square.ColumnLabel.Equals(square.ColumnLabel) || this.square.RowNumber == square.RowNumber) && square.Piece == null) {
                return true;
            }
            return false;
        }
    }
}
