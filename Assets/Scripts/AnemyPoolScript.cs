using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnemyPoolScript : MonoBehaviour {

	public float generateMaxTime = 5f;
	public float generateBossTime = 60f;
	public GameObject anemyPrefab;
	public GameObject bossPrefab;

	private float currentTime;
	private GameControllerScript gameController;
	private Transform parentTrans;
	private Transform parentTransY;
	private bool isWillAppearedBoss;

	void Awake() {
		this.currentTime = Random.Range(generateMaxTime - 3f, this.generateMaxTime + 1f);
		this.gameController = GameObject.Find("GameController").GetComponent<GameControllerScript>();
		this.parentTrans = GameObject.Find("ImageTarget").GetComponent<Transform>();
		this.isWillAppearedBoss = true;
	}

	// Update is called once per frame
	void Update() {

        if (gameController.getStartStatus() && (currentTime -= Time.deltaTime) < 0f) {
			CreateAnemy();
			this.currentTime = Random.Range(0, this.generateMaxTime);
		}

		if (isWillAppearedBoss && gameController.getStartStatus() && (generateBossTime -= Time.deltaTime) < 0f) {
			CreateBoss();
			isWillAppearedBoss = false;
		}
    }
		
	void CreateAnemy() {
		GameObject newAnemy = Instantiate(anemyPrefab, parentTrans, true) as GameObject;
		newAnemy.transform.position = new Vector3(parentTrans.position.x, parentTrans.position.y + 15, parentTrans.position.z);
	}

	void CreateBoss() {
		GameObject newAnemy = Instantiate(bossPrefab, parentTrans, true) as GameObject;
		newAnemy.transform.position = new Vector3(parentTrans.position.x, parentTrans.position.y + 15, parentTrans.position.z);
		gameController.levelUp();
	}

}
