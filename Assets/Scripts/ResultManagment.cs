using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ResultManagment : MonoBehaviour
{
void Start()
    {
        GetComponent<AudioSource>().Play();
    }
    // Update is called once per frame
    void Update()
    {
        if(Gamepad.current.circleButton.wasPressedThisFrame || Keyboard.current.enterKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("BBPEvent");
        }
    }
}
