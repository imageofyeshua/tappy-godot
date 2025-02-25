using Godot;
using System;

public partial class SignalManager : Node
{
    public static SignalManager Instance { get; private set; }

    [Signal] public delegate void OnPlaneDiedEventHandler();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Instance = this;
    }

    public static void EmitOnPlaneDied()
    {
        Instance.EmitSignal(SignalName.OnPlaneDied);
    }
}
