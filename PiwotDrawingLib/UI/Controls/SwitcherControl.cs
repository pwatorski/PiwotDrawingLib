﻿using System.Diagnostics;

namespace PiwotDrawingLib.UI.Controls
{
    abstract class SwitcherControl : ActionControl, Switchable
    {

        protected string LAS;
        protected string RAS;
        protected string LNS;
        protected string RNS;
        
        /// <summary>
        /// Symbol(string) used on the left side while the shown value is greater than the minimal value.
        /// </summary>
        public string LeftAvlaiableSymbol
        {
            get
            {
                return LAS;
            }
            set
            {
                LAS = value;
                SetPrintableText();
            }
        }

        /// <summary>
        /// Symbol(string) used on the right side while the shown value is greater than the minimal value.
        /// </summary>
        public string RightAvaliableSymbol
        {
            get
            {
                return RAS;
            }
            set
            {
                RAS = value;
                SetPrintableText();
            }
        }

        /// <summary>
        /// Symbol(string) used on the left side while the shown value is equal or less than the minimal value.
        /// </summary>
        public string LeftNonavaliableSymbol
        {
            get
            {
                return LNS;
            }
            set
            {
                LNS = value;
                SetPrintableText();
            }
        }
        /// <summary>
        /// Symbol(string) used on the right side while the shown value is equal or less than the minimal value.
        /// </summary>
        public string RightNonavaliableSymbol
        {
            get
            {
                return RNS;
            }
            set
            {
                RNS = value;
                SetPrintableText();
            }
        }

        protected int fastSwitchCounter;


        int fastStepTime;

        /// <summary>
        /// Maximal time between value switches required for step multiplication to activate.
        /// </summary>
        public int FastStepTime
        {
            get
            {
                return fastStepTime;
            }
            set
            {
                if(value < 0)
                {
                    throw new System.ArgumentOutOfRangeException();
                }
                fastStepTime = value;
            }
        }
        public int fastStepMultiplier;

        /// <summary>
        /// Multiplier applied to step each time the fast steps counter reaches value of FastStepsToMultiply.
        /// </summary>
        public int FastStepMultiplier
        {
            get
            {
                return fastStepMultiplier;
            }
            set
            {
                if (value < 2)
                {
                    throw new System.ArgumentOutOfRangeException();
                }
                fastStepMultiplier = value;
            }
        }
        public int fastStepsToMultiply;
        /// <summary>
        /// Represents how many times value must be switched faster than FastStepTime for FastStepMultiplier to be applied.
        /// </summary>
        public int FastStepsToMultiply
        {
            get
            {
                return fastStepsToMultiply;
            }
            set
            {
                if (value < 1)
                {
                    throw new System.ArgumentOutOfRangeException();
                }
                fastStepsToMultiply = value;
            }
        }

        protected int oryginalStep;
        protected int step;

        /// <summary>
        /// Magnitude of value increments.
        /// </summary>
        public int Step
        {
            get
            {
                return step;
            }
            set
            {
                step = value;
                oryginalStep = step;
            }
        }

        protected int min = 0;

        /// <summary>
        /// The minimal possible value.
        /// </summary>
        public int Min
        {
            get
            {
                return min;
            }
            set
            {
                min = PiwotToolsLib.PMath.Arit.Clamp(value, int.MinValue, max);
                SetPrintableText();
            }
        }

        protected int max = 10;

        /// <summary>
        /// The maximal possible value.
        /// </summary>
        public int Max
        {
            get
            {
                return max;
            }
            set
            {
                max = PiwotToolsLib.PMath.Arit.Clamp(value, min, int.MaxValue);
                SetPrintableText();
            }
        }

        protected bool hideName = false;

        /// <summary>
        /// If set to 'true' only the value will be shown.
        /// </summary>
        public bool HideName
        {
            get
            {
                return hideName;
            }
            set
            {
                hideName = value;
                SetPrintableText();
            }
        }


        protected Stopwatch stopwatch;

        public SwitcherControl(string name, string identificator) : base(name, identificator)
        {
            LAS = "◄";
            RAS = "►";
            LNS = " ";
            RNS = " ";
            fastSwitchCounter = 0;
            FastStepTime = 0;
            FastStepMultiplier = 10;
            FastStepsToMultiply = 10;
            stopwatch = new Stopwatch();
            stopwatch.Start();
            accessable = true;
        }

        abstract protected void PerformStep(int direction);

        abstract protected void SetPrintableText();
        /// <summary>
        /// Action invoked when left arrow is pressed over this control.
        /// </summary>
        abstract public void SwitchLeft();

        /// <summary>
        /// Action invoked when right arrow is pressed over this control.
        /// </summary>
        abstract public void SwitchRight();
    }
}
