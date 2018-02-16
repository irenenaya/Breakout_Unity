using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
	Animator anim;
	GeneralStateBehaviour[] behaviour;

	IEnumerator Start () {
		anim = GetComponent<Animator> ();
	//	behaviour = anim.GetBehaviour<GeneralStateBehaviour> ();
		behaviour = anim.GetBehaviours<GeneralStateBehaviour> ();
		for (int i = 0 ; i < behaviour.Length; ++i)
			behaviour[i].controller = this;
		yield return StartCoroutine (LoadSceneAndSetActive ("StartScene"));
	}

	// Update is called once per frame
	void Update () {
		if (InputHandle.Enter) {
			anim.SetTrigger ("EnterPressed");
		}
	}

	private IEnumerator LoadSceneAndSetActive (string sceneName)
	{
		yield return SceneManager.LoadSceneAsync (sceneName, LoadSceneMode.Additive);
		Scene newlyLoadedScene = SceneManager.GetSceneAt (SceneManager.sceneCount - 1);
		SceneManager.SetActiveScene (newlyLoadedScene);
	}

	private IEnumerator UnloadAndLoadScene(string sceneName) {
		yield return SceneManager.UnloadSceneAsync (SceneManager.GetActiveScene ().buildIndex);
		yield return StartCoroutine (LoadSceneAndSetActive (sceneName));
	}

	public void LoadNextScene(string scene) {
		// TODO : Uncomment this line when we have more scenes
		// TODO : Key/value pairs matching names of states and scenes
		StartCoroutine (UnloadAndLoadScene (scene));

	}
}
