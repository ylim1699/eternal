using Raylib_cs;

public class Player : GameObject {
private int _points = 0;
private int _life = 3;
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
        
        if (GetLeftEdge() < 0) 
        {
            _x = 0;
        }
        else if (GetRightEdge() > GameManager.SCREEN_WIDTH)
        {
            _x = GameManager.SCREEN_WIDTH - _width;
        }
    }

    public override void CollideWith(GameObject other)
    {
        if (other is Point)
        {
            Point point = (Point)other;
            _score += point.GetPoint(); 
            point.Kill();
        }
        else if (other is Obstacle)
        {
            Obstacle obstacle = (Obstacle)other;
            _life -= 1;
            obstacle.Kill();
        }
    }

}