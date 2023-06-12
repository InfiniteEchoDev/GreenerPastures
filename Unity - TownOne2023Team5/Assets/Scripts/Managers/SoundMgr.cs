using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class SoundMgr : Singleton<SoundMgr> {



	[Header( "Obj Refs" )]
	public FMODUnity.StudioEventEmitter MainMenuEvent;
	public FMODUnity.StudioEventEmitter PlayMusicEvent;
	public FMODUnity.StudioEventEmitter GameOverMusicEvent;

	public FMODUnity.ParamRef FollowerCountParam;

	public PlayerController PlayerController;
		

	protected override void Awake() {
		base.Awake();

	}

	private void Start() {
		GameManager.Instance.OnCurrentGameStateChange += OnGameStateChange;

		PlayerController.OnUpdateFollowerCount += OnUpdateFollowerCount;
	}


	void OnGameStateChange( GameManager.GameState fromState, GameManager.GameState toState ) {

		switch( toState ) {
			case GameManager.GameState.AtMainMenu:
				GameOverMusicEvent.Stop();
				MainMenuEvent.Play();
				break;
			case GameManager.GameState.Playing:
				MainMenuEvent.Stop();
				PlayMusicEvent.Play();
				break;
			case GameManager.GameState.GameOver:
				PlayMusicEvent.Stop();
				GameOverMusicEvent.Play();
				break;
		}

	}

	void OnUpdateFollowerCount( float followerCount ) {
		Debug.Log( $"here: " );
		FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Lonely Shepherd", followerCount );
	}
}
