using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{

    public string levelName;

    public void Home_Press()
    {

        Debug.Log("Load level: " + levelName);
        SceneManager.LoadScene(levelName);

    }
     
}