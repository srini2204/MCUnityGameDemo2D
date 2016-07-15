using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum GameScene
{
    _MainScene,
    MatchMe,
    TuneTime
};

public class SceneNavController : MonoBehaviour
{

    public GameScene currentScene;
    public Image homeButton;

    [SerializeField]
    public bool returnToLauncher;
    [SerializeField]
    private bool homeButtonVisible;

    private GameManager GM;
    
    public bool HomeButtonVisible
    {
        get
        {
            return homeButtonVisible;
        }

        set
        {
            homeButtonVisible = value;
            homeButton.enabled = homeButtonVisible;
        }
    }

    private void setHomeButtonVisibilty(bool value)
    {
        HomeButtonVisible = value;
        homeButton.enabled = HomeButtonVisible;
    }

    public void goToScene(GameScene sceneID)
    {
        Debug.Log("Moving to State:" + sceneID);
        if (currentScene == sceneID)
            return;

        GM = GameManager.Instance;

        currentScene = sceneID;

        switch (currentScene)
        {
            case GameScene._MainScene:
                HomeButtonVisible = false;
                Debug.Log("State:" + sceneID);
                break;
            case GameScene.MatchMe:
            case GameScene.TuneTime:
                homeButton.enabled = true;
                break;
            default:
                break;
        }

        SceneManager.LoadScene((int)currentScene);
        Debug.Log("State Loaded : " + sceneID);
    }

    public void triggerHomeButtonAnimation()
    {

    }

    public void homeButtonAnimationDone()
    {
        Debug.Log("HomeButton Animation Done");
        goToScene(GameScene._MainScene);
        Debug.Log("LoadingLauncher");
    }
}
