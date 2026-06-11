using System.Collections.Generic;
using Godot;

public partial class PlayerStateMachine : Node
{
    // [Export]
    // public Player you;

    public List<State> states = new List<State>();
    public State prevState { get; set; }
    public State currentState { get; set; }

    public override void _Ready()
    {
        ProcessMode = ProcessModeEnum.Disabled;
    }

    public override void _Process(double delta)
    {
        ChangeState(currentState.Process(delta));
    }

    public override void _PhysicsProcess(double delta)
    {
        ChangeState(currentState.Physics(delta));
    }

    public override void _UnhandledInput(InputEvent @event)
    {
        ChangeState(currentState.HandleInput(@event));
    }

    public void Initialize(Player you)
    {
        foreach (Node c in GetChildren())
        {
            if (c is State)
                states.Add((State)c);

            if (states.Count > 0)
            {
                states[0].player = you;
                ChangeState(states[0]);
                ProcessMode = ProcessModeEnum.Inherit;
            }
        }
    }

    public void ChangeState(State newState)
    {
        if (newState == null || newState == currentState)
            return;

        if (currentState != null)
            currentState.Exit();

        prevState = currentState;

        currentState = newState;
        currentState.Enter();
    }
}
