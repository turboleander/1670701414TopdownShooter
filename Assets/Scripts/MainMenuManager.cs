using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Level Buttons")]
    public Button[] levelButton;

    void Start()
    {
        Time.timeScale = 1f;
        SaveData data = SaveManager.instance.currentData;

        levelButton[0].interactable = true;

        levelButton[1].interactable = data.levelCompleted[0];

        levelButton[2].interactable = data.levelCompleted[1];

        levelButton[3].interactable = data.levelCompleted[1];

        if (levelButton.Length >= 5)
        {
            levelButton[4].interactable = data.levelCompleted[2] && data.levelCompleted[3];
        }

        //int unlocked = 1;
        //if (SaveManager.instance != null)
        //{
        //    unlocked = SaveManager.instance.currentData.unlockedLevel;
        //}

        for (int i = 0; i < levelButton.Length; i++)
        {
            //levelButton[i].interactable = (unlocked >= (i + 1));

            int sceneIndexToLoad = i + 1;

            levelButton[i].onClick.RemoveAllListeners();

            levelButton[i].onClick.AddListener(() => LoadLevelByIndex(sceneIndexToLoad));
        }
    }

    private void LoadLevelByIndex(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}