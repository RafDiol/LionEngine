using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LionEngine.LionEngine
{
    public class Shape2D : Collider
    {
        public Vector2 Position = null;
        public Scale Scale = null;
        public string Tag = "";
        public Color Color = Color.Red;

        public Shape2D(Vector2 position, Scale scale, string tag)
        {
            this.Position = position;
            this.Scale = scale;
            this.Tag = tag;

            LionEngine.RegisterShape(this);
        }

        public Shape2D(Vector2 position, Scale scale, Color color, string tag)
        {
            this.Position = position;
            this.Scale = scale;
            this.Tag = tag;
            this.Color = color;

            LionEngine.RegisterShape(this);
        }

        public Shape2D(Vector2 position, Scale scale, Color color)
        {
            this.Position = position;
            this.Scale = scale;
            this.Color = color;

            LionEngine.RegisterShape(this);
        }

        public Shape2D(Vector2 position, Scale scale)
        {
            this.Position = position;
            this.Scale = scale;

            LionEngine.RegisterShape(this);
        }

        public bool isColliding(out Object collide)
        {
            return base.isColliding(this, out collide);
        }

        public bool isCollidingWith(Sprite2D sprite)
        {
            return Collider.isColliding(sprite, this);
        }

        public bool isCollidingWith(Shape2D shape)
        {
            return Collider.isColliding(shape, this);
        }

        public void DestroySelf()
        {
            LionEngine.UnregisterShape(this);
        }
    }
}
