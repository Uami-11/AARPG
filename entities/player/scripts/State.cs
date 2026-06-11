using Godot;

public partial class State : Node
{
    public Player player { get; set; }

    public override void _Ready() { }

    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual State Process(double delta)
    {
        return null;
    }

    public virtual State Physics(double delta)
    {
        return null;
    }

    public virtual State HandleInput(InputEvent _event)
    {
        return null;
    }
}
