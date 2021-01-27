using System;
using System.Collections.Generic;
using System.Text;

namespace LionEngine.LionEngine
{
    public class Vector2
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Vector2(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public Vector2()
        {
            this.X = Zero().X;
            this.Y = Zero().Y;
        }

        public static Vector2 Zero()
        {
            return new Vector2(0f, 0f);
        }

        public static bool isEqual(Vector2 vector1, Vector2 vector2)
        {
            if (vector1.X == vector2.X && vector1.Y == vector2.Y)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public bool isEqual(Vector2 vector)
        {
            if (this.X == vector.X && this.Y == vector.Y)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public static Vector2 Add(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X + b.X, a.Y + b.Y);
        }

        public Vector2 Add(Vector2 vector)
        {
            return new Vector2(this.X + vector.X, this.Y + vector.Y);
        }

        public static Vector2 Subtract(Vector2 a, Vector2 b)
        {
            return new Vector2(a.X - b.X, a.Y - b.Y);
        }

        public Vector2 Subtract(Vector2 vector)
        {
            return new Vector2(this.X - vector.X, this.Y - vector.Y);
        }
    }
}
