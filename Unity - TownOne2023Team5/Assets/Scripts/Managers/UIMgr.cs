using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class UIMgr : Singleton<UIMgr> {

	override protected void Awake() {
		base.Awake();

	}

	[Header("Obj Refs")]
	public GameObject MainMenuUI;
	public GameObject GameOverlayUI;
	public GameObject GameOverUI;

	public TMPro.TMP_Text SheepAmtText;
	public TMPro.TMP_Text WolfAmtText;


	public void Start() {
		GameManager.Instance.OnCurrentGameStateChange += OnGameStateChange;
		
	}


	void OnGameStateChange( GameManager.GameState fromState, GameManager.GameState toState ) {
		Debug.Log( $"egin - {toState}" );
		switch( toState ) {
			case GameManager.GameState.AtMainMenu:
				MainMenuUI.SetActive( true );
				GameOverUI.SetActive( false );
				break;
			case GameManager.GameState.Playing:
				MainMenuUI.SetActive( false );
				break;
			case GameManager.GameState.GameOver:
				GameOverUI.SetActive( true );
				break;
		}
	}
}
