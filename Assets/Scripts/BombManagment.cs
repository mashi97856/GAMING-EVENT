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
            Debug.Log($"{shapeName}の爆弾だ！ゲームオーバー！ シーンをロードします: {gameOverSceneName}");
            LoadGameOverScene();
        }
        else
        {
            Debug.Log($"{shapeName}の爆弾はセーフ！");
        }
    }

    private void LoadGameOverScene()
    {
        if (string.IsNullOrEmpty(gameOverSceneName))
        {
            Debug.LogError("ゲームオーバーシーン名が空です。");
            return;
        }

        if (!Application.CanStreamedLevelBeLoaded(gameOverSceneName))
        {
            Debug.LogError($"シーン '{gameOverSceneName}' がビルド設定に追加されていません。Build Settings にシーンを追加してください。");
            return;
        }

        SceneManager.LoadScene(gameOverSceneName);
    }
}