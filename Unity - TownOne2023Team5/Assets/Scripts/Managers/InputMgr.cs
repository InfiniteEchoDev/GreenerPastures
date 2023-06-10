using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class InputMgr : Singleton<InputMgr> {


    protected override void Awake()
    {
        base.Awake();
    }          

    public void Update()
    {
  
        // Test raycast for Sheeps destination setting
		if( Input.GetMouseButton( 0 ) ) {
			if( Physics.Raycast(
				CameraMgr.Instance.MainCamera.ScreenPointToRay( Input.mousePosition ),
				out RaycastHit inputPlaneHit,
				Mathf.Infinity,
				1 << LayerMgr.MouseClickLayer,
				QueryTriggerInteraction.Collide 
			) ) {
				SheepsMgr.Instance.SetAllSheepDest( inputPlaneHit.point );
			}
		}
		if( Input.GetMouseButton( 1 ) ) {
			if( Physics.Raycast(
				CameraMgr.Instance.MainCamera.ScreenPointToRay( Input.mousePosition ),
				out RaycastHit inputPlaneHit,
				Mathf.Infinity,
				1 << LayerMgr.MouseClickLayer,
				QueryTriggerInteraction.Collide 
			) ) {
				SheepsMgr.Instance.SetAllSheepsRunAwayFrom( inputPlaneHit.point );
			}
		}
    }
}


