using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame
{
    public interface IBowser : IGameObject
    {
        bool BeRemoved { get; set; }
        void Draw(SpriteBatch spriteBatch, Vector2 Location, Color shade);
        void Update();
        void SetPosition(Vector2 location);
        void ChangeDirection();
        Vector2 Location { get; set; }
        IPhysics Physics { get; set; }
    }
}
