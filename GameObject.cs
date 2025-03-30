using Raylib_cs;

public abstract class GameObject {
    protected double _x;
    protected double _y;
    protected double _velocity;
    protected double _width;
    protected double _height;

     public GameObject(double x, double y, double velocity)
    {
        _x = x;
        _y = y;
        _velocity = velocity;
    }

    public abstract void Draw(); 

    public abstract void ProcessActions();

    public abstract void CollideWith(GameObject other);

    public virtual double GetLeftEdge()
    {
        return _x;
    }

    public virtual double GetRightEdge()
    {
        return _x + _width;
    }

    public virtual double GetTopEdge()
    {
        return _y;
    }

    public virtual double GetBottomEdge()
    {
        return _y + _height;
    }

    // if (GetLeftEdge() < 0)
    // {
    //     _x = 0;
    // }
    // else if (GetRightEdge() > GameManager.SCREEN_WIDTH)
    // {
    //     _x = GameManager.SCREEN_WIDTH;
    // }
}