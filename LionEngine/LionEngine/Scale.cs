using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LionEngine.LionEngine
{
    public class Scale
    {
        public float Width { get; set; }
        public float Height { get; set; }

        public Scale(float Width, float Height)
        {
            this.Width = Width;
            this.Height = Height;
        }

        public static Scale Zero()
        {
            return new Scale(0, 0);
        }
    }
}
