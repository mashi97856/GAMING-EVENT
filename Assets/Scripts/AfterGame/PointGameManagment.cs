using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PointGameManagment : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if(Gamepad.current.triangleButton.wasPressedThisFrame || Keyboard.current.qKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("AVictoryScene");
        }
        if(Gamepad.current.crossButton.wasPressedThisFrame || Keyboard.current.eKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("BVictoryScene");
        }
    }
}
