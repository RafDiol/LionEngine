using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LionEngine.LionEngine;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace LionEngine
{
    public class DemoGame : LionEngine.LionEngine
    {
        //Shape2D shape;
        Sprite2D sprite;
        bool left, right, up, down;
        float speed = 5f;
        Random rnd = new Random();
        //SoundPlayer soundPlayer;

        public DemoGame() : base(new Scale(512, 512), "New Game")
        {
           
        }

        public override void OnLoad()
        {
            sprite = new Sprite2D(new Vector2(100, 100), new Scale(100, 100), @"C:\Users\rafae\source\repos\LionEngine\LionEngine\Images\img1.jpg");
            for (int i =0; i < 20; i++)
            {
                Sprite2D coin = new Sprite2D(new Vector2(rnd.Next(0, 800), rnd.Next(0, 800)), new Scale(50, 50), @"C:\Users\rafae\source\repos\LionEngine\LionEngine\Images\coin.jpg");
            }
            //soundPlayer = new SoundPlayer(@"C:\Users\rafae\source\repos\LionEngine\LionEngine\Sounds\big_bopper_hello_baby.wav");
        }

        public override void OnUpdate()
        {
            Movement();
            Object collide;
            if (sprite.isColliding(out collide))
            {
                try
                {
                    Sprite2D coin = (Sprite2D)collide;
                    coin.DestroySelf();
                }
                catch
                {
                    Shape2D coin = (Shape2D)collide;
                    coin.DestroySelf();
                }
            }
        }

        public override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A) { left = true; }
            if (e.KeyCode == Keys.D) { right = true; }
            if (e.KeyCode == Keys.S) { down = true; }
            if (e.KeyCode == Keys.W) { up = true; }
        }

        public override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A) { left = false; }
            if (e.KeyCode == Keys.D) { right = false; }
            if (e.KeyCode == Keys.S) { down = false; }
            if (e.KeyCode == Keys.W) { up = false; }
        }

        private void Movement()
        {
            if (up)
            {
                sprite.Position.Y -= speed;
            }
            if (down)
            {
                sprite.Position.Y += speed;
            }
            if (left)
            {
                sprite.Position.X -= speed;
            }
            if (right)
            {
                sprite.Position.X += speed;
            }
        }
    }
}
