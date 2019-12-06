using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

	public int currentLevel = 1;

	public float anemySpeed = 15f;
	public float anemyDamage = 3f;
	public float anemyAttackTime = 2f;
	public int anemyLifeCount = 3;

	public float bossSpeed = 15f;
	public float bossDamage = 10f;
	public float bossAttackTime = 2f;
	public int bossLifeCount = 80;

	public float hp = 100f;
	public GameObject charGameOver;
	public GameObject charGameClear;

	private int killCount = 0;
	private Transform hpGageTrans;
	private bool isDeath;
	private bool isStartting;
	private bool isClear;
	private AudioSource aso;

    void Awake() {
		this.hpGageTrans = GameObject.Find("CastleHP").GetComponent<Transform>();
		this.isDeath = true;
		this.isStartting = false;
		this.isClear = false;
		this.aso = GetComponent<AudioSource>();
	}

	public void downHP() {
		if ((this.hp -= anemyDamage) > 0) {
			// 게이지 바를 줄이고 왼쪽으로 정렬하는 소스 -> 게이지 바를 줄이면 가운데 기준으로 양쪽이 줄어들기 때문.
			this.hpGageTrans.transform.localScale = new Vector3(this.hp, 5f, 5f);
			this.hpGageTrans.Translate(Vector3.left * (anemyDamage / 2.0f));
		} else {
			if (this.isDeath) {
				gameOver();
				this.hp = -999;
				this.hpGageTrans.transform.localScale = new Vector3(0, 0, 0);
				this.isDeath = false;
			}
		}

		
	}

	public float getAnemySpeed() {
		return this.anemySpeed;
	}

	public float getAnemyAttackTime() {
		return this.anemyAttackTime;
	}

	public int getAnemyLifeCount() {
		return this.anemyLifeCount;
	}

	public float getBossSpeed() {
		return this.bossSpeed;
	}

	public float getBossAttackTime() {
		return this.bossAttackTime;
	}

	public int getBossLifeCount() {
		return this.bossLifeCount;
	}

	public int getLevel() {
		return this.currentLevel;
	}

	public void levelUp() {
		this.currentLevel++;
		this.anemySpeed += 10;
	}

	public bool getStartStatus() {
		return isStartting;
	}

	public bool setStartStatus(bool s) {
		return isStartting = s;
	}

	public void gameClear() {
		this.isClear = true;
		this.aso.Stop();

		GameObject obj = Instantiate(charGameClear, GameObject.Find("ImageTarget").transform, true) as GameObject;
		obj.transform.position = GameObject.Find("AnemyPool").transform.position;
		obj.transform.Translate(Vector3.up * 70);
		GameObject.Find("ARCamera").GetComponent<MainCameraScript>().setSootingPause(true);		// 게임 오버는 아니지만 역할이 필요해서 함.

		Destroy(GameObject.Find("AnemyPool"));
	}

	void gameOver() {
		if (this.isClear) return;
		this.aso.Stop();

		GameObject obj = Instantiate(charGameOver, GameObject.Find("ImageTarget").transform, true) as GameObject;
		obj.transform.position = GameObject.Find("AnemyPool").transform.position;
		obj.transform.Translate(Vector3.up * 70);
		GameObject.Find("ARCamera").GetComponent<MainCameraScript>().setSootingPause(true);
	}


}
