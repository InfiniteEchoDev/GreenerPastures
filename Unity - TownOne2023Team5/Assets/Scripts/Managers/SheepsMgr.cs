using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;


public class SheepsMgr : Singleton<SheepsMgr> {

	List<Sheep> Sheeps = new();


	protected override void Awake() {
		base.Awake();
		Sheeps = FindObjectsOfType<Sheep>().ToList();
	}


	public void SetAllSheepDest( Vector3 destPos ) {
		foreach( Sheep sheep in Sheeps ) {
			sheep.SetMoveTarget( destPos );
		}
	}
}
