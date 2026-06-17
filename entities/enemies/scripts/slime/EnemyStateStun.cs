using Godot;

public partial class EnemyStateStun : EnemyState
{
    private RandomNumberGenerator RandalThor = new RandomNumberGenerator();

    [Export]
    public string animName = "stun";

    [Export]
    public float knockbackSpeed = 200f;

    [Export]
    public float decelarateSpeed = 10f;

    [Export]
    public EnemyState nextState;

    public Vector2 damagePosition;
    public Vector2 _direction;

    public bool animationFinished = false;

    public override void Init()
    {
        enemy.enemyDamaged += OnEnemyDamaged;
    }

    public override void _Ready() { }

    public override void Enter()
    {
        _direction = enemy.GlobalPosition.DirectionTo(damagePosition);
        enemy.invulnerable = true;
        animationFinished = false;
        enemy.Velocity = _direction * -knockbackSpeed;
        enemy.UpdateAnimation(animName);
        enemy.animationPlayer.AnimationFinished += onAnimationFinished;
    }

    public override void Exit()
    {
        enemy.animationPlayer.AnimationFinished -= onAnimationFinished;
        enemy.invulnerable = false;
    }

    public override EnemyState Process(double delta)
    {
        if (animationFinished)
            return nextState;

        enemy.Velocity -= enemy.Velocity * decelarateSpeed * (float)delta;
        return null;
    }

    public override EnemyState Physics(double delta)
    {
        return null;
    }

    public void OnEnemyDamaged(HurtBox hurtBox)
    {
        damagePosition = hurtBox.GlobalPosition;
        stateMachine.ChangeState(this);
    }

    private void onAnimationFinished(StringName _a)
    {
        animationFinished = true;
    }
}
