using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BombManagment : MonoBehaviour
{
    public Sprite[] bombSprites; // 爆弾のスプライト（Inspectorで設定）
    public string gameOverSceneName = "BBPEventScene";
    private int bombIndex; // フィールドとして定義
    private SpriteRenderer spriteRenderer; // SpriteRendererをキャッシュ

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bombIndex = Random.Range(0, bombSprites.Length); // 爆弾のインデックスをランダムに決定
        spriteRenderer = GetComponent<SpriteRenderer>(); // スプライトレンダラーを取得
        if (spriteRenderer == null)
        {
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>(); // SpriteRendererを自動追加
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (spriteRenderer == null) return;
        if (Gamepad.current == null) return;

        if (Gamepad.current.triangleButton.wasPressedThisFrame || Keyboard.current.qKey.wasPressedThisFrame)
        {
            HandleBombSelection(0, "三角");
        }
        if (Gamepad.current.squareButton.wasPressedThisFrame || Keyboard.current.wKey.wasPressedThisFrame)
        {
            HandleBombSelection(1, "四角");
        }
        if (Gamepad.current.crossButton.wasPressedThisFrame || Keyboard.current.eKey.wasPressedThisFrame)
        {
            HandleBombSelection(2, "×");
        }
    }

    private void HandleBombSelection(int selectedIndex, string shapeName)
    {
        if (bombIndex == selectedIndex)
        {
            // 爆発フラグを立てる
            GameData.bombExploded = true;
            GameData.bombExplodedPlayer = GameData.currentPlayer; // 爆発したプレイヤーを記録
            GameData.bombGameFinished = true;
            SceneManager.LoadScene("爆弾解除失敗画面");
        }
        else
        {
            GameData.bombGameFinished = true;
            SceneManager.LoadScene("爆弾解除成功画面");
        }
    }
}