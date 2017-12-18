using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace MarioGame
    {
    class Fireball : IObject
    {
        public bool ShouldUpdate { get; set; } = true;
        public bool BeRemoved { get; set; }
        public Vector2 Location { get; set; }
        public Texture2D Texture;
        public int Rows;
        public int Columns;
        private int currentFrame;
        private int totalFrames;
        private int i;
        public bool isWarpPipe { get; set; }
        public bool isExitPipe { get; set; }
        public int fireBallJump {get; set;}
        public bool collisionBlock = false;
        public bool collisionPipe = false;
        public bool collisionEnemy = false;
        public IPhysics physics;
        public Rectangle DestinationRectangle { get; set; }

        public Fireball(Texture2D texture, int rows, int columns)
        {
            physics = new FireBallPhysics(this);
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            i = 0;
            fireBallJump = 0;
            BeRemoved = false;
        }
        public void Update()
        {
            physics.UpdatePosition();
            if (i > 10)
            {
                currentFrame++;
                i = 0;
            }
            else if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
            i++;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
            {

                int width = Texture.Width / Columns;
                int height = Texture.Height / Rows;
                int row = (int)((float)currentFrame / (float)Columns);
                int column = currentFrame % Columns;
                Location = location;

                Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
                 DestinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, transformMatrix: Game1.MainCamera.GetViewMatrix());
                spriteBatch.Draw(Texture, DestinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
        }
    }