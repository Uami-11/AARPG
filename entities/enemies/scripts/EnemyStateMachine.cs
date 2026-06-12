using System.Collections.Generic;
using Godot;

public partial class EnemyStateMachine : Node
{
    public List<EnemyState> states = new List<EnemyState>();

    public EnemyState prevState;
    public EnemyState currentState;

    public override void _Ready()
    {
        ProcessMode = ProcessModeEnum.Disabled;
    }

    public void Initialize(Enemy them)
    {
        foreach (Node c in GetChildren())
        {
            if (c is EnemyState)
                states.Add((EnemyState)c);
        }

        foreach (EnemyState state in states)
        {
            state.enemy = them;
            state.stateMachine = this;
            state.Init();
        }
        if (states.Count > 0)
        {
            ChangeState(states[0]);
            ProcessMode = ProcessModeEnum.Inherit;
        }
    }

    public override void _Process(double delta) { }

    public void ChangeState(EnemyState newState)
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
