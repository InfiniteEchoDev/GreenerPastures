using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class Tile : MonoBehaviour {
	
	public enum TileType {
		Unknown = 0,
		Grass,
		Forest,
		Dirt,
		Water,
		Cliff,
	}

	public TileType Type = TileType.Unknown;
}
