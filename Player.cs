using Raylib_cs;

public class Player : GameObject {
private int points = 0;
private int life = 3;
private int _score = 0;
    public Player (double x, double y, double velocityX) : base(x, y, velocityX)
    {}
    public override void Draw()
    {
        Raylib.DrawRectangle((int)_x, (int)_y, 35, 10, Color.Blue);   
    }

    public override void ProcessActions()
    {
        if (Raylib.IsKeyDown(KeyboardKey.Left))
        {
            _x -= _velocity;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.Right))
        {
            _x += _velocity;
        }
    }

    public override void CollideWith(GameObject other)
    {
        if (other is Points)
        {
            Points point = (Points)other;
            _score += point.GetPoint(); 
        }
    }

}