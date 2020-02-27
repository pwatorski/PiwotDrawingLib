﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiwotDrawingLib.Drawing;

namespace PiwotDrawingLib.UI.Controls
{
    public class TextDisplay : UIElement
    {
        protected string[] textLines;

        protected string text;
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                textLines = text.Split('\n');
            }
        }

        public override void Erase()
        {
            
        }

        public override void PrintOnCanvas(Canvas canvas)
        {
            for(int i = 0; i < textLines.Length; i++)
            {
                canvas.DrawOnCanvas(textLines[i], position.X, position.Y + i);
            }
        }
    }
}
