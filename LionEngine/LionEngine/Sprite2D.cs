using System;
using System.Drawing;

namespace LionEngine.LionEngine
{
    public class Sprite2D : Collider
    {
        public Vector2 Position = null;
        public Scale Scale = null;
        public string Tag = "";

        public Bitmap Sprite = null;
        public string Directory = null;

        public Sprite2D(Vector2 position, Scale scale, string directory, string tag)
        {
            this.Position = position;
            this.Scale = scale;
            this.Directory = directory;
            this.Tag = tag;

            Image tmp = Image.FromFile(this.Directory);
            Sprite = new Bitmap(tmp, (int)this.Scale.Width, (int)this.Scale.Height);

            LionEngine.RegisterSprite(this);
        }

        public Sprite2D(Vector2 position, Scale scale, string directory)
        {
            this.Position = position;
            this.Scale = scale;
            this.Directory = directory;

            Image tmp = Image.FromFile(this.Directory);
            Sprite = new Bitmap(tmp, (int)this.Scale.Width, (int)this.Scale.Height);

            LionEngine.RegisterSprite(this);
        }


        public void setImage(string directory)
        {
            this.Directory = directory;
            Image tmp = Image.FromFile(this.Directory);
            Sprite = new Bitmap(tmp, (int)this.Scale.Width, (int)this.Scale.Height);
        }

        public void setImage(string directory, Scale scale)
        {
            this.Directory = directory;
            this.Scale = scale;

            Image tmp = Image.FromFile(this.Directory);
            Sprite = new Bitmap(tmp, (int)this.Scale.Width, (int)this.Scale.Height);
        }

        public bool isColliding(out Object collide)
        {
            return base.isColliding(this, out collide);
        }

        public bool isCollidingWith(Sprite2D sprite)
        {
            return Collider.isColliding(this, sprite);
        }

        public bool isCollidingWith(Shape2D shape)
        {
            return Collider.isColliding(this, shape);
        }

        public void DestroySelf()
        {
            LionEngine.UnregisterSprite(this);
        }
    }
}
