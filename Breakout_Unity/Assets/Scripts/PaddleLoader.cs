using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleLoader : MonoBehaviour {

	public Paddle paddle;
	// Use this for initialization
	void Start () {
		Instantiate (paddle, new Vector2 (0, -4), Quaternion.identity);
	}

}
