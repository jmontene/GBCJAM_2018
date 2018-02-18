using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScene : MonoBehaviour {

	public float fadeTime = 3f;

	// Use this for initialization
	void Start () {
		GameManager.instance.FadeIn (fadeTime);
		GameManager.instance.ResetUI ();
		GameManager.instance.UpdateScore ();
	}
}
