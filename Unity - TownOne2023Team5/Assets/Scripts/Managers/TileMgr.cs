using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteInEditMode]
public class TileMgr : Singleton<TileMgr> {
    
    // public static Dictionary<Tile.TileType, GameObject> OverlaysToPrefabs = new Dictionary<Tile.TileType, GameObject>
    // {
    //     { Tile.TileType.Unknown  = "TODO"},
    //     { Tile.TileType.Cliff  = "TODO"},
    //     { Tile.TileType.Dirt  = "TODO"},
    //     { Tile.TileType.Forest  = "TODO"},
    //     { Tile.TileType.Grass  = "TODO"},
    //     { Tile.TileType.Water  = "TODO"}
    // };

    // public static Dictionary<TileUnderlays, GameObject> TileUnderlayDict = new Dictionary<TileUnderlays, GameObject>();
    // public static Dictionary<TileOverlays, GameObject> TileOverlayDict = new Dictionary<TileOverlays, GameObject>();


    protected override void Awake() {
		base.Awake();

    //    RegenerateDictionaries();
	}

    // public void RegenerateDictionaries()
    // {
    //     Debug.Log("Regenerating Dictionaries 2.");
    //     foreach (TileUnderlayEntry entry in tileUnderlayMap) 
    //     {
    //         if (!TileUnderlayDict.ContainsKey(entry.tileUnderlay))
    //             TileUnderlayDict.Add(entry.tileUnderlay, entry.prefab);
    //     }

    //     foreach (TileOverlayEntry entry in tileOverlayMap) 
    //     {
    //         if (!TileOverlayDict.ContainsKey(entry.tileOverlay))
    //             TileOverlayDict.Add(entry.tileOverlay, entry.prefab);
    //     }
        
    //     // TileUnderlayDict = new Dictionary<TileUnderlays, GameObject>(tileUnderlayMap.ToDictionary<TileUnderlays, GameObject>(entry => entry.tileUnderlay, entry => entry.prefab));
    //     // TileOverlayDict = new Dictionary<TileOverlays, GameObject>(tileOverlayMap.ToDictionary<TileOverlays, GameObject>(entry => entry.tileOverlay, entry => entry.prefab));
    // }

    

    // [System.Serializable]
    // public class TileUnderlayEntry
    // {
    //     public TileUnderlays tileUnderlay;
    //     public GameObject prefab;
    // }

	// [SerializeField]
	// // [OnChangedCall(nameof(RegenerateDictionaries))]
    // public List<TileUnderlayEntry> tileUnderlayMap;

    // [System.Serializable]
    // public class TileOverlayEntry
    // {
    //     public TileOverlays tileOverlay;
    //     public GameObject prefab;
    // }

	// [OnChangedCall(nameof(RegenerateDictionaries))]
    // public List<TileOverlayEntry> tileOverlayMap;
    
    // [OnChangedCall(nameof(RegenerateDictionaries))]


    public enum TileUnderlays {
		Unknown = 0,
		// Water,
		Cliff1,

        Dirt1,
        Forest1,
        Grass1,
        Grass2,
        Grass3,
        Grass4,
        Grass5,
        Water1,
        Water2
	}

    public enum TileOverlays {
        Unknown = 0,
		Bush1,
		Bush2,
		Bush3,
		Forest1,
        Forest2,
		Rock1,
		Rock2,
		Rock3,
		Rock4,

        Tree1,
        Tree2,
        Trunk1,
        Trunk2,
        Trunk3,
	}
}
