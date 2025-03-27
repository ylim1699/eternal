using Raylib_cs;

public class Points : FallingObject {
    private List<int> _points = [1, 2, 3, 5];

    public Points(double x, double y, double velocityY) : base(x, y, velocityY)
    {}

    public override void Draw()
    {
        Raylib.DrawCircleLines((int)_x, (int)_y, 10, Color.Black);
    }

    public override void ProcessActions()
    {
        _y += _velocity;
    }
    
    public override void CollideWith()
    {
        throw new NotImplementedException();
    }
}