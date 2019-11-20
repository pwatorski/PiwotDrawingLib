﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PiwotToolsLib.PMath;

namespace PiwotDrawingLib.UI.Containers
{
    public class ScrollContainer : Container
    {
        #region Variables

        protected int scrollPoint;
        public int ScrollPoint
        {
            get
            {
                return scrollPoint;
            }
            set
            {
                if (scrollPoint == value)
                    return;

                scrollPoint = value;
            }
        }

        protected string rawText;
        protected string formatedText;
        public string Text
        {
            get
            {
                return formatedText;
            }
            set
            {
                if (value == formatedText)
                    return;
                formatedText = value;
            }
        }


        #endregion
        public ScrollContainer() : base(new Int2(), new Int2(10, 10), "Menu", Misc.Boxes.BoxType.doubled)
        {
            Setup();
        }

        public ScrollContainer(Int2 position, Int2 size, string name, Misc.Boxes.BoxType boxType) : base(position, size, name, boxType)
        {
            Setup();
        }

        void Setup()
        {

        }

        /// <summary>
        /// Draws scrollable window.
        /// </summary>
        override protected void DrawWindow()
        {
            base.DrawWindow();
            Drawing.Renderer.DrawFormated(Name, position.X + (size.X - Name.Length) / 2, position.Y);

        }

        protected override void DrawContent()
        {
            throw new NotImplementedException();
        }


    }
}