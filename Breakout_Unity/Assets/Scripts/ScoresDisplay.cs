using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Displays the Highscores
 * Display gets activated by HighscoreStateBehaviour
 */
public class ScoresDisplay : MonoBehaviour {
    // canvas: Object to instantiate. parent: Clone's parent: Used for layout and to clean up board
    public GameObject canvas;
    public GameObject parent;

    HighScoreHandler handler;

    // Start only gets called once per object's lifetime. Using OnEnable because it's the one called when
    // object gets activated
    void OnEnable() {
        // clean previous scores, if any
        CleanPrevious ();
        // get handler instance to retrieve data from pq
        handler = GameObject.FindGameObjectWithTag ("GameController").GetComponent<HighScoreHandler> ();
        int size = handler.DisplayData.Length;
        // instantiate score object and set text 
        for (int i = 0; i < size; ++i) {
            GameObject temp = Instantiate (canvas);
            temp.transform.SetParent (parent.transform, false);
            temp.transform.GetChild (0).gameObject.GetComponent<Text> ().text = (i +1) + ".";
            temp.transform.GetChild (1).gameObject.GetComponent<Text> ().text = handler.DisplayData [i].name;
            temp.transform.GetChild (2).gameObject.GetComponent<Text> ().text = (handler.DisplayData [i].score).ToString();
        }
        handler.SaveData ();
    }

    void CleanPrevious() {
        int children = parent.transform.childCount;
        for(int i = 0; i < children; ++i) {
            Destroy (parent.transform.GetChild (i).gameObject);
        }
    }

}
