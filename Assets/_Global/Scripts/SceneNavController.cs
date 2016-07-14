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


    // Use this for initialization
    void Start()
    {

        //disable home button if current stateOject is Launcher or sceneID = 0;
        //homeButtonVisible = homeButton.activeInHierarchy;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void goToScene(GameScene sceneID)
    {
        Debug.Log("Moving to State:" + sceneID);
        if (currentScene == sceneID)
            return;

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
