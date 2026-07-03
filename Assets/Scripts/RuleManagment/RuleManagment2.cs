using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RuleManagment2 : MonoBehaviour
{
    void Update()
    {
        if (Gamepad.current.circleButton.wasPressedThisFrame || Keyboard.current.enterKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("爆弾解除ゲーム");
        }
    }
}
