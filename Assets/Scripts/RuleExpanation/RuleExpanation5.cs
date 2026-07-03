using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RuleExpanation5 : MonoBehaviour
{
    void Update()
    {
        if(Gamepad.current.circleButton.wasPressedThisFrame || Keyboard.current.enterKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("すごろくルールの説明画面６");
        }
    }
}
