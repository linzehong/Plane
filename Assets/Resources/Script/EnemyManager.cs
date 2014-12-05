using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	void Start () {
        Invoke("toCreate", 1);
	}

	void Update () {
	
	}

	private void createEnemy() {
		string prefabName = "Prefabs/enemy_S";
		Vector3 mTmpPos = new Vector3(0, 0, 10);

		int rdm = Random.Range (0, 100);
		if (rdm < 65) {
			prefabName = "Prefabs/enemy_S";

            mTmpPos.x = Random.Range(20, ScreenAdapter.SCREEN_WIDTH - 20);
            mTmpPos.y = ScreenAdapter.SCREEN_HEIGHT + 20;
		}
		else if (rdm < 95) {
			prefabName = "Prefabs/enemy_M";

            mTmpPos.x = Random.Range(30, ScreenAdapter.SCREEN_WIDTH - 30);
            mTmpPos.y = ScreenAdapter.SCREEN_HEIGHT + 40;
		}
		else if (rdm < 100) {
			prefabName = "Prefabs/enemy_L";

            mTmpPos.x = Random.Range(70, ScreenAdapter.SCREEN_WIDTH - 70);
            mTmpPos.y = ScreenAdapter.SCREEN_HEIGHT + 80;
		}

        mTmpPos = ScreenAdapter.transformVector(mTmpPos);
		mTmpPos = Camera.main.ScreenToWorldPoint(mTmpPos);
		Instantiate(Resources.Load<GameObject>(prefabName), mTmpPos, Quaternion.identity);
	}

    private void toCreate() {
        createEnemy();

        Invoke("toCreate", Random.Range(0.4f, 2f));
    }

    public void stopCreate() {
        CancelInvoke();
    }

    public void startCreate() {
        if (!IsInvoking()) {
            Invoke("toCreate", 1);
        }        
    }

}
