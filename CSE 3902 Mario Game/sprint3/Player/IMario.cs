using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public interface IMario : IGameObject
    {
        MarioStateMachine.MarioSize Size();
        MarioStateMachine.MarioState State();
        MarioStateMachine.MarioHealth Health();
        IPhysics Physics { get; set; }
        Color Shade { get; set; }
        bool ShouldCollide {get; set;}
        Vector2 Location { get; set; }
        bool CanJump { get; set; }
        bool IsMovingVertically { get; set; }
        bool FacingLeft();
        void SetSmall();
        void SetBig();
        void SetFire();
        void SetLeft();
        void SetRight();
        void Idle();
        void Run();
        void Jump();
        void Duck();
        void KillMario();
        void TakeDamage();
        void SetPosition(Vector2 location);
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gameTime);
        void AddStar();
        bool marioCanTransition { get; set; }
        bool marioCanTransitionLeftPipe { get; set; }
        bool DrawInvisibleSprite { get; set; }
    }
}
