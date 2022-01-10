using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapManager : MonoBehaviour
{
    [SerializeField] private Tilemap map;

    [SerializeField] TileInfo[] tileInfos;

    Dictionary<TileBase, TileInfo> infoFromTiles;

    private void Awake()
    {
        infoFromTiles = new Dictionary<TileBase, TileInfo>();
        PopulateDictionary();
    }

    private void PopulateDictionary()
    {
        foreach (TileInfo tileInfo in tileInfos)
        {
            foreach (TileBase tile in tileInfo.tiles)
            {
                infoFromTiles.Add(tile, tileInfo);
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = map.WorldToCell(mousePosition);

            TileBase clickedTile = map.GetTile(gridPosition);

            TileInfo clickedTileInfo = infoFromTiles[clickedTile];

            Debug.Log(clickedTile.name + " Speed Multiplaier: " + clickedTileInfo.velocityMultiplier + ", Is Terrain Combat: " + clickedTileInfo.isTerrainCombat);
        }
    }

}
