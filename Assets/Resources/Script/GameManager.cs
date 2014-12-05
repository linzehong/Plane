using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    private GameObject mUIScore;
    private GameObject mPauseMenu;

    private int mScore = 0;

    private int mState;
    public const int STATE_NONE = -1;
    public const int STATE_PLAYING = 0;
    public const int STATE_PAUSE = 1;
    public const int STATE_END = 2;

	void Start () {
		Vector3 bgPos = new Vector3 (ScreenAdapter.SCREEN_WIDTH / 2,ScreenAdapter.SCREEN_HEIGHT,10);
        bgPos = ScreenAdapter.transformVector(bgPos);
        bgPos = Camera.main.ScreenToWorldPoint(bgPos);
        Instantiate(Resources.Load<GameObject>("Prefabs/BGManager"), bgPos, Quaternion.identity);

        Vector3 btnPausePos = new Vector3(40, ScreenAdapter.SCREEN_HEIGHT - 40, 10);
        btnPausePos = ScreenAdapter.transformVector(btnPausePos);
        btnPausePos = Camera.main.ScreenToWorldPoint(btnPausePos);
		Instantiate(Resources.Load<GameObject>("Prefabs/BtnPause"), btnPausePos, Quaternion.identity);

		Vector3 aircraftPos = new Vector3 (0,-3f,0);
	    Instantiate(Resources.Load<GameObject>("Prefabs/Aircraft"), aircraftPos, Quaternion.identity);

        mUIScore = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/CanvasScore"));
        
        mState = STATE_PLAYING;
	}

	void Update () {
        mUIScore.GetComponentInChildren<Text>().text = mScore.ToString();
	}

    private void setState(int state) {
        mState = state;
    }

    public bool isStatePlaying() {
        return (mState == STATE_PLAYING);
    }

    public bool isStatePause() {
        return (mState == STATE_PAUSE);
    }

    public bool isStateEnd() {
        return (mState == STATE_END);
    }

    public void switchToPauseMenu() {
        mState = STATE_PAUSE;

        createPauseMenu();

        FindObjectOfType<EnemyManager>().stopCreate();
    }

    public void backFmPauseMenu(int btnIndex) {
        mState = STATE_PLAYING;

        destroyPauseMenu();

        FindObjectOfType<EnemyManager>().startCreate();

        switch (btnIndex) {
            case 0:
                break;
            case 1:
                restart();
                break;
            case 2:
                Application.LoadLevel("start");
                break;
        }
    }

    public void switchToEnd() {
        mState = STATE_END;

        createCanvasEnd();

        FindObjectOfType<EnemyManager>().stopCreate();
    }

    private void createPauseMenu() {
        if (mPauseMenu == null) {
            mPauseMenu = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/CanvasPause"));
        }        
    }

    private void destroyPauseMenu() {
        if (mPauseMenu != null) {
            GameObject.Destroy(mPauseMenu);
            mPauseMenu = null;
        }
    }

    private void createCanvasEnd() {
        GameObject uiEnd = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/CanvasEnd"));
        uiEnd.transform.FindChild("Score").GetComponent<Text>().text = mScore.ToString(); 
    }

    public void restart() {
        GameObject[] objs = null;

        objs = GameObject.FindGameObjectsWithTag("Enemy_S");
        foreach (GameObject obj in objs) {
            GameObject.Destroy(obj);
        }

        objs = GameObject.FindGameObjectsWithTag("Enemy_M");
        foreach (GameObject obj in objs) {
            GameObject.Destroy(obj);
        }

        objs = GameObject.FindGameObjectsWithTag("Enemy_L");
        foreach (GameObject obj in objs) {
            GameObject.Destroy(obj);
        }

        mScore = 0;

        mState = STATE_PLAYING;
    }

    public void addScore(int addScore) {
        mScore += addScore;
    }

    public int getScore() {
        return mScore;
    }

    public void btnContinueHandleOnEndUI() {
        Application.LoadLevel("game");
    }

}
