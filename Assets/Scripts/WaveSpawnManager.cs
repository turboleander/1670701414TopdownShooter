using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveSpawnManager : MonoBehaviour
{
    public Wave[] waveConfigurations;
    public WaveController waveController;

    public UIManager uiManager;

    private int currentWave = 0;
    private float waveEndTime = 0f;

    public bool IslevelCompleted = false;

    void Start()
    {
        waveController.StartWave(waveConfigurations[currentWave]);
        waveEndTime = Time.time + waveConfigurations[currentWave].waveInterval;
    }

    void Update()
    {
        if (currentWave >= waveConfigurations.Length)
        {
            if (waveController.IsComplete() && !IslevelCompleted)
            {
                Debug.Log("All waves completed!");
                IslevelCompleted = true;
                //save progress
                if (SaveManager.instance != null)
                {
                    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                    SaveManager.instance.UnlockLevel(currentSceneIndex + 1);
                }
                //show win screen
                if (uiManager != null)
                {
                    uiManager.ShowWinScreen();
                }
            }
            return;
        }

        if (Time.time >= waveEndTime && waveController.IsComplete())
        {
            currentWave++;
            if (currentWave >= waveConfigurations.Length)
            {
                Debug.Log("All Enemies Spawned! Waiting for player to clear...");
            }
            else
            {
                waveController.StartWave(waveConfigurations[currentWave]);
                waveEndTime = Time.time + waveConfigurations[currentWave].waveInterval;
            }
        }
    }
}