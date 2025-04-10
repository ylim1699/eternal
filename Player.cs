using Raylib_cs;

public class Player : GameObject {
private int _health = 3;
private int _score = 0;
private int _level = 1;
    public Player (double x, double y, double velocityX,  double width, double height) : base(x, y, velocityX, width, height)
    {}
    public override void Draw()
    {
        Raylib.DrawRectangle((int)_x, (int)_y, (int)_width, (int)_height, Color.Blue);   
        Raylib.DrawText($"Points:{_score}", 10, 10, 20, Color.Black);
        Raylib.DrawText($"Life:{_health}", 700, 10, 20, Color.Black);
        Raylib.DrawText($"Level:{_level}", 350, 10, 20, Color.Black);
        Raylib.DrawText($"You win if you get to 500 points", 350, 580, 10, Color.Black);
    }

    public int GetHealth()
    {
        return _health;
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
        
        // This is how to make it so that your player doesn't go out of screen. Make sure to give the parameter for _width when you make an instance of your player in Gamemanager
        if (GetLeftEdge() < 0) 
        {
            _x = 0;
        }
        else if (GetRightEdge() > GameManager.SCREEN_WIDTH)
        {
            _x = GameManager.SCREEN_WIDTH - _width;
        }

        if (GetHealth() == 0)
        {
            Raylib.CloseWindow();
        }

         if (_score == 100)
        {
            _level = 2;
        }
        else if (_score == 200)
        {
            _level = 3;
        }
        else if (_score == 300)
        {
            _level = 4;
        }
        else if (_score == 400)
        {
            _level = 5;
        }
        else if (_score == 500)
        {
            Raylib.CloseWindow();
        }

    }

    public override void CollideWith(GameObject other)
    {
        // You only need to put in stuff to override CollideWith function in player class. 
        if (other is Point)
        {
            Point point = (Point)other;
            _score += point.GetPoint(); 
            point.Kill();
        }
        else if (other is Obstacle)
        {
            Obstacle obstacle = (Obstacle)other;
            _health -= 1;
            obstacle.Kill();
        }
    }
}