using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructureSample
{
    struct Color32
    {
        public Color32(byte r, byte g, byte b, byte a)
        {
            R =r; G = g; B = b; A = a;
        }

        public byte R, G, B, A; //byte는 0~255까지 표현, 8bit, 음수 없음
    }
}
