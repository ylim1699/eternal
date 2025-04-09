using System.Numerics;
using System.Runtime.Intrinsics;
using Raylib_cs;

public class Obstacle : GameObject {
    public Obstacle(double x, double y, double velocityY,  double width, double height) : base(x, y, velocityY, width, height)
    {     
    }

    public override void Draw()
    {
        Raylib.DrawRectangle((int)_x, (int)_y, (int)_width, (int)_height, Color.Red);
    }

    public override void ProcessActions()
    {
        _y += _velocity;
    }
    
    public override void CollideWith(GameObject other)
    {
    }
}