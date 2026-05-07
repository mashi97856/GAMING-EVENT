using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Transform[] masu;// 空マスの位置（Inspectorで設定）
    public Vector3 offset;// プレイヤーの位置のオフセット（Inspectorで設定）
    public bool isMoving = false;// プレイヤーが移動中かどうか
    public int currentIndex = 0;// 現在のマスのインデックス

    void Start()
    {
    if (gameObject.name == "TeamA")
    {
        currentIndex = GameData.playerAIndex;
    }
    else
    {
        currentIndex = GameData.playerBIndex;
    }

    transform.position = masu[currentIndex].position + offset;

    // 爆弾が爆発した場合、2マス戻す（アニメーション付き）
    if (GameData.bombExploded && GameData.bombExplodedPlayer == (gameObject.name == "TeamA" ? 0 : 1))
    {
        Debug.Log($"{gameObject.name}: 爆発したので2マス戻ります。現在:{currentIndex} → ");
        StartCoroutine(MoveBack(2));
        GameData.bombExploded = false;
        GameData.bombExplodedPlayer = -1;
    }
    }
IEnumerator MoveBack(int steps)
{
    isMoving = true;

    for (int i = 0; i < steps; i++)
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = 0;
        }

        Vector3 target = masu[currentIndex].position + offset;
        yield return StartCoroutine(MoveTo(target));
    }

    isMoving = false;
    SavePosition();
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

        if (currentIndex >= masu.Length-1)
        {
            currentIndex = masu.Length - 1;

            Debug.Log(gameObject.name + " ゴール！");

            SceneManager.LoadScene("EndScene");
            break;
        }

        Vector3 target = masu[currentIndex].position + offset;

        yield return StartCoroutine(MoveTo(target));

        // ★止まった瞬間だけ判定
        if (currentIndex == 4 ||
            currentIndex == 10 ||
            currentIndex == 15)
        {
            SavePosition();

            SceneManager.LoadScene("爆弾解除ゲーム");

            yield break;
        }
    }

    isMoving = false;

    SavePosition();
}
void SavePosition()
{
    if (gameObject.name == "TeamA")
    {
        GameData.playerAIndex = currentIndex;
    }
    else
    {
        GameData.playerBIndex = currentIndex;
    }
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
