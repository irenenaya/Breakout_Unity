using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * Main controller class for transitions between scenes. It gets a reference to the base class of all 
 * State Machine Behaviours (GeneralStateBehaviour), and to the animator, to pass input. 
 * The class lives in the PersistentScene and has different methods to load / unload scenes asynchronously
*/
public class SceneController : MonoBehaviour {
    Animator anim;
    GeneralStateBehaviour[] behaviour;

    void Start()
    {
        // Setting screen resolution here because it will not work just from Unity's Editor settings
        Screen.SetResolution (432, 243, false);
        anim = GetComponent<Animator>();
        // get a reference to the all StateMachineBehaviours derived from base class.
        // This is how the behaviours get a reference to this class.  
        behaviour = anim.GetBehaviours<GeneralStateBehaviour>();
        for (int i = 0 ; i < behaviour.Length; ++i)
            behaviour[i].controller = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (InputHandle.Enter) {
            anim.SetTrigger ("EnterPressed");
        }
        if (InputHandle.Esc) {
            anim.SetTrigger ("EscPressed");
        }
    }

    private IEnumerator LoadSceneAndSetActive(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync (sceneName, LoadSceneMode.Additive);
        Scene newlyLoadedScene = SceneManager.GetSceneAt (SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene (newlyLoadedScene);
    }

    private IEnumerator UnloadAndLoadScene(string sceneName)
    {		
        yield return SceneManager.UnloadSceneAsync (SceneManager.GetActiveScene ().buildIndex);
        yield return StartCoroutine (LoadSceneAndSetActive (sceneName));
    }

    private IEnumerator UnloadOnly(string sceneName)
    {
        yield return SceneManager.UnloadSceneAsync (sceneName);
    }

    public void LoadNextScene(string scene)
    {
        StartCoroutine (UnloadAndLoadScene (scene));

    }

    public void UnloadScene(string scene)
    {
        if (SceneManager.GetSceneByName(scene).IsValid())
            StartCoroutine (UnloadOnly (scene));
    }

    public void AddScene(string scene)
    {
        StartCoroutine (LoadSceneAndSetActive (scene));
    }
    // Used to toggle the active state of objects that are in the Persistent Scene
    // Inactive objects can't be found during runtime, so they are placed inside an active
    // parent object, and we toggle the child.
    public void activateObject(string obj, bool active)
    {
        GameObject temp = GameObject.FindGameObjectWithTag (obj);
        temp.transform.GetChild(0).gameObject.SetActive (active);

    }
}
