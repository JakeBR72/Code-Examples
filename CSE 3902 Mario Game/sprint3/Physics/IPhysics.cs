using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame
{
    public interface IPhysics
    {
        // pixels subtracted from YVelocity per second 
        double GravityCoef { get; set; }
        // pixel change per second
        double XVelocity { get; set; }
        // pixel change per second
        double YVelocity { get; set; }
        double XMaxVelocity { get; set; }
        double XMinVelocity { get; set; }
        double YMaxVelocity { get; set; }
        double YMinVelocity { get; set; }
        Vector2 MaxPosition { get; set; }
        Vector2 MinPosition { get; set; }
        bool IsMovingX();
        bool IsMovingY();
        void UpdatePosition();
    }
}
