using CategoryEnums;
using UnityEngine;

public class GameplayMenuUI : MonoBehaviour
{
    /// <summary>
    /// 
    /// Button click event for the exit button
    /// 
    /// </summary>
    public void ExitButton()
    {
        GameManager.instance.sceneManager.LoadNewScene(SceneList.MainMenuScene);
    }

    /// <summary>
    /// 
    /// Button click event for the quit button
    /// 
    /// </summary>
    public void QuitButton()
    {
        Application.Quit();
    }
}
