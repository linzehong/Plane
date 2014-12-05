using UnityEngine;
using System.Collections;

public class BtnPause : MonoBehaviour {

    private GameManager mGameManager;

    void Start() {
        mGameManager = FindObjectOfType<GameManager>();
    }

    void Update() {

    }

    void OnMouseDown() {
        if (mGameManager.isStatePlaying()) {
            GetComponent<Animator>().SetBool("isPause", true);
        }
    }

    void OnMouseUp() {
        if (mGameManager.isStatePlaying()) {
            GetComponent<Animator>().SetBool("isPause", false);

            mGameManager.switchToPauseMenu();
        }
    }



}
