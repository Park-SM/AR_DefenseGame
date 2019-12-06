using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnemyBossScript : MonoBehaviour {

	private GameControllerScript gameController;
	private Transform groundTrans;
	private Animator anim;
	private Vector3 destination;
	private bool isWalking;
	private bool isAttacking;
	private float walkingSpeed;
	private float attackTime;
	private int lifeCount;
	private float direction;
	private float soutingTime;

	void Awake() {
		this.gameController = GameObject.Find("GameController").GetComponent<GameControllerScript>();
		this.groundTrans = GameObject.Find("Ground").GetComponent<Transform>();
		this.anim = GetComponent<Animator>();

		this.direction = Random.Range(0f, 360f);
		this.isWalking = true;
		this.isAttacking = false;
		this.walkingSpeed = gameController.getBossSpeed();
		this.attackTime = gameController.getBossAttackTime();
		this.lifeCount = gameController.getBossLifeCount();
		this.soutingTime = 2.5f;

		transform.rotation = groundTrans.rotation;
		transform.Rotate(new Vector3(0, direction, 0));
	}

	// Update is called once per frame
	void Update() {

		if ((soutingTime -= Time.deltaTime) < 0 && isWalking) {
			transform.Translate(0, 0, walkingSpeed * Time.deltaTime, Space.Self);
		}

		if (isAttacking) {
			if ((attackTime -= Time.deltaTime) <= 0) {
				gameController.downHP();

				this.attackTime = gameController.getAnemyAttackTime();
			}
		}

	}

	void OnTriggerEnter(Collider other) {
		if (other.transform.tag == "castle") {
			this.anim.SetBool("isAttacking", true);
			this.isWalking = false;
			this.isAttacking = true;
		}
	}

	public void hit() {
		this.anim.SetTrigger("isDamage");
		transform.Translate(Vector3.back * 3, Space.Self);
		this.isWalking = true;
		this.isAttacking = false;

		if (--lifeCount <= 0) {
			this.isWalking = false;
			this.isAttacking = false;
			this.anim.SetTrigger("isDeath");
			gameController.gameClear();
			Destroy(gameObject, 3);
		}
	}

}
