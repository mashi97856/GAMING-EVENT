using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SelfIntroduction : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Gamepad.current.circleButton.wasPressedThisFrame || Keyboard.current.enterKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
