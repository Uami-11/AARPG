using Godot;

public partial class EnemyState : Node
{
    public Enemy enemy;

    public EnemyStateMachine stateMachine;

    public virtual void Init() { }

    public override void _Ready() { }

    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual EnemyState Process(double delta)
    {
        return null;
    }

    public virtual EnemyState Physics(double delta)
    {
        return null;
    }
}
