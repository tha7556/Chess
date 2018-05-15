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
            throw new NotImplementedException();
        }
    }
}
