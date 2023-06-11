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


	public void SetAllSheepDest( Vector3 destPos ) {
		foreach( Sheep sheep in Sheeps ) {
			if( Vector3.Distance( destPos, sheep.transform.position ) < AttractToDist )
				sheep.SetMoveTarget( destPos );
		}
	}

	// Set all sheep within dist units from destPos to move towards it
	// Returns number of sheep that move
	public int SetAllSheepDest( Vector3 destPos, float dist ) {
		int count = 0;
		foreach( Sheep sheep in Sheeps ) {
			if( Vector3.Distance( destPos, sheep.transform.position ) < dist ) {
				sheep.SetMoveTarget( destPos );
				count++;
			}
		}
		return count;
	}

	public void SetAllSheepsRunAwayFrom( Vector3 runFromPos ) {
		foreach( Sheep sheep in Sheeps ) {
			if( Vector3.Distance( runFromPos, sheep.transform.position ) < RunFromDist )
				sheep.SetRunFromPos( runFromPos );
		}
	}

	// Counts number of sheep within a certain dist of pos
	public int CountSheepAroundPosition( Vector3 pos, float dist) {
		int count = 0;
		foreach ( Sheep sheep in Sheeps ) {
			if( Vector3.Distance( pos, sheep.transform.position ) < dist )
				count++;
		}
		return count;
	}
}
