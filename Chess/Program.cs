using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess {
    static class Program {
        public static Display display = new Display();
        public static Piece Selected;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Board board = new Board();
            Application.EnableVisualStyles();
            Application.Run(display);
        }
    }
}
