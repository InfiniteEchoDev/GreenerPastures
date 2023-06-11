using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;


public class SheepsMgr : Singleton<SheepsMgr> {

	//[Range(1, 100)]
	public float RunFromDist = 5f;
	//[Range(1, 100)]
	public float AttractToDist = 2.5f;

	List<Sheep> Sheeps = new();


	protected override void Awake() {
		base.Awake();
		Sheeps = FindObjectsOfType<Sheep>().ToList();
	}

	public void CheckSheeps(Sheep sheep) 
	{
		if (sheep.health < 0)
		{
			Sheeps.Remove(sheep);
			sheep.gameObject.SetActive(false);
            //Destroy(sheep);
		}
	
	}

	public void SetAllSheepDest( Vector3 destPos ) {
		foreach( Sheep sheep in Sheeps ) {
			if( Vector3.Distance( destPos, sheep.transform.position ) < AttractToDist )
				sheep.SetMoveTarget( destPos );
		}
	}

	public void SetAllSheepsRunAwayFrom( Vector3 runFromPos ) {
		foreach( Sheep sheep in Sheeps ) {
			if( Vector3.Distance( runFromPos, sheep.transform.position ) < RunFromDist )
				sheep.SetRunFromPos( runFromPos );
		}
	}
}
