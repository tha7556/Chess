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
    /// <summary>
    /// A Windows Form display of the Chess Board
    /// </summary>
    public partial class Display : Form {
        List<Piece> pieces;
        List<Square> squares;
        /// <summary>
        /// Creates a new Display for the Chess Board
        /// </summary>
        public Display() {
            pieces = new List<Piece>();
            squares = new List<Square>();
            InitializeComponent();
        }
        /// <summary>
        /// Adds a Square to the Chess Board
        /// </summary>
        /// <param name="square">The Square being added</param>
        public void AddSquare(Square square) {
            square.SendToBack();
            Controls.Add(square);
            squares.Add(square);
        }
        /// <summary>
        /// Adds a Piece to the Chess Board
        /// </summary>
        /// <param name="piece">The Piece being added</param>
        public void AddPiece(Piece piece) {
            piece.BringToFront();
            Controls.Add(piece);
            pieces.Add(piece);
        }
        /// <summary>
        /// Called whenever the Display is rendered
        /// </summary>
        /// <param name="args">The PaintEventArgs</param>
        protected override void OnPaint(PaintEventArgs args) {
            base.OnPaint(args);
            for (int i = 0; i < pieces.Count; i++) {
                pieces[i].BringToFront();
            }
            

        }
    }
}
