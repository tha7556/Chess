﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess {
    class Pawn : Piece {
        public Pawn(Square square, bool isWhite) : base(square, isWhite) {
        }
        public override List<Square> AvailableMoves() {
            throw new NotImplementedException();
        }
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