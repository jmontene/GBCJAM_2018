using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameManager.instance.ResetUI ();
		GameManager.instance.UpdateScore ();
	}
}
