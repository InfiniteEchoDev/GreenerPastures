using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class Tile : MonoBehaviour {
	

	// [SerializeField]
	// [OnChangedCall(nameof(OnUnderlayChanged))]
	public TileMgr.TileUnderlays underlay = TileMgr.TileUnderlays.Unknown;
	// [SerializeField]
	// [OnChangedCall(nameof(OnOverlayChanged))]
	public TileMgr.TileOverlays overlay = TileMgr.TileOverlays.Unknown;

	// public void OnUnderlayChanged()
	// {
	// 	Debug.Log("Some underlay changed!");
	// 	ChangeUnderlay();
	// 	// ChangeOverlay();
	// }

	// public void OnOverlayChanged()
	// {
	// 	Debug.Log("Some overlay changed!");
	// 	// ChangeUnderlay();
	// 	ChangeOverlay();
	// }

	// public void ChangeUnderlay()
	// {
	// 	// destroy underlay
	// 	Transform currUnderlay = this.gameObject.transform.GetChild(0);
	// 	Debug.Log("Changing Underlay... 0th child is " + currUnderlay + "Underlay is " + underlay);
	// 	GameObject newUnderlay;
		
	// 	// if (underlay != TileMgr.TileUnderlays.Unknown && TileMgr.TileUnderlayDict.ContainsKey(underlay)) {
	// 	// 	newUnderlay =  Instantiate(TileMgr.TileUnderlayDict[underlay], this.gameObject.transform);
	// 	// 	// instantiate prefab based on TileMgr

	// 	// } else {
	// 	// 	// underlay key is invalid or unknown; default to grass
	// 	// 	newUnderlay =  Instantiate(TileMgr.TileUnderlayDict[TileMgr.TileUnderlays.Grass1], this.gameObject.transform);
	// 	// 	//instantiate prefab based on TileMgr
	// 	// }

	// 	foreach (TileMgr.TileUnderlayEntry entry in TileMgr.Instance.tileUnderlayMap)
	// 	{
	// 		if (entry.tileUnderlay.Equals(underlay))
	// 		{
	// 			newUnderlay = Instantiate(entry.prefab, this.gameObject.transform);
	// 			newUnderlay.transform.SetSiblingIndex(0);
	// 			Debug.Log("New underlay: " + newUnderlay);
	// 			Destroy(currUnderlay);
	// 			return;
	// 		}
	// 	}
	// 	Debug.Log("Couldn't find the correct underlay!");
	// }

	// public void ChangeOverlay()
	// {
	// 	Transform currOverlay = this.gameObject.transform.GetChild(1);
	// 	Debug.Log("Changing Overlay... 1st child is " + currOverlay + "overlay is " + overlay);
	// 	GameObject newOverlay;
	// 	// if (overlay != TileMgr.TileOverlays.Unknown && TileMgr.TileOverlayDict.ContainsKey(overlay)) {
	// 	// 	newOverlay =  Instantiate(TileMgr.TileOverlayDict[overlay], this.gameObject.transform);
	// 	// 	// instantiate prefab based on TileMgr

	// 	// } else {
	// 	// 	// underlay key is invalid or unknown; default to no overlay
	// 	// 	newOverlay =  Instantiate(TileMgr.TileOverlayDict[TileMgr.TileOverlays.Unknown], this.gameObject.transform);
	// 	// 	//instantiate prefab based on TileMgr
	// 	// }
	// 	// newOverlay.transform.SetSiblingIndex(1);
	// 	// Debug.Log(newOverlay);
	// 	// DestroyImmediate(currOverlay);

	// 	foreach (TileMgr.TileOverlayEntry entry in TileMgr.Instance.tileOverlayMap)
	// 	{
	// 		if (entry.tileOverlay.Equals(overlay))
	// 		{
	// 			newOverlay = Instantiate(entry.prefab, this.gameObject.transform);
	// 			newOverlay.transform.SetSiblingIndex(1);
	// 			Debug.Log("New underlay: " + newOverlay);
	// 			Destroy(currOverlay);
	// 			return;
	// 		}
	// 	}
	// 	Debug.Log("Couldn't find the correct underlay!");
	// }
}
