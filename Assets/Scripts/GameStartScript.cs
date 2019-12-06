using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartScript : MonoBehaviour {

	private GameControllerScript gameController;

	private void Awake() {
		this.gameController = GameObject.Find("GameController").GetComponent<GameControllerScript>();
	}

	public void gameStart() {
		this.gameController.setStartStatus(true);
		Destroy(gameObject);
	}
}
