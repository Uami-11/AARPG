using Godot;

public partial class StateAttack : State
{
    [ExportCategory("Other States")]
    [Export]
    public State idle;

    [Export]
    public State run;

    public bool attacking = false;

    public override void Enter()
    {
        player.UpdateAnimation("attack");
        attacking = true;

        player.sprite.AnimationFinished += EndAttack;
    }

    public override void Exit() { }

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
    }
}
