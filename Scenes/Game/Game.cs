using Godot;
using System;

public partial class Game : Node2D
{
    [Export] private Marker2D _spawnUpper;
    [Export] private Marker2D _spawnLower;
    [Export] private Node2D _pipesHolder;
    [Export] private Timer _spawnTimer;
    [Export] private PackedScene _pipesScene;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // GD.Print($"{GetSpawnY()}");
        _spawnTimer.Timeout += SpawnPipes;

        SpawnPipes();
    }

    private void SpawnPipes()
    {
        Pipes np = _pipesScene.Instantiate<Pipes>();
        _pipesHolder.AddChild(np);
        np.GlobalPosition = new Vector2(_spawnLower.GlobalPosition.X, GetSpawnY());
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {

    }

    public float GetSpawnY()
    {
        return (float)GD.RandRange(_spawnUpper.GlobalPosition.Y, _spawnLower.GlobalPosition.Y);
    }
}
