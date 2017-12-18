using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    class StarMario : IMario
    {
        public bool ShouldUpdate { get; set; }
        public bool ShouldCollide {
            get { return decoratedMario.ShouldCollide; }
            set { decoratedMario.ShouldCollide = value;}
        }
        public bool DrawInvisibleSprite { get; set; }

        private int timer = 1500;
        public bool marioCanTransition { get; set; }
        public bool marioCanTransitionLeftPipe { get; set; }
        private Color[] colorRotation = {Color.White, Color.Red,
            Color.Orange, Color.Yellow, Color.Green, Color.BlueViolet };
        private int colorIndex = 0;

        private IMario decoratedMario;
        private Game1 theGame;
        public bool CanJump
        {
            get { return decoratedMario.CanJump;}
            set { decoratedMario.CanJump = value;}
        }
        public IPhysics Physics
        {
            get { return decoratedMario.Physics;}
            set { decoratedMario.Physics = value;}
        }
        public Vector2 Location
        {
            get { return decoratedMario.Location;}
            set { decoratedMario.Location = value;}
        }
        public Rectangle DestinationRectangle
        {
            get { return decoratedMario.DestinationRectangle;}
            set { decoratedMario.DestinationRectangle = value;}
        }
        public Color Shade
        {
            get { return decoratedMario.Shade;}
            set { decoratedMario.Shade = value;}
        }
        public bool IsMovingVertically
        {
            get { return decoratedMario.IsMovingVertically; }
            set { decoratedMario.IsMovingVertically = value; }
        }
        public StarMario (IMario decoratedMario, Game1 game)
        {
            this.decoratedMario = decoratedMario;
            theGame = game;
            MusicManager.Instance.SetBackgroundMusic("star-theme");
        }
        public MarioStateMachine.MarioSize Size()
        {
            return decoratedMario.Size();
        }
        public MarioStateMachine.MarioState State()
        {
            return decoratedMario.State();
        }
        public MarioStateMachine.MarioHealth Health()
        {
            return decoratedMario.Health();
        }

        public bool FacingLeft()
        {
            return decoratedMario.FacingLeft();
        }

        public void SetSmall()
        {
            decoratedMario.SetSmall();
        }
        public void SetBig()
        {
            decoratedMario.SetBig();
        }
        public void SetFire()
        {
            decoratedMario.SetFire();
        }

        public void SetLeft()
        {
            decoratedMario.SetLeft();
        }
        public void SetRight()
        {
            decoratedMario.SetRight();
        }
        public void Idle()
        {
            decoratedMario.Idle();
        }
        public void Run()
        {
            decoratedMario.Run();
        }
        public void Jump()
        {
            decoratedMario.Jump();
        }
        public void Duck()
        {
            decoratedMario.Duck();
        }

        public void KillMario()
        {
            
        }
        public void TakeDamage()
        {
            
        }
        public void SetPosition(Vector2 location)
        {
            decoratedMario.SetPosition(location);
            Location = location;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            if (timer % 9 == 0)
            {
                colorIndex++;
                if(colorIndex == colorRotation.Length)
                {
                    colorIndex = 0;
                }
                Shade = colorRotation[colorIndex];
            }
            decoratedMario.Draw(spriteBatch);
        }
        public void Update(GameTime gameTime)
        {
            timer--;
            if(timer ==0)
            {
                RemoveStar();
            }
            decoratedMario.Update(gameTime);
        }

        public void RemoveStar()
        {
            theGame.Mario.Shade = Color.White;
            MusicManager.Instance.SetBackgroundMusic("main-theme");
            theGame.Mario = decoratedMario;
            theGame.st.EndStarCombo();
        }

        public void AddStar()
        {
            
        }
    }
}
