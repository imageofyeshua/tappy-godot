using System;
using Godot;

public partial class Plane : CharacterBody2D
{
    const float GRAVITY = 800.0f;
    const float POWER = -450.0f;

    [Export] private AnimationPlayer _animationPlayer;
    [Export] private AnimatedSprite2D _planeSprite;

    [Signal] public delegate void OnPlaneDiedEventHandler();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() { }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;
        velocity.Y += GRAVITY * (float)delta;

        if (Input.IsActionJustPressed("fly"))
        {
            velocity.Y = POWER;
            _animationPlayer.Play("power");
        }

        Velocity = velocity;
        MoveAndSlide();

        if (IsOnFloor())
        {
            Die();
        }
    }

    private void Die()
    {
        SetPhysicsProcess(false);
        _planeSprite.Stop();
        GD.Print("Die");
        EmitSignal(SignalName.OnPlaneDied);
    }
}
