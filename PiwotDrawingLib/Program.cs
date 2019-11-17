﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Pastel;
using System.IO;
using System.Drawing;
using System.Threading;
using PiwotDrawingLib.Drawing;
using PiwotToolsLib.PMath;
using System.Text;
using System.Activities;
using System.Runtime.InteropServices;

namespace PiwotDrawingLib
{
    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetConsoleWindow();
        static void Main(string[] args)
        {
            Renderer.WindowSize = new Int2(200, 50);
            Renderer.FrameLenght = 30;
            
            Bitmap b2 = new Bitmap("picture.jpg");

            Bitmap b = new Bitmap("image.jpg");
            int counter = 0;

            UI.Containers.PictureBox pb = new UI.Containers.PictureBox(new Int2(0, 0), new Int2(200, 50), "", Misc.Boxes.BoxType.none, b)
            {
                SizeDifferenceHandling = UI.Containers.Container.ContentHandling.FitContent
            };

            pb.Draw();
            while (true)
            {
                
                pb.Image = (counter % 2 == 0 ? b : b2);
                pb.RefreshContent();
                counter++;
                Console.ReadKey(true);
            }

            /*
            UI.Containers.SimpleFunctionDisplay fd = new UI.Containers.SimpleFunctionDisplay(new Int2(0, 0), new Int2(150, 50), "Main menu", Misc.Boxes.BoxType.round, (x) => x);
            fd.Draw();
            float f;
            long time = 0;
            for(int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    f = (float)Rand.Double() * 2;
                    fd.Function = (x) => (x + f - 1) * (x + f - 1);
                    
                    fd.RefreshContent();
                    Thread.Sleep(200);
                }
            }
            time /= 100;
            */
            /*
            Stopwatch sw = new Stopwatch();
            for (int i = 0; i < 1000; i++)
            {
                ch = (char)(65 + i % 26);
                sw.Restart();
                for (int j = 0; j < 10000; j++)
                {
                    c.Draw(""+ch, j % 38, (j / 38) % 38);
                    //c.DrawMap();
                    //Console.ReadKey(true);
                }
                c.RefreshContent();
                sw.Stop();
                Renderer.Write(sw.ElapsedMilliseconds + " ", 40, 0);
                Console.ReadKey(true);
            }
            */
            
            /*
            Int2 menuSize = new Int2(40, 20);
            UI.Containers.Menu mainMenu = new UI.Containers.Menu(Int2.One, menuSize, "Main menu", Misc.Boxes.BoxType.light);
            //mainMenu.VerticalTextWrapping = UI.Containers.Menu.Wrapping.scrolling;

            UI.Controls.ButtonControl bc = new UI.Controls.ButtonControl("b0", "b0");
            bc.AddAction("b1", (x) => { Renderer.AddDissapearingText($"XDDD {DateTime.Now.Millisecond}", 1000, new Int2()); return true; });
            mainMenu.AddControl(bc);

            mainMenu.AddControl(new UI.Controls.LineSeparatorControl("L0", "_label_0"));

            bc = new UI.Controls.ButtonControl("b1", "b1");
            bc.AddAction("b1", (x) => { Renderer.AddDissapearingText($"DXXX {DateTime.Now.Millisecond}", 1000, new Int2(0, 1)); return true; });
            mainMenu.AddControl(bc);

            UI.Controls.CheckBoxControl cb = new UI.Controls.CheckBoxControl("CB", "_CB", true)
            {
                TrueValue = "XD",
                FalseValue = "DX",
                HideName = true
            };
            mainMenu.AddControl(cb);

            UI.Controls.IntSwitcherControl isc = new UI.Controls.IntSwitcherControl("ICS", "_ICS", 40, 2, 10000000, 1)
            {
                MinSpecialText = "ZERO",
                MaxSpecialText = "DUŻO",
                FastStepMultiplier = 10,
                FastStepsToMultiply = 10,
                FastStepTime = 10,
                HideName = true,

            };
            isc.AddAction("ISC", (x) => { mainMenu.Size = new Int2(((UI.Events.IntSwitcherEvent)x).Value, 20); return true; });
            mainMenu.AddControl(isc);

            UI.Controls.FloatSwitcherControl fsc = new UI.Controls.FloatSwitcherControl("FCS", "_FCS", 0, 0, 10000000, 0.5f)
            {
                MinSpecialText = "ZERO",
                MaxSpecialText = "DUŻO",
                FastStepMultiplier = 10,
                FastStepsToMultiply = 10,
                FastStepTime = 200,
                HideName = true,
                RoundingDigits = 5
            };
            mainMenu.AddControl(fsc);
            mainMenu.WaitForInput();
            
            //Renderer.AbortAsyncThread();
            */
            Console.ReadKey(true);

        }
    }
}
