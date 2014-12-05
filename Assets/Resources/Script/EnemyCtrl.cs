using UnityEngine;
using System.Collections;

public class EnemyCtrl : MonoBehaviour {

    private GameManager mGameManager;

	private int mHP = 1;
	private float mSpeed = 2f;
    private int mScore = 0;

	void Start () {
        mGameManager = FindObjectOfType<GameManager>();

		if (gameObject.tag == "Enemy_S") {
			mHP = 1;
			mSpeed = 2f;
            mScore = 100;
		}
		else if (gameObject.tag == "Enemy_M") {
            mHP = 5;
			mSpeed = 1.2f;
            mScore = 500;
		}
		else if (gameObject.tag == "Enemy_L") {
			mHP = 20;
			mSpeed = 0.5f;
            mScore = 2000;
		}
		GetComponent<Animator>().SetInteger("mHP", mHP);
	}

	void Update () {
        if (mGameManager.isStatePlaying() || mGameManager.isStateEnd()) {
            transform.Translate(Vector3.down * Time.deltaTime * mSpeed);

            if (transform.position.y + (gameObject.renderer.bounds.size.y / 2) < -4.8) {
                GameObject.Destroy(gameObject);
            }
        }
	}

	public void setSpeed(float speed) {
		mSpeed = speed;
	}

	public void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.tag == "Bullet") {
			if (mHP > 0) {
				Destroy(collider.gameObject);
				
				--mHP;
				GetComponent<Animator>().SetInteger("mHP", mHP);
				if (mHP <= 0) {
					mSpeed = 0;

                    mGameManager.addScore(mScore);
				}
				else {
					GetComponent<Animator>().SetBool("isHurt", true);
				}
			}
		}
        else if(collider.gameObject.tag == "Aircraft") {
            collider.gameObject.GetComponent<AircraftCtrl>().hurt();
        }
	}

	public void hurtEnd() {
		GetComponent<Animator>().SetBool("isHurt", false);
	}

	public void exploEnd() {
		GameObject.Destroy(gameObject);
	}

}
