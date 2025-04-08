using System.Numerics;
using Raylib_cs;

class GameManager
{
    public const int SCREEN_WIDTH = 800;
    public const int SCREEN_HEIGHT = 600;
    public const double POINT_SPAWN_RATE = 0.02;
    public const double OBSTACLE_SPAWN_RATE = 0.02;
    public const float v1 = 20;
    private string _title;

    private List<GameObject> _gameObjects = new List<GameObject>(); 

    Random _random = new Random();

    public GameManager()
    {
        _title = "CSE 210 Game";
    }

    /// <summary>
    /// The overall loop that controls the game. It calls functions to
    /// handle interactions, update game elements, and draw the screen.
    /// </summary>
    public void Run()
    {
        Raylib.SetTargetFPS(60);
        Raylib.InitWindow(SCREEN_WIDTH, SCREEN_HEIGHT, _title);
        // If using sound, un-comment the lines to init and close the audio device
        // Raylib.InitAudioDevice();
    
        InitializeGame();

        while (!Raylib.WindowShouldClose())
        {
            HandleInput();
            ProcessActions();

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            DrawElements();

            Raylib.EndDrawing();
        }

        // Raylib.CloseAudioDevice();
        Raylib.CloseWindow();
    }

    /// <summary>
    /// Sets up the initial conditions for the game.
    /// </summary>
    private void InitializeGame()
    {
        Random random = new Random();
        int x1 = random.Next(0, SCREEN_WIDTH);
        int x2 = random.Next(0, SCREEN_WIDTH);

        Player player = new Player(SCREEN_WIDTH / 2, SCREEN_HEIGHT - 50, 10);
        _gameObjects.Add(player);

        Point points = new Point(x1, 0, 10);
        _gameObjects.Add(points);

        Obstacle obstacles = new Obstacle(x2, 0, 10);
        _gameObjects.Add(obstacles);
    }

    /// <summary>
    /// Responds to any input from the user.
    /// </summary>
    private void HandleInput()
    {

    }

    /// <summary>
    /// Processes any actions such as moving objects or handling collisions.
    /// </summary>
    private void ProcessActions()
    {
        foreach (GameObject items in _gameObjects)
        {
            items.ProcessActions();
        }

        // if (GetLeftEdge() < 0) game manager
        // {
        //     _x = 0;
        // }
        // else if (GetRightEdge() > GameManager.SCREEN_WIDTH)
        // {
        //     _x = GameManager.SCREEN_WIDTH;
        // }

        SpawnItems();
        // CleanItems();
    }

    public bool IsCollision(GameObject first, GameObject second)
    {   
        bool isTouching = false;

        if (first.GetRightEdge() > second.GetLeftEdge()
            && first.GetLeftEdge() < second.GetRightEdge()
            && first.GetTopEdge() < second.GetBottomEdge()
            && first.GetBottomEdge() > second.GetTopEdge())
            {
                isTouching = true;
            }
        return isTouching;
    }


    /// <summary>
    /// Draws all elements on the screen.
    /// </summary>
    private void DrawElements()
    {
        foreach (GameObject item in _gameObjects)
        {
            item.Draw();
        }
    }

    private void SpawnItems()
    {
        Random random = new Random();

        double pointNumber = random.NextDouble();

        if (pointNumber < POINT_SPAWN_RATE)
        {
            int x = random.Next(0, SCREEN_WIDTH);
            Point point = new Point(x, 0, 10);
            _gameObjects.Add(point);
        }

        double obstacleNumber = random.NextDouble();

        if (obstacleNumber < OBSTACLE_SPAWN_RATE)
        {
            int x = random.Next(0, SCREEN_WIDTH);
            Obstacle obstacle = new Obstacle(x, 0, 10);
            _gameObjects.Add(obstacle);
        }
    }

    private void CleanItems()
    {
        _gameObjects.RemoveAll(e => !e.IsAlive());            
    }


}