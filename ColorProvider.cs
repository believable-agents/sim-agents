using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Ei.Agents.Core
{
    public class ColorProvider: MonoBehaviour
    {
        private byte originalRed;
        private byte originalGreen;
        private byte originalBlue;

        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
        public byte ZIndex { get; set; }

        public void Change(byte red, byte green, byte blue) {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        public void RestoreOriginal() {
            this.Red = this.originalRed;
            this.Green = this.originalGreen;
            this.Blue = this.originalBlue;
        }

        public void MakeGreen() {
            this.Red = 0;
            this.Green = 255;
            this.Blue = 0;
        }

        public void MakeBlack() {
            this.Red = 0;
            this.Green = 0;
            this.Blue = 0;
        }

        public void SetOriginal(byte red, byte green, byte blue) {
            this.originalRed = red;
            this.originalGreen = green;
            this.originalBlue = blue;
            this.RestoreOriginal();
        }
    }
}
