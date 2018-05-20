using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess { 
    static class Program {
        public static Display display = new Display();
        public static Piece Selected;
        //Last move data
        public static Piece lastMoved;
        public static Square lastStartSpace, lastEndSpace;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Board board = new Board();
            Console.WriteLine(board["A1"].GetType());
            Application.EnableVisualStyles();
            Application.Run(display);
        }
    }
}
