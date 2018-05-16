using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess {
    public partial class Form1 : Form {
        List<Piece> pieces;
        List<Square> squares;
        public Form1() {
            pieces = new List<Piece>();
            squares = new List<Square>();
            InitializeComponent();
        }
        public void AddSquare(Square square) {
            square.SendToBack();
            Controls.Add(square);
            squares.Add(square);
        }
        public void AddPiece(Piece piece) {
            piece.BringToFront();
            Controls.Add(piece);
            pieces.Add(piece);
        }
        protected override void OnPaint(PaintEventArgs args) {
            base.OnPaint(args);
            for (int i = 0; i < pieces.Count; i++) {
                pieces[i].BringToFront();
            }
            

        }
    }
}
