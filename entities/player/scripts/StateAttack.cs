using Godot;

public partial class StateAttack : State
{
    [Export]
    public AnimatedSprite2D attackAnim;

    [ExportCategory("Other States")]
    [Export]
    public State idle;

    [Export]
    public State run;

    public bool attacking = false;

    public override void Enter()
    {
        if (player.sprite.FlipH)
        {
            attackAnim.FlipH = true;
        }
        else
        {
            attackAnim.FlipH = false;
        }
        attackAnim.Visible = true;
        player.UpdateAnimation("attack");
        if (player.AnimDirection() == "up")
            attackAnim.ShowBehindParent = true;
        else
            attackAnim.ShowBehindParent = false;

        attackAnim.Play("attack_" + player.AnimDirection());
        attacking = true;

        player.sprite.AnimationFinished += EndAttack;
    }

    public override void Exit()
    {
        player.sprite.AnimationFinished -= EndAttack;
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

    public void EndAttack()
    {
        attacking = false;
        attackAnim.Visible = false;
    }
}
