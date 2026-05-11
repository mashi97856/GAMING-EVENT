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
        Application.targetFrameRate = 60;
        Debug.Log("爆弾開始!三つのうちどれか一つがランダムで爆弾だよ!爆弾じゃないのを選んでボタンを押してね！");
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
        if (Keyboard.current == null) return;

        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            HandleBombSelection(0, "三角");
        }
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            HandleBombSelection(1, "四角");
        }
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            HandleBombSelection(2, "×");
        }
    }

    private void HandleBombSelection(int selectedIndex, string shapeName)
    {
        if (bombIndex == selectedIndex)
        {
            Debug.Log($"{shapeName}の爆弾だ！２マス下がります！");
            // 爆発フラグを立てる
            GameData.bombExploded = true;
            GameData.bombExplodedPlayer = GameData.currentPlayer; // 爆発したプレイヤーを記録
            GameData.bombGameFinished = true;
            SceneManager.LoadScene("爆弾解除失敗画面");
        }
        else
        {
            Debug.Log($"{shapeName}の爆弾はセーフ！");
            GameData.bombGameFinished = true;
            SceneManager.LoadScene("爆弾解除成功画面");
        }
    }
}