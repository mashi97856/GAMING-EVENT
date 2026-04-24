using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Transform[] masu;
    public Vector3 offset;

    int currentIndex = 0;

    void Start()
    {
        if (masu.Length == 0)
        {
            Debug.LogError("masuが設定されてない！");
            return;
        }

        transform.position = masu[0].position + offset;
    }

    public void Move(int step)
    {
        StartCoroutine(MoveStep(step));
    }

    IEnumerator MoveStep(int step)
    {
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
