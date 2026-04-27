using UnityEngine;
using UnityEngine.InputSystem;

public class BombManagment : MonoBehaviour
{
    public Sprite[] bombSprites; // 爆弾のスプライト（Inspectorで設定）
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

        if(Keyboard.current.qKey.wasPressedThisFrame)
        {
            if (bombIndex == 0) // 爆弾が選ばれた場合
            {
                Debug.Log("爆弾だ！ゲームオーバー！");
                // ゲームオーバーの処理をここに追加
            }
            else
            {
                Debug.Log("三角の爆弾はセーフ！");
            }
        }
        if(Keyboard.current.wKey.wasPressedThisFrame)
        {
            if (bombIndex == 1) // 爆弾が選ばれた場合
            {
                Debug.Log("爆弾だ！ゲームオーバー！");
                // ゲームオーバーの処理をここに追加
            }
            else
            {
                Debug.Log("四角の爆弾はセーフ！");
            }
        }
        if(Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (bombIndex == 2) // 爆弾が選ばれた場合
            {
                Debug.Log("爆弾だ！ゲームオーバー！");
                // ゲームオーバーの処理をここに追加
            }
            else
            {
                Debug.Log("×の爆弾はセーフ！");
            }
        }
    }
}