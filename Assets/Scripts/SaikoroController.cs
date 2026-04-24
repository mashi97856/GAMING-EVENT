using Unity.Multiplayer.PlayMode;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SaikoroControllerA : MonoBehaviour
{
    public Sprite[] saikoroSprites; // サイコロの面のスプライト（Inspectorで設定）
    float time = 0;
    int idx = 0;
    bool isRolling = true; // サイコロが回転中かどうか
    int currentPlayer = 0; // 0=プレイヤーA、1=プレイヤーB
    public GameObject[] players;
    SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // スペースキーで停止＆処理まとめる
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (isRolling)
            {
                isRolling = false;

                // 出目（0〜3）
                int result = Random.Range(0, saikoroSprites.Length);

                // 見た目更新
                spriteRenderer.sprite = saikoroSprites[result];

                Debug.Log("出目: " + (result + 1));

                // プレイヤー移動（+1して1〜3に）
                GameObject nowPlayer = players[currentPlayer];
                nowPlayer.GetComponent<PlayerController>().Move(result + 1);

                // ターン交代
                currentPlayer = (currentPlayer + 1) % players.Length;
            }
        }

        // 回転中だけアニメーション
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
}
