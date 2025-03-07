using Godot;
using System;

public partial class Pipes : Node2D
{
    const float SCROLL_SPEED = 120.0f;

    [Export] private VisibleOnScreenNotifier2D _visibleOnScreenNotifier;
    [Export] private Area2D _upperPipe;
    [Export] private Area2D _lowerPipe;
    [Export] private Area2D _laser;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _visibleOnScreenNotifier.ScreenExited += OnScreenExited;
        _lowerPipe.BodyEntered += OnPipeBodyEntered;
        _upperPipe.BodyEntered += OnPipeBodyEntered;
        _laser.BodyEntered += OnLaserBodyEntered;
    }

    private void OnLaserBodyEntered(Node2D body)
    {
        GD.Print("Scored");
    }

    private void OnPipeBodyEntered(Node2D body)
    {
        if (body is Plane)
        {
            // GD.Print("OnPipeBodyEntered: ", body.Name);
            (body as Plane).Die();
        }
        // Alternative using SceneGroup
        // if (body.IsInGroup("plane"))
        // {
        //     (body as Plane).Die();
        // }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        Position -= new Vector2(SCROLL_SPEED * (float)delta, 0.0f);
    }

    private void OnScreenExited()
    {
        QueueFree();
    }
}
