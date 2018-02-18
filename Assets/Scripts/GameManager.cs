using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
	public float fadeTime = 3f;

	GameUI ui;
	int score;
	float timer;
	bool gameOver;

	// Use this for initialization
	void Awake() {
		if (_instance == null) {
			_instance = this;
			DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}

		score = 0;
		gameOver = false;
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

	public float GetScore(){
		return score;
	}

	public void SetUIReference(GameUI g){
		ui = g;
	}

	public void UpdateScore(){
		ui.SetScore (score);
	}

	public void StartTick(){
		InvokeRepeating ("ScoreTick", timePerTick, timePerTick);
	}

	public void ResetUI(){
		ui = FindObjectOfType<GameUI> ();
	}

	public void FadeIn(float time){
		StartCoroutine(FadeInCo(time));
	}

	void ScoreTick(){
		AddScore (1);
	}

	void GameOver(){
		if (gameOver) {
			return;
		}

		gameOver = true;
		CancelInvoke ();
		SoundManager.instance.stopBGM ();
		StartCoroutine (FadeOutToGameOver (fadeTime));
	}

	IEnumerator FadeOutToGameOver(float time){
		Image fade = GameObject.Find ("Fade").GetComponent<Image> ();
		Color origColor = fade.color;
		Color targetColor = new Color (fade.color.r, fade.color.g, fade.color.b, 1f);
		float t = 0f;

		while (t < time) {
			t += Time.deltaTime;
			fade.color = Color.Lerp (origColor, targetColor, t / time);
			yield return null;
		}
		SceneManager.LoadScene (4);
	}

	IEnumerator FadeInCo(float time){
		Image fade = GameObject.Find ("Fade").GetComponent<Image> ();
		Color origColor = fade.color;
		Color targetColor = new Color (fade.color.r, fade.color.g, fade.color.b, 0f);
		float t = 0f;

		while (t < time) {
			t += Time.deltaTime;
			fade.color = Color.Lerp (origColor, targetColor, t / time);
			yield return null;
		}
	}
}
