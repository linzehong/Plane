using UnityEngine;
using System.Collections;

public class AircraftCtrl : MonoBehaviour {

    private GameManager mGameManager;

    private Vector3 mOffsetPosition;
    private Vector3 mTmpPosition = new Vector3();

    private int mState;
    private const int STATE_NORMAL = 0;
    private const int STATE_DEAD = 1;

    void Start() {
        mGameManager = FindObjectOfType<GameManager>();

        mState = STATE_NORMAL;

        GetComponent<Animator>().SetInteger("mHP", 1);

        InvokeRepeating("shoot", 0.15f, 0.15f);
    }

    void Update() {
    
    }

    IEnumerator OnMouseDown() {
        mTmpPosition.x = Input.mousePosition.x;
        mTmpPosition.y = Input.mousePosition.y;
        mTmpPosition.z = transform.position.z;
        mOffsetPosition = transform.position - Camera.main.ScreenToWorldPoint(mTmpPosition);

        while (Input.GetMouseButton(0)) {
            mTmpPosition.x = Input.mousePosition.x;
            mTmpPosition.y = Input.mousePosition.y;
            mTmpPosition.z = transform.position.z;
            transform.position = Camera.main.ScreenToWorldPoint(mTmpPosition) + mOffsetPosition;

            //边界处理
            mTmpPosition = Camera.main.WorldToScreenPoint(transform.position);
            if (mTmpPosition.x < 28) {
                mTmpPosition.x = 28;
            }
            if (mTmpPosition.x > Screen.width - 28) {
                mTmpPosition.x = Screen.width - 28;
            }
            if (mTmpPosition.y < 25) {
                mTmpPosition.y = 25;
            }
            if (mTmpPosition.y > Screen.height - 35) {
                mTmpPosition.y = Screen.height - 35;
            }
            transform.position = Camera.main.ScreenToWorldPoint(mTmpPosition);

            yield return 0; //这个很重要，循环执行
        }
    }

    public void hurt() {
        GetComponent<Animator>().SetInteger("mHP", 0);

        mState = STATE_DEAD;
    }

    public void exploEnd() {
        GameObject.Destroy(gameObject);

        mGameManager.switchToEnd();
    }

    private void shoot() {
        if (mGameManager.isStatePlaying()) {
            if (mState == STATE_NORMAL) {
                GameObject aircraft = GameObject.FindGameObjectWithTag("Aircraft");
                Vector3 pos = new Vector3(aircraft.transform.position.x, aircraft.transform.position.y + 0.6f, 10);
                Instantiate(Resources.Load<GameObject>("Prefabs/bullet"), pos, Quaternion.identity);
            }
        }
    }

}
