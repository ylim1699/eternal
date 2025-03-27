using Raylib_cs;

public abstract class GameObject {
    protected double _x;
    protected double _y;
    protected double _velocity;

     public GameObject(double x, double y, double velocity)
    {
        _x = x;
        _y = y;
        _velocity = velocity;
    }

    public abstract void Draw(); 

    public abstract void ProcessActions();

    public void CollideWith() 
    {
        bool CheckCollisionCircleRec(Vector2 center, float radius, Rectangle rec);  
    }
}