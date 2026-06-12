using Godot;

public partial class GlobalPlayerManager : Node
{
    public static GlobalPlayerManager Instance { get; private set; }

    public Player player;

    public override void _EnterTree()
    {
        Instance = this;
    }
}
