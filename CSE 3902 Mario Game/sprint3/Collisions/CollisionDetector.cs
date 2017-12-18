using Microsoft.Xna.Framework;

namespace MarioGame
{
    public static class CollisionDetector
    {
        public const int MinIntersectionSize = 3;
        public static ICollision detectCollision(IGameObject obj1, IGameObject obj2)
        {
            ICollision side = new NullCollision();
            Rectangle rect1 = obj1.DestinationRectangle;
            Rectangle rect2 = obj2.DestinationRectangle;
            if (rect1.Intersects(rect2))
            {
                Rectangle intersection = Rectangle.Intersect(rect1, rect2);
                if (intersection.Width > MinIntersectionSize || intersection.Height > MinIntersectionSize)
                {
                    if (intersection.Width >= intersection.Height && rect1.Top <= rect2.Center.Y)
                    {
                        side = new Top(intersection);
                        side.TopOrLeft = obj1;
                        side.BottomOrRight = obj2;
                    }
                    else if (intersection.Width >= intersection.Height && rect1.Bottom > rect2.Center.Y)
                    {
                        side = new Bottom(intersection);
                        side.TopOrLeft = obj2;
                        side.BottomOrRight = obj1;
                    }
                    else if (intersection.Width < intersection.Height && rect1.Center.X >= rect2.Center.X)
                    {
                        side = new Right(intersection);
                        side.TopOrLeft = obj2;
                        side.BottomOrRight = obj1;
                    }
                    else if (intersection.Width < intersection.Height && rect1.Center.X < rect2.Center.X)
                    {
                        side = new Left(intersection);
                        side.TopOrLeft = obj1;
                        side.BottomOrRight = obj2;
                    }
                }
            }
            return side;
        }
    }
}
