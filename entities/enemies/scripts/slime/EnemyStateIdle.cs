using Godot;

public partial class EnemyStateIdle : EnemyState
{
    private RandomNumberGenerator RandalThor = new RandomNumberGenerator();

    [Export]
    public string animName = "idle";

    [ExportCategory("AI")]
    [Export]
    public float stateDurationMin = 0.5f;

    [Export]
    public float stateDurationMax = 1.5f;

    [Export]
    public EnemyState afterIdleState;

    [Export]
    public float timer = 0.0f;

    public override void Init() { }

    public override void _Ready() { }

    public override void Enter()
    {
        enemy.Velocity = Vector2.Zero;
        timer = RandalThor.RandfRange(stateDurationMin, stateDurationMax);
        enemy.UpdateAnimation(animName);
    }

    public override void Exit() { }

    public override EnemyState Process(double delta)
    {
        timer -= (float)delta;
        if (timer <= 0)
        {
            return afterIdleState;
        }
        return null;
    }

    public override EnemyState Physics(double delta)
    {
        return null;
    }
}
