using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class SoundMgr : Singleton<SoundMgr> {


	
		

	protected override void Awake() {
		base.Awake();

	}

	private void Start() {
		GameManager.Instance.OnCurrentGameStateChange += OnGameStateChange;
	}


	void OnGameStateChange( GameManager.GameState fromState, GameManager.GameState toState ) {

		switch( toState ) {
			case GameManager.GameState.AtMainMenu:

				break;
			case GameManager.GameState.Playing:
				break;
			case GameManager.GameState.GameOver:
				break;
		}

	}
}
