using System.Dynamic;
using Raylib_cs;

public class Point : GameObject {

    private int _pointValue;
    public Point(double x, double y, double velocityY, double width, double height) : base(x, y, velocityY, width, height)
    {
        Random _random = new Random();
        _pointValue = _random.Next(1,5);
    }
    public int GetPoint()
    {
        return _pointValue;
    }

    public override void Draw()
    {
        Raylib.DrawRectangle((int)_x, (int)_y, (int)_width, (int)_height, Color.Purple);
    }

    public override void ProcessActions()
    {
        _y += _velocity;
    }
    
    public override void CollideWith(GameObject Other)
    {
        if (Other is Player)
        {
            Player player = (Player)Other;
            player.CollideWith(this);
        }
    }
}