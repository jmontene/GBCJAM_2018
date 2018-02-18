using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScene : MonoBehaviour {

	public float fadeTime = 3f;
	public AudioClip gameOverSound;

	// Use this for initialization
	void Start () {
		SoundManager.instance.PlaySFX (gameOverSound);
		GameManager.instance.FadeIn (fadeTime);
		GameManager.instance.ResetUI ();
		GameManager.instance.UpdateScore ();
	}
}
