using Godot;

public partial class StateRun : State
{
    [Export]
    public float moveSpeed = 200f;

    [Export]
    public State idle;

    public override void Enter()
    {
        player.UpdateAnimation("run");
    }

    public override void Exit() { }

    public override State Process(double delta)
    {
        if (player.direction == Vector2.Zero)
            return idle;

        player.Velocity = player.direction * moveSpeed;

        if (player.SetDirection())
            player.UpdateAnimation("run");

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
}
