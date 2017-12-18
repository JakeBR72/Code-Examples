using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MarioGame
{
    public class Mario : IMario
    {
        private MarioStateMachine StateMachine;
        private Game1 theGame;
        public bool marioCanTransition { get; set; }
        public bool marioCanTransitionLeftPipe { get; set; }
        public bool ShouldUpdate { get; set; }
        public bool ShouldCollide {
            get {return StateMachine.ShouldCollide;}
            set {StateMachine.ShouldCollide = value;}
        }
        public bool DrawInvisibleSprite { get { return StateMachine.DrawInvisibleSprite; } set { StateMachine.DrawInvisibleSprite = value; } }
        public IPhysics Physics {
            get { return StateMachine.Physics;}
            set {StateMachine.Physics = value;}
        }
        public bool CanJump { get; set; }
        public Vector2 Location
        {
            get { return StateMachine.Location;}
            set { StateMachine.Location = value;}
        }
        public Color Shade
        {
            get { return StateMachine.Shade;}
            set { StateMachine.Shade = value;}
        }
        public Rectangle DestinationRectangle
        {
            get { return StateMachine.Destination;}
            set { StateMachine.Destination = value;}
        }
        public bool IsMovingVertically
        {
            get { return StateMachine.IsMovingVertically; }
            set { StateMachine.IsMovingVertically = value; }
        }
        public Mario(Vector2 location, Game1 game)
        {
            StateMachine = new MarioStateMachine();
            StateMachine.SetPosition(location);
            theGame = game;
            Physics = new MarioPhysics(this,game);
            CanJump = true;
        }
        public MarioStateMachine.MarioSize Size()
        {
            return StateMachine.Size;
        }
        public MarioStateMachine.MarioState State()
        {
            return StateMachine.State;
        }
        public MarioStateMachine.MarioHealth Health()
        {
            return StateMachine.Health;
        }
        public bool FacingLeft()
        {
            return StateMachine.FacingLeft;
        }

        public void SetSmall()
        {
            StateMachine.SetSmall();
        }
        public void SetBig()
        {
            StateMachine.SetBig();
        }
        public void SetFire()
        {
            StateMachine.SetFire();
        }

        public void SetLeft()
        {
            StateMachine.SetLeft();
        }
        public void SetRight()
        {
            StateMachine.SetRight();
        }
        public void Idle()
        {
            StateMachine.Idle();
        }
        public void Run()
        {
            StateMachine.Run();
        }
        public void Jump()
        {
            StateMachine.Jump();
        }
        public void Duck()
        {
            StateMachine.Duck();
        }
        public void KillMario()
        {
            StateMachine.KillMario();
        }
        public void TakeDamage()
        {
            StateMachine.TakeDamage();            
        }
        public void SetPosition(Vector2 location)
        {
            if (Location.Y != location.Y)
            {
                IsMovingVertically = true;
                CanJump = false;
            }
            StateMachine.SetPosition(location);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            StateMachine.Draw(spriteBatch);
        }
        public void Update(GameTime gameTime)
        {
            StateMachine.Update(gameTime);
        }

        public void AddStar()
        {
            theGame.Mario = new StarMario(this, theGame);
        }
    }
}
