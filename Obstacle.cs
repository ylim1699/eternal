public class Obstacle : FallingObject {
    public Obstacle(double x, double y, double velocityY) : base(x, y, velocityY)
    {

    }

    public override void Draw()
    {
        
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