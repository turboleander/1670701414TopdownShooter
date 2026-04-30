using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveData
{
    public int unlockedLevel = 1;
}

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    public SaveData currentData;

    private string saveFilePath;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            saveFilePath = Application.persistentDataPath + "/gamesave.json";

            LoadProgress();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UnlockLevel(int levelToUnlock)
    {
        if (levelToUnlock > currentData.unlockedLevel)
        {
            currentData.unlockedLevel = levelToUnlock;
            SaveProgress();
        }
    }

    public void SaveProgress()
    {
        string json = JsonUtility.ToJson(currentData, true);

        File.WriteAllText(saveFilePath, json);
        Debug.Log("Saved to: " + saveFilePath);
    }

    public void LoadProgress()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            currentData = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("Loaded Saved: " + currentData.unlockedLevel);
        }
        else
        {
            currentData = new SaveData();
            Debug.Log("Save not found");
        }
    }
}