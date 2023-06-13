using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class GameManager : Singleton<GameManager> {

	public enum GameState {
		Unknown = 0,
		AtMainMenu,
		Playing,
		GameOver,
	}

	public GameState CurrentGameState = GameState.Unknown;


	public delegate void OnCurrentGameStateChangeDelegate( GameState fromState, GameState toState );
	public event OnCurrentGameStateChangeDelegate OnCurrentGameStateChange;



	GameState prevGameState = GameState.Unknown;
	public void SetGameState( GameState toState ) {
		prevGameState = CurrentGameState;
		CurrentGameState = toState;

		OnCurrentGameStateChange?.Invoke( prevGameState, toState );
	}


	public void Start() {
		OnCurrentGameStateChange += OnCurrentGameStateChangeHere;
		BeginGame();
	}


	public void BeginGame() {
		SetGameState( GameState.AtMainMenu );
	}


	void OnCurrentGameStateChangeHere( GameState fromState, GameState toState ) {
		switch( toState ) {
			case GameState.AtMainMenu:
				Time.timeScale = 0;
				break;
			case GameState.Playing:
				Time.timeScale = 1;
				break;
			case GameState.GameOver:
				Time.timeScale = 0;
				break;
		}
	}
}
