using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess {
    static class Program {
        public static Form1 form = new Form1();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Board board = new Board();
            Application.EnableVisualStyles();
            Application.Run(form);
        }
    }
}
