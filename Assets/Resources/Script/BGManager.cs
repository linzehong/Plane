using UnityEngine;
using System.Collections;

public class BGManager : MonoBehaviour {

	private Vector3 mTmpPosition = new Vector3();

	private float mSpeed = 0.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.down * Time.deltaTime * mSpeed);

		if (transform.position.y <= -4.8f) {
			mTmpPosition.x = transform.position.x;
			mTmpPosition.y = 4.8f;
			mTmpPosition.z = transform.position.z;

			transform.position = mTmpPosition;
		}
	}
}
