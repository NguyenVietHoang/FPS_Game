using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : Singleton<GameplayManager>
{
    [SerializeField]
    private MenuView MenuView;
    [SerializeField]
    private ReactManager ReactManager;

    public string address { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        address = "Test Address...";

        if(MenuView != null)
        {
            MenuView.Init();

            MenuView.OnLoginClicked = null;
            MenuView.OnLoginClicked += OnLogin;            
            //MenuView.OnLoginClicked += () => OnLoginSuccess("Test Feature...");            
        }
        
        if (ReactManager != null)
        {
            ReactManager.Init();

            ReactManager.OnLoginSuccess = null;
            ReactManager.OnLoginSuccess += OnLoginSuccess;
        }
    }

    /// <summary>
    /// Call this event when the Login button was pressed
    /// </summary>
    void OnLogin()
    {
        ReactManager.OnLogin();
    }

    /// <summary>
    /// This function will be called when the React Page called "LoginSuccess" of ReactManager
    /// </summary>
    /// <param name="msg"></param>
    void OnLoginSuccess(string msg)
    {
        address = msg;
        ChangeScene();
    }

    void ChangeScene()
    {
        MenuView.SetMessage("Login success...Charging game 0%");
        StartCoroutine(LoadScene_Async("Playground"));
    }

    IEnumerator LoadScene_Async(string sceneName)
    {
        yield return null;

        //Begin to load the Scene you specify
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;
        Debug.Log("Pro :" + asyncOperation.progress);
        //When the load is still in progress, output the Text and progress bar
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            MenuView.SetMessage("Login success...Charging game " + (asyncOperation.progress * 100) + "%");

            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
                //Change the Text to show the Scene is ready
                MenuView.SetMessage("Press the space bar to continue...");
                //Wait to you press the space key to activate the Scene
                if (Input.GetKeyDown(KeyCode.Space))
                    //Activate the Scene
                    asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    public void OnScoreUpdate(int _score)
    {
        ReactManager.React_ScoreUpdate(_score);
    }
}
