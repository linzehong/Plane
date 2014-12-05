using UnityEngine;
using System.Collections;

public class MenuCtrl : MonoBehaviour {

    private GameObject mBtnAbout;
    private GameObject mPageAbout;
    private GameObject mTitle;
    private GameObject mBtnSingle;

    private Vector3 mOffset = ScreenAdapter.transformVector(new Vector3(ScreenAdapter.SCREEN_WIDTH, 0, 0));

    private int mState;
    private const int STATE_SHOW_BTN = 0;
    private const int STATE_PAGE_ABOUT = 1;

	void Start () {
        GameObject mUIAbout = (GameObject)Instantiate(Resources.Load<GameObject>("Prefabs/CanvasMenu"));
        mBtnAbout = mUIAbout.transform.FindChild("BtnAbout").gameObject;
        mPageAbout = mUIAbout.transform.FindChild("PageAbout").gameObject;
        mTitle = mUIAbout.transform.FindChild("Title").gameObject;
        mBtnSingle = mUIAbout.transform.FindChild("BtnSingle").gameObject;

        mPageAbout.transform.position += mOffset;

        mState = STATE_SHOW_BTN;
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Home)) {
            Application.Quit();
        }
	}

    public void clickBtnAbout() {
        if (mState == STATE_SHOW_BTN) {
            mState = STATE_PAGE_ABOUT;

            mBtnSingle.SetActive(false);

            iTween.MoveBy(mBtnAbout, -mOffset, 1f);
            iTween.MoveBy(mTitle, -mOffset, 1f);
 
            iTween.MoveBy(mPageAbout, -mOffset, 1f);
        }
    }

    public void clickBtnBack() {
        if (mState == STATE_PAGE_ABOUT) {
            mState = STATE_SHOW_BTN;

            mBtnSingle.SetActive(true);

            iTween.MoveBy(mBtnAbout, mOffset, 1f);
            iTween.MoveBy(mTitle, mOffset, 1f);

            iTween.MoveBy(mPageAbout, mOffset, 1f);
        }
    }

    public void enterGame() {
        Application.LoadLevel("game");
    }

}
