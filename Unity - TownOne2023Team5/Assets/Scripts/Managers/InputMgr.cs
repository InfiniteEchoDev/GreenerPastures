using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class InputMgr : Singleton<InputMgr> {


	bool isWaitingForAnyKey = false;
	bool doTransferToGameplay = false;
	bool doTransferToMainMenu = false;
	bool havePressedAnyKey = false;

	[Header( "Obj Refs" )]
	public PlayerInput PlayerInput;


    protected override void Awake()
    {
        base.Awake();

    }

	private void Start() {
		GameManager.Instance.OnCurrentGameStateChange += OnGameStateChanged;
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

		if( isWaitingForAnyKey ) {
			if( Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown( "Submit" ) ) {
				isWaitingForAnyKey = false;

				if( doTransferToGameplay )
					GameManager.Instance.SetGameState( GameManager.GameState.Playing );
				if( doTransferToMainMenu )
					GameManager.Instance.SetGameState( GameManager.GameState.AtMainMenu );

				doTransferToGameplay = false;
				doTransferToMainMenu = false;
			}
		}
    }


	void OnGameStateChanged( GameManager.GameState fromState, GameManager.GameState toState ) {
		switch( toState ) {
			case GameManager.GameState.AtMainMenu:
				isWaitingForAnyKey = true;
				doTransferToGameplay = true;
				havePressedAnyKey = false;
				break;
			case GameManager.GameState.Playing:
				break;
			case GameManager.GameState.GameOver:
				isWaitingForAnyKey = true;
				doTransferToMainMenu = true;
				break;

		}
	}
}


