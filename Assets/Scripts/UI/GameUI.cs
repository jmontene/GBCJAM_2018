using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour{

	Canvas canvas;
	Text scoreText;
	Lifebar lifebar;

	// Use this for initialization
	void Awake() {
		canvas = GetComponent<Canvas> ();
		scoreText = canvas.transform.Find("Score").GetComponent<Text> ();
		lifebar = GetComponentInChildren<Lifebar> ();
	}
	
	public void SetScore(int score, string prev = "sscore: "){
		scoreText.text = prev + score.ToString ();
	}

	public void SetLife(float perc){
		lifebar.SetPerc (perc);
	}
}
