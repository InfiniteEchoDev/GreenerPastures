using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMgr : Singleton<PlayerMgr> {

	protected override void Awake() {
		base.Awake();
	}

	[Header( "Obj Refs" )]
	public GameObject Player;
}
