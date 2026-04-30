using UnityEngine;

public class UiMainMenu : MonoBehaviour
{
    public void OnclickButtonStart(GameObject LvSelectPanel)
    {
        LvSelectPanel.SetActive(true);
    }

    public void OnclickButtonExit()
    {
        Application.Quit();
    }

    public void OnclickButtonBack(GameObject LvSelectPanel)
    {
        LvSelectPanel.SetActive(false);
    }
}
