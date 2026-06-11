using Godot;

public partial class LevelTilemap : TileMapLayer
{
    public override void _Ready()
    {
        GlobalLevelManager.Instance.ChangeTilemapBounds(GetTilemapBounds());
    }

    public Vector2[] GetTilemapBounds()
    {
        Vector2[] bounds = new Vector2[2];

        bounds[0] = (Vector2)GetUsedRect().Position * RenderingQuadrantSize;
        bounds[1] = (Vector2)GetUsedRect().End * RenderingQuadrantSize;

        return bounds;
    }
}
