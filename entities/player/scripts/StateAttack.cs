using Godot;

public partial class StateAttack : State
{
    [Export]
    public AnimationPlayer attackAnim;

    [Export]
    public AudioStream attackSound;

    [Export]
    public AudioStreamPlayer2D audioPlayer;

    [Export]
    public HurtBox hurtbox;

    [ExportCategory("Other States")]
    [Export]
    public State idle;

    [Export]
    public State run;

    public bool attacking = false;

    public RandomNumberGenerator numberGenerator = new RandomNumberGenerator();

    public override async void Enter()
    {
        player.UpdateAnimation("attack");

        attackAnim.Play("attack_" + player.AnimDirection());
        attacking = true;

        player.animationPlayer.AnimationFinished += EndAttack;

        audioPlayer.Stream = attackSound;
        audioPlayer.PitchScale = numberGenerator.RandfRange(0.9f, 1.1f);
        audioPlayer.Play();

        await ToSignal(GetTree().CreateTimer(0.075f), SceneTreeTimer.SignalName.Timeout);

        hurtbox.Monitoring = true;
    }

    public override void Exit()
    {
        player.animationPlayer.AnimationFinished -= EndAttack;
        hurtbox.Monitoring = false;
    }

    public override State Process(double delta)
    {
        // player.Velocity = Vector2.Zero;

        if (!attacking)
        {
            if (player.direction == Vector2.Zero)
                return idle;
            else
                return run;
        }
        return null;
    }

    public override State Physics(double delta)
    {
        return null;
    }

    public override State HandleInput(InputEvent _event)
    {
        return null;
    }

    public void EndAttack(StringName _name)
    {
        attacking = false;
    }
}
