using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BtnContinue : MonoBehaviour {

	void Start () {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(onClick);
	}

	void Update () {
	
	}

    void onClick()
    {
        FindObjectOfType<GameManager>().btnContinueHandleOnEndUI();
    }

}
