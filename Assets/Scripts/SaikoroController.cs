using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SaikoroController : MonoBehaviour
{
    public Sprite[] saikoroSprites; // サイコロの面のスプライト（Inspectorで設定）
    float time = 0;
    int idx = 0;
    bool isRolling = true; // サイコロが回転中かどうか
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
        // スペースキーで停止
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (isRolling)
            {
                isRolling = false;

                // ランダムで最終結果
                int result = Random.Range(0, saikoroSprites.Length);
                spriteRenderer.sprite = saikoroSprites[result];

                Debug.Log("出目: " + (result + 1));
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
