using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	static GameManager _instance;
	public static GameManager instance{
		get{
			if (_instance == null) {
				_instance = GameObject.FindObjectOfType<GameManager> ();
				if (_instance == null) {
					GameObject obj = new GameObject ("GameManager");
					_instance = obj.AddComponent<GameManager> ();
				}
			}
			return _instance;
		}
	}

	public float timePerTick = 0.5f;

	GameUI ui;
	int score;
	float timer;

	// Use this for initialization
	void Awake() {
		if (_instance == null) {
			_instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}

		score = 0;
		ui = FindObjectOfType<GameUI> ();

		InvokeRepeating ("ScoreTick", timePerTick, timePerTick);
	}
	
	public void AddScore(int add){
		score += add;
		ui.SetScore (score);
	}

	public void SetLife(float perc){
		ui.SetLife (perc);
		if (perc == 0f) {
			GameOver ();
		}
	}

	void ScoreTick(){
		AddScore (1);
	}

	void GameOver(){
		CancelInvoke ();
	}
}
