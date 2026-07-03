using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameStartMangment : MonoBehaviour
{
    void Start()
    {
        GetComponent<AudioSource>().Play();
    }
    void Update()
    {
        if(Gamepad.current.circleButton.wasPressedThisFrame || Keyboard.current.enterKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("すごろくルールの説明画面１");
        }
    }
}
