using Godot;

public partial class GlobalLevelManager : Node
{
    public static GlobalLevelManager Instance { get; private set; }

    public Vector2[] currentTilemapBounds = new Vector2[2];

    [Signal]
    public delegate void TilemapBoundsChangedEventHandler(Vector2[] bounds);

    public void ChangeTilemapBounds(Vector2[] bounds)
    {
        currentTilemapBounds = bounds;
        EmitSignal(SignalName.TilemapBoundsChanged, bounds);
    }

    public override void _EnterTree()
    {
        Instance = this;
    }
}
