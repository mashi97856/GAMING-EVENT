using UnityEngine;
using UnityEngine.InputSystem;

public class masuManagment : MonoBehaviour
{
    int currentPlayer = 0; // 0=プレイヤーA、1=プレイヤーB
    public GameObject[] players;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
    }
    
   // Update is called once per frame
    void Update()
    {
        GameObject nowPlayer = players[currentPlayer];
        currentPlayer = 1 - currentPlayer;
    }
}
