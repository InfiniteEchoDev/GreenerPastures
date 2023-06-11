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
		BeginGame();
	}


	void BeginGame() {
		SetGameState( GameState.AtMainMenu );
	}
}
