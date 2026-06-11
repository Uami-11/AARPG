using Godot;

public partial class State : Node
{
    public Player player { get; set; }

    public override void _Ready() { }

    public void Enter() { }

    public void Exit() { }

    public State Process(double delta)
    {
        return null;
    }

    public State Physics(double delta)
    {
        return null;
    }

    public State HandleInput(InputEvent _event)
    {
        return null;
    }
}
