using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SoundManager.instance.playBGM ("game");
		GameManager.instance.ResetUI ();
		GameManager.instance.StartTick ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
