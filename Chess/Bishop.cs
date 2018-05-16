using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess {
    class Bishop : Piece {
        public Bishop(Square square, bool isWhite) : base(square,isWhite) {
            if (isWhite) {
                Image = Properties.Resources.White_Bishop;
                selectedImage = Properties.Resources.White_Bishop_Selected;
            }

            else {
                Image = Properties.Resources.Black_Bishop;
                selectedImage = Properties.Resources.Black_Bishop_Selected;
            }
            BaseImage = Image;
        }
        public override List<Square> AvailableMoves() {
            throw new NotImplementedException();
        }

        public override bool CanMoveTo(Square square) {
            if(IsDiagonalTo(square) && square.Piece == null) {
                return true;
            }
            return false;
        }
    }
}
