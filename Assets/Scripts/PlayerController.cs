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
                yield break;
            }

            Vector3 target = masu[currentIndex].position + offset;
            yield return StartCoroutine(MoveTo(target));
        }
    }

    IEnumerator MoveTo(Vector3 target)
    {
        while (Vector3.Distance(transform.position, target) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target,
                5f * Time.deltaTime
            );
            yield return null;
        }
    }
}
