using System.Collections.Generic;
using Godot;

public partial class PlayerStateMachine : Node
{
    public List<State> states = new List<State>();
    public State prevState { get; set; }
    public State currentState { get; set; }

    public override void _Ready()
    {
        ProcessMode = ProcessModeEnum.Disabled;
    }

    public override void _Process(double delta) { }

    public void Initialize()
    {
        foreach (Node c in GetChildren())
        {
            if (c is State)
                states.Add((State)c);
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
