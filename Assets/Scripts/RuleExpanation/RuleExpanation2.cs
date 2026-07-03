using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RuleExpanation2 : MonoBehaviour
{
    void Update()
    {
        if(Gamepad.current.circleButton.wasPressedThisFrame || Keyboard.current.enterKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("すごろくルールの説明画面３");
        }
    }
}
