using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class PlayerControllerB: MonoBehaviour
{
    Vector3 offsetB = new Vector3(0.6f, 0, 0);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform[] masu; // マス座標（Inspectorで設定）
    int currentIndexB = 0;//現在のBチームマスの位置

    void Start()
    {
        Application.targetFrameRate = 60;
        transform.position =this.masu[0].position + offsetB;
    }
    void Update()
    {
        // テスト：スペースキーで3マス進む
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            StartCoroutine(MoveStep(3));
        }
    }

    IEnumerator MoveStep(int step)
    {
        for (int i = 0; i < step; i++)
        {
            currentIndexB++;

            // ゴールチェック
            if (currentIndexB >= masu.Length)
            {
                currentIndexB = masu.Length-1;
                if(this.transform.position == masu[21].position + offsetB)
                {
                    Debug.Log("ゴール！");
                }
                yield break;
            }

            // 次のマスへ移動
            Vector3 target = masu[currentIndexB].position + offsetB;
            yield return StartCoroutine(MoveTo(target));
        }
    }

    IEnumerator MoveTo(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 5f * Time.deltaTime);

            yield return null;
        }
    }
}
