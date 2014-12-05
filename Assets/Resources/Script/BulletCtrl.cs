using UnityEngine;
using System.Collections;

public class BulletCtrl : MonoBehaviour {

    private GameManager mGameManager;

	private float mSpeed = 8f;
	
	void Start () {
        mGameManager = FindObjectOfType<GameManager>();
	}

	void Update () {
        if (mGameManager.isStatePlaying() || mGameManager.isStateEnd()) {
            transform.Translate(Vector3.up * Time.deltaTime * mSpeed);

            if (transform.position.y - (gameObject.renderer.bounds.size.y / 2) > 4.8) {
                GameObject.Destroy(gameObject);
            }	
        }
	}

	public void setSpeed(float speed) {
		mSpeed = speed;
	}

}
