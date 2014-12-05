using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnPause : MonoBehaviour {

	void Start () {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(onClick);
	}
	
	void Update () {
	
	}

    void onClick() {
        switch (tag) {
            case "OnPauseContinue":
                FindObjectOfType<GameManager>().backFmPauseMenu(0);
                break;
            case "OnPauseRestart":
                FindObjectOfType<GameManager>().backFmPauseMenu(1);
                break;
            case "OnPauseMenu":
                FindObjectOfType<GameManager>().backFmPauseMenu(2);
                break;
        }
    }

}
