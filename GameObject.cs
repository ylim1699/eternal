using System.Runtime.CompilerServices;
using Raylib_cs;

public abstract class GameObject {
    protected double _x;
    protected double _y;
    protected double _velocity;
    protected double _width;
    protected double _height;
    protected bool _life = true;
     public GameObject(double x, double y, double velocity)
    {
        _x = x;
        _y = y;
        _velocity = velocity;
    }

    public GameObject(double x, double y, double velocity, double width, double height)
    {
        _x = x;
        _y = y;
        _velocity = velocity;
        _width = width;
        _height = height;
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

    public bool IsAlive()
    {
        return _life;
    }
    
    public void Kill()
    {
        _life = false;
    }

    public virtual void CollideWith()
    {}
}