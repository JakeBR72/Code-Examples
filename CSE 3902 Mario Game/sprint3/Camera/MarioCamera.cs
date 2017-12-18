using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace MarioGame
{
    class MarioCamera : ICamera
    {
        public bool ShouldUpdate { get; set; }
        public Rectangle DestinationRectangle { get; set; }
        private Game1 Game;
        private Vector2 Position;
        private int XPos;
        private Vector2 Origin;
        private Viewport _viewport;
        private float Zoom;
        private int deltaXPosition;
        private int speed;

        public MarioCamera(Viewport viewport, Game1 game)
        {
            ShouldUpdate = true;
            Game = game;
            _viewport = new Viewport(0,0, viewport.Width/2, viewport.Height/2);
            Zoom = 2f;
            Origin = new Vector2(0,0);
            Position = new Vector2(0,0);
            XPos = 0;
            DestinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, _viewport.Width, _viewport.Height);
        }
        public void Update(IGameObject Target)
        {
            if (ShouldUpdate)
            {
                speed = Math.Abs(Target.DestinationRectangle.Location.X - deltaXPosition);
                if (speed == 0)
                {
                    speed = 2;
                }
                deltaXPosition = Target.DestinationRectangle.Location.X;
                Position = new Vector2(XPos, 0);
                if (Target.DestinationRectangle.X - XPos < -_viewport.Width)
                {
                    XPos = Target.DestinationRectangle.X;
                }
                if (Target.DestinationRectangle.X - XPos > 2.5 * _viewport.Width / 4 && Game.parser.GetLevel() != "1-1G")
                {
                    XPos += speed;
                }
                else if (Target.DestinationRectangle.X - XPos < 1.5 * _viewport.Width / 4)
                {
                    XPos -= speed;
                }
                XPos = MathHelper.Clamp(XPos, 0, 3008);
                DestinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, _viewport.Width, _viewport.Height);
            }
        }
        public Matrix GetViewMatrix()
        {
            return
            Matrix.CreateTranslation(new Vector3(-Position, 0.0f)) *
            Matrix.CreateTranslation(new Vector3(-Origin, 0.0f)) *
            Matrix.CreateRotationZ(0) *
            Matrix.CreateScale(Zoom, Zoom, 1) *
            Matrix.CreateTranslation(new Vector3(Origin, 0.0f));
        }
        /*Used Code from http://www.dylanwilson.net/implementing-a-2d-camera-in-monogame
         * "Implementing a 2D Camera in MonoGame." - Dylanwilson.net. N.p., n.d. Web. 19 Oct. 2016.
         * */
    }
}
