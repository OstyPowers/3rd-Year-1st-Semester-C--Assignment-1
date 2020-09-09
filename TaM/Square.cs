using System;
using System.Collections.Generic;
using System.Text;

namespace TaM
{
    public class Square
    {
        public bool Top;
        public bool Bottom;
        public bool Left;
        public bool Right;

        
        public Square(string data)
        {
            this.Top = false;
            this.Bottom = false;
            this.Left = false;
            this.Right = false;

        }
    }
}
