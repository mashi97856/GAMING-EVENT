using Unity.Multiplayer.PlayMode;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.SceneManagement;

public class SaikoroController : MonoBehaviour
{
    public Sprite[] saikoroSprites; // サイコロの面のスプライト（Inspectorで設定）
    public float time = 0;// サイコロの回転時間を管理
    public int idx = 0; // サイコロの面の数字の管理
    public bool isRolling = false; // サイコロが回転中かどうか
    public int currentPlayer = 0; // 0=プレイヤーA、1=プレイヤーB
    public GameObject[] players;// プレイヤーのゲームオブジェクト（Inspectorで設定）
    SpriteRenderer spriteRenderer;// サイコロのスプライトを変更するためのコンポーネント
    public bool canRoll = true;// サイコロを振れるかどうか

    void Start()
    {
        Debug.Log("サイコロ開始");
        Application.targetFrameRate = 60;
        spriteRenderer = GetComponent<SpriteRenderer>();// サイコロのスプライトを変更するためのコンポーネントを取得
        isRolling = true; // サイコロを自動で回転開始
    }

    // Update is called once per frame
    void Update()
    {
        // スペースで止めるだけ
        if (Keyboard.current.spaceKey.wasPressedThisFrame && canRoll && isRolling)
        {
            StopDice();
        }

        // 回転アニメーション
        if (isRolling)
        {
            time += Time.deltaTime;

            if (time >= 0.1f)
            {
                time = 0;
                spriteRenderer.sprite = saikoroSprites[idx];
                idx = (idx + 1) % saikoroSprites.Length;
            }
        }
    }
    void StopDice()
    {
        isRolling = false;
        canRoll = false;

        int result = Random.Range(0, saikoroSprites.Length);
        spriteRenderer.sprite = saikoroSprites[result];

        GameObject nowPlayer = players[currentPlayer];
        PlayerController pc = nowPlayer.GetComponent<PlayerController>();// プレイヤーのゲームオブジェクトからPlayerControllerを取得

        pc.Move(result + 1);

        StartCoroutine(WaitTurnEnd(pc));
    }
    IEnumerator RollAndStop(int milliseconds)
    {
        isRolling = true;

        float seconds = milliseconds / 1000f;
        yield return new WaitForSeconds(seconds);

        isRolling = false;

        int result = Random.Range(0, saikoroSprites.Length);
        spriteRenderer.sprite = saikoroSprites[result];

        GameObject nowPlayer = players[currentPlayer];
        PlayerController pc = nowPlayer.GetComponent<PlayerController>();
        if (pc != null)
        {
            pc.Move(result + 1);
        }
        StartCoroutine(WaitTurnEnd(pc));
    }
    IEnumerator WaitTurnEnd(PlayerController pc)
    {
        while (pc.isMoving)
        {
            yield return null;
        }

        currentPlayer = (currentPlayer + 1) % players.Length;
        isRolling = true;
        canRoll = true;
    }
}
