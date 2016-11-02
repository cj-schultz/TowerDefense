using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one GameManager in the scene!");
            return;
        }

        instance = this;
    }

    private bool isGameOver = false;

    public void EndGame()
    {
        isGameOver = true;
        Debug.Log("Game Over!");
    }
}
