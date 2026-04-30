using UnityEngine;

public class GameState : MonoBehaviour
{
    private int hitCount = 0;
    public int maxHits = 3;

    public UIManager uiManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            hitCount++;
            if (hitCount >= maxHits)
            {
                Debug.Log("Game Over!");

                if (uiManager != null)
                {
                    uiManager.ShowGameOver();
                }
                else
                {
                    Time.timeScale = 0;
                }
            }
        }
    }
}