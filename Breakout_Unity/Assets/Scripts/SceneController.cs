using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
	Animator anim;
	GeneralStateBehaviour[] behaviour;

	void Start()
    {
		Screen.SetResolution (432, 243, false);
		anim = GetComponent<Animator>();
	
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

	public void activateObject(string obj, bool active)
    {
		GameObject temp = GameObject.FindGameObjectWithTag (obj);
		temp.transform.GetChild(0).gameObject.SetActive (active);

	}
}
