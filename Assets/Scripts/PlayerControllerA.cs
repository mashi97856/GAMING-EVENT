using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerControllerA : MonoBehaviour
{

    // 各マス座標（Inspectorで設定）
    public Transform[] masu;
    // 重なり防止
    Vector3 offsetA = new Vector3(-0.6f,0,0);
    //現在のAチームマスの位置
    int currentIndexA = 0;
    bool isMovingA = false;

    public void Move(int step)
    {
        StartCoroutine(MoveStep(step));
    }

    void Start()
    {
        Application.targetFrameRate = 60;
        //初期値の設定
        transform.position =this.masu[0].position + offsetA;
        isMovingA = true;

    }
    void Update()
    {
        // テスト：Qキーで3マス進む
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            StartCoroutine(MoveStep(3));
        }
    }

    IEnumerator MoveStep(int step)
    {
        for (int i = 0; i < step; i++)
        {
            currentIndexA++;

            // ゴールチェック
            if (currentIndexA >= masu.Length)
            {
                currentIndexA = masu.Length-1;
                if (currentIndexA >= masu.Length - 1)
                {
                    Debug.Log("ゴール！");
                }
                yield break;
            }

            if (isMovingA == true)
            {
                // 次のマスへ移動
                Vector3 target = masu[currentIndexA].position + offsetA;
                //移動し終わるまで待機
                yield return StartCoroutine(MoveTo(target));
            }
        }
    }

    IEnumerator MoveTo(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.05f)
        {
            //移動する速さの設定
            transform.position = Vector3.MoveTowards(transform.position,target,5f * Time.deltaTime);
            isMovingA = false;
            yield return null;
            isMovingA = true;
        }
    }
}
