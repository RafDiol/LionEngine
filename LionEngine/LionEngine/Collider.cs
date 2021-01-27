using System;

namespace LionEngine.LionEngine
{
    public abstract class Collider
    {
        public virtual bool isCollidingWith(Sprite2D me, Sprite2D other)
        {
            return isColliding(me, other);
        }

        public virtual bool isCollidingWith(Sprite2D me, Shape2D other)
        {
            return isColliding(me, other);
        }

        public virtual bool isColliding(Sprite2D me, out Object collide)
        {
            foreach (Sprite2D sprite in LionEngine.getAllSprites2D())
            {
                if (Sprite2D.isColliding(me, sprite) && sprite != me)
                {
                    collide = sprite;
                    return true;
                }
            }
            foreach (Shape2D shape in LionEngine.getAllShapes2D())
            {
                if (Sprite2D.isColliding(me, shape))
                {
                    collide = shape;
                    return true;
                }
            }
            collide = null;
            return false;
        }

        public virtual bool isColliding(Shape2D me, out Object collide)
        {
            foreach (Sprite2D sprite in LionEngine.getAllSprites2D())
            {
                if (isColliding(sprite, me))
                {
                    collide = sprite;
                    return true;
                }
            }
            foreach (Shape2D shape in LionEngine.getAllShapes2D())
            {
                if (Sprite2D.isColliding(me, shape) && shape != this)
                {
                    collide = shape;
                    return true;
                }
            }
            collide = null;
            return false;
        }

        public virtual bool isCollidingWith(Shape2D me, Shape2D other)
        {
            return isColliding(me, other);
        }
        // These are static and do not need to be implemented
        public static bool isColliding(Sprite2D sprite, Shape2D shape)
        {
            if (sprite.Position.X < shape.Position.X + shape.Scale.Width &&
                sprite.Position.X + sprite.Scale.Width > shape.Position.X &&
                sprite.Position.Y < shape.Position.Y + shape.Scale.Height &&
                sprite.Position.Y + sprite.Scale.Height > shape.Position.Y)
            {
                return true;
            }
            return false;
        }

        public static bool isColliding(Sprite2D a, Sprite2D b)
        {
            if (a.Position.X < b.Position.X + b.Scale.Width &&
                a.Position.X + a.Scale.Width > b.Position.X &&
                a.Position.Y < b.Position.Y + b.Scale.Height &&
                a.Position.Y + a.Scale.Height > b.Position.Y)
            {
                return true;
            }
            return false;
        }

        public static bool isColliding(Shape2D a, Shape2D b)
        {
            if (a.Position.X < b.Position.X + b.Scale.Width &&
                a.Position.X + a.Scale.Width > b.Position.X &&
                a.Position.Y < b.Position.Y + b.Scale.Height &&
                a.Position.Y + a.Scale.Height > b.Position.Y)
            {
                return true;
            }
            return false;
        }
    }
}
