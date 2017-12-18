using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public interface IKoopa : IGameObject
    {
        bool shouldCollide { get; set; }
        bool BeRemoved { get; set; }
        void Draw(SpriteBatch spriteBatch, Vector2 Location, Color shade);
        void Update();
        void SetPosition(Vector2 location);
        void ChangeDirection();
        void KillKoopa();
        KoopaStateMachine.KoopaHealth Health { get; set; }
        Vector2 Location { get; set; }
        IPhysics Physics { get; set; }
        void BeShelled();
    }
}
