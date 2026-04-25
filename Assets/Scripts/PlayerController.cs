using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Transform[] masu;
    public Vector3 offset;
    public bool isMoving = false;
    public int currentIndex = 0;

    void Start()
    {
        transform.position = masu[0].position + offset;
    }

    public void Move(int step)
    {
        if (isMoving) return; // 動いてたら無視

        StartCoroutine(MoveStep(step));
    }
    IEnumerator MoveStep(int step)
    {
        isMoving = true;

        for (int i = 0; i < step; i++)
        {
            currentIndex++;

            if (currentIndex >= masu.Length)
            {
                currentIndex = masu.Length - 1;
                Debug.Log(gameObject.name + " ゴール！");
                break; // ←ここが重要（yield breakじゃない）
            }

            Vector3 target = masu[currentIndex].position + offset;
            yield return StartCoroutine(MoveTo(target));
        }

        // ★これ絶対必要
        isMoving = false;
    }
    IEnumerator MoveTo(Vector3 target)
    { 

        int safety = 0; // 無限防止

        while (Vector3.Distance(transform.position, target) > 0.1f)
        {

            transform.position = Vector3.MoveTowards
                (
                transform.position,
                target,
                5f * Time.deltaTime
                 );

            safety++;
            if (safety > 300) // 5秒くらいで強制終了
            {
                break;
            }

            yield return null;
        }

        transform.position = target;
    }
}
