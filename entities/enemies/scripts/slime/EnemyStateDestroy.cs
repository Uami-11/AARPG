using Godot;

public partial class EnemyStateDestroy : EnemyState
{
    private RandomNumberGenerator RandalThor = new RandomNumberGenerator();

    [Export]
    public string animName = "destroy";

    [Export]
    public float knockbackSpeed = 200f;

    [Export]
    public float decelarateSpeed = 10f;

    public Vector2 damagePosition;
    public Vector2 _direction;

    public override void Init()
    {
        enemy.enemyDied += OnEnemyDestroyed;
    }

    public override void _Ready() { }

    public override void Enter()
    {
        _direction = enemy.GlobalPosition.DirectionTo(damagePosition);
        enemy.invulnerable = true;
        enemy.Velocity = _direction * -knockbackSpeed;
        enemy.UpdateAnimation(animName);
        enemy.animationPlayer.AnimationFinished += OnAnimationFinished;
    }

    public override void Exit() { }

    public override EnemyState Process(double delta)
    {
        enemy.Velocity -= enemy.Velocity * decelarateSpeed * (float)delta;
        return null;
    }

    public override EnemyState Physics(double delta)
    {
        return null;
    }

    public void OnEnemyDestroyed(HurtBox hurtBox)
    {
        damagePosition = hurtBox.GlobalPosition;
        stateMachine.ChangeState(this);
    }

    public void OnAnimationFinished(StringName _a)
    {
        enemy.QueueFree();
    }
}
