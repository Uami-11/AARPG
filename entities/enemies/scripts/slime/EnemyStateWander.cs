using Godot;

public partial class EnemyStateWander : EnemyState
{
    private RandomNumberGenerator RandalThor = new RandomNumberGenerator();

    [Export]
    public string animName = "run";

    [Export]
    public float moveSpeed = 40f;

    [ExportCategory("AI")]
    [Export]
    public float stateAnimationDuration = 0.7f;

    [Export]
    public int statesCycleMin = 1;

    [Export]
    public int statesCycleMax = 3;

    [Export]
    public EnemyState nextState;

    public Vector2 _direction;

    [Export]
    public float timer = 0.0f;

    public override void Init() { }

    public override void _Ready() { }

    public override void Enter()
    {
        timer = RandalThor.RandiRange(statesCycleMin, statesCycleMax) * stateAnimationDuration;
        var dir = RandalThor.RandiRange(0, 3);
        _direction = enemy.DIR[dir];
        enemy.Velocity = _direction * moveSpeed;
        enemy.SetDirection(_direction);
        enemy.UpdateAnimation(animName);
    }

    public override void Exit() { }

    public override EnemyState Process(double delta)
    {
        timer -= (float)delta;

        if (timer <= 0)
        {
            return nextState;
        }
        return null;
    }

    public override EnemyState Physics(double delta)
    {
        return null;
    }
}
