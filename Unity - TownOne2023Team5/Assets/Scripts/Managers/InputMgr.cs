using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class InputMgr : Singleton<InputMgr> {

	private void Update() {
		if( Input.GetMouseButton( 0 ) ) {
			if( Physics.Raycast(
				CameraMgr.Instance.MainCamera.ScreenPointToRay( Input.mousePosition ),
				out RaycastHit inputPlaneHit,
				Mathf.Infinity,
				1 << LayerMgr.MouseClickLayer,
				QueryTriggerInteraction.Collide 
			) ) {
				//inputPlaneHit
			}
		}
	}
}
