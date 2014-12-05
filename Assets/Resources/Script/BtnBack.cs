using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BtnBack : MonoBehaviour {

	void Start () {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(onClick);
	}
	
	void Update () {
	
	}

    void onClick() {
        FindObjectOfType<MenuCtrl>().clickBtnBack();
    }

}
