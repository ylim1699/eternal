using System.Numerics;
using System.Runtime.Intrinsics;
using Raylib_cs;

public class Obstacle : GameObject {
    public Obstacle(double x, double y, double velocityY) : base(x, y, velocityY)
    {     
    }

    public override void Draw()
    {
        Raylib.DrawRectangle((int)_x, (int)_y, 20, 20, Color.Red);
    }

    public override void ProcessActions()
    {
        _y += _velocity;
    }
    
    public override void CollideWith(GameObject other)
    {
        throw new NotImplementedException();
    }
}