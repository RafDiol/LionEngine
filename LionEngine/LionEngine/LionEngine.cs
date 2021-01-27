using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace LionEngine.LionEngine
{

    class Canvas : Form 
    {
        public Canvas()
        {
            this.DoubleBuffered = true;
        }
    }

    public abstract class LionEngine
    {
        private Scale ScreenSize = new Scale(512, 512);
        private string Title;
        private Canvas Window = null;
        private Thread GameLoopThread;

        public Color BackgroundColor = Color.Aqua;

        private static List<Shape2D> AllShapes2D = new List<Shape2D>();
        private static List<Sprite2D> AllSprites2D = new List<Sprite2D>();


        public LionEngine(Scale ScreenSize, string Title)
        {
            this.ScreenSize = ScreenSize;
            this.Title = Title;

            Window = new Canvas();
            Window.Size = new Size((int)ScreenSize.Width, (int)ScreenSize.Height);
            Window.Text = Title;
            Window.Paint += Renderer;
            Window.KeyDown += KeyDown;
            Window.KeyUp += KeyUp;
            Window.MouseDown += MouseDown;
            Window.MouseUp += MouseUp;
            Window.MouseMove += MouseMove;
            Window.MouseDoubleClick += MouseDoubleClick;

            // Lets Start our Game Loop

            GameLoopThread = new Thread(GameLoop);
            GameLoopThread.Start();

            Application.Run(Window);
        }

        private void KeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDown(e);
        }

        private void KeyUp(object sender, KeyEventArgs e)
        {
            OnKeyUp(e);
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp(e);
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMoved(e);
        }

        private void MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OnMouseDoubleClicked(e);
        }

        private void GameLoop()
        {
            // If you have set an OnLoad method then you can run code before your game starts
            OnLoad();
            while (GameLoopThread.IsAlive)
            {
                try
                {
                    OnDraw();
                    Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });
                    OnUpdate();
                    Thread.Sleep(1);
                }
                catch
                {
                    Log.Error("Game has not started yet...");
                }
            }
            OnClosed();
        }


        /// <summary>
        ///  Registers a shape which makes it render.
        ///  There is no need to manually call it since it is called from the shape constructor
        /// </summary>
        /// <param name="shape"></param>
        public static void RegisterShape(Shape2D shape)
        {
            AllShapes2D.Add(shape);
        }

        /// <summary>
        ///  Unregisters a shape and thus stops it from rendering.
        ///  There is no need to manually call it since it is called from the shape constructor
        /// </summary>
        /// <param name="shape"></param>
        public static void UnregisterShape(Shape2D shape)
        {
            AllShapes2D.Remove(shape);
        }

        /// <summary>
        /// Registers a sprite which makes it render.
        /// There is no need to manually call it since it is called from the sprite constructor
        /// </summary>
        /// <param name="sprite"></param>
        public static void RegisterSprite(Sprite2D sprite)
        {
            AllSprites2D.Add(sprite);
        }

        /// <summary>
        /// Unregisters a sprite and thus stops it from rendering.
        /// There is no need to manually call it since it is called from the sprite constructor
        /// </summary>
        /// <param name="sprite"></param>
        public static void UnregisterSprite(Sprite2D sprite)
        {
            AllSprites2D.Remove(sprite);
        }

        public static List<Sprite2D> getAllSprites2D()
        {
            return AllSprites2D;
        }

        public static List<Shape2D> getAllShapes2D()
        {
            return AllShapes2D;
        }


        public void setTitle(string title)
        {
            this.Title = title;
            this.Window.Text = this.Title;
        }

        public string getTitle()
        {
            return this.Title;
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.Clear(BackgroundColor);

            foreach (Shape2D shape in AllShapes2D)
            {
                graphics.FillRectangle(new SolidBrush(shape.Color), shape.Position.X, shape.Position.Y, shape.Scale.Width, shape.Scale.Height);
            }
            foreach (Sprite2D sprite in AllSprites2D)
            {
                graphics.DrawImage(sprite.Sprite, sprite.Position.X, sprite.Position.Y, sprite.Scale.Width, sprite.Scale.Height);
            }
        }

        // Methods the user can implement

        public virtual void OnLoad()
        {

        }

        public virtual void OnDraw()
        {

        }

        public virtual void OnUpdate()
        {

        }

        public virtual void OnClosed()
        {

        }

        public virtual void OnKeyDown(KeyEventArgs e)
        {

        }

        public virtual void OnKeyUp(KeyEventArgs e)
        {

        }

        public virtual void OnMouseDown(MouseEventArgs e)
        {

        }
        public virtual void OnMouseUp(MouseEventArgs e)
        {

        }

        public virtual void OnMouseMoved(MouseEventArgs e)
        {

        }
        public virtual void OnMouseDoubleClicked(MouseEventArgs e)
        {

        }
    }
}
