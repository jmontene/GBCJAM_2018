using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SoundManager.instance.playBGM ("title");
	}
}
