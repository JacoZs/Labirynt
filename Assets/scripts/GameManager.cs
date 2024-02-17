using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    int timeToEnd, points;
    [SerializeField]
    bool isGamePaused,endGame, win;
    [SerializeField]
    KeyCode pauseKey = KeyCode.P;
    public int redKey, greenKey, goldKey;
    

    private void Start()
    {
        if(instance == null)
            instance = this;
        if(timeToEnd <= 0)
        {
            timeToEnd = 90;
        }
        InvokeRepeating("Stopper", 2, 1);
    }
    private void PauseGame()
    {
        Debug.Log("Game Paused");
        Time.timeScale = 0;
        isGamePaused = true;
    }
    private void ResumeGame()
    {
        Debug.Log("Game Resumed");
        Time.timeScale = 1;
        isGamePaused = false;
    }
    private void Update()
    {
        CheckPause();
    }
    private void CheckPause()
    {
        if (!Input.GetKeyDown(pauseKey)) return;
        if(isGamePaused)
            ResumeGame();
        else
            PauseGame();
        
    }



    private void Stopper()
    {
        timeToEnd--;
        Debug.Log($"Time: {timeToEnd}s");

        if(timeToEnd <= 0)
        {
            endGame = true;
            EndGame();

        }
    }
    private void EndGame()
    {
        CancelInvoke("Stopper");
        if (win) Debug.Log("You win!");
        else Debug.Log("You lose!");
    }
    public void AddPoints(int point)
    {
        points += point;
    }
    public void AddTime(int addTime)
    {
        timeToEnd += addTime;
    }
    public void FreezeTime(int freezeTime)
    {
        CancelInvoke("Stopper");
        InvokeRepeating("Stopper", freezeTime, 1);
    }
    public void AddKey(KeyColor keyColor)
    {
        if (keyColor == KeyColor.Red) redKey++;
        else if (keyColor == KeyColor.Green) greenKey++;
        else if (keyColor == KeyColor.Gold) goldKey++;
        else Debug.LogWarning($"Key {keyColor} is unsupported");
        
    }
}
