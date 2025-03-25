using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        gameOn = true;
    }
}
