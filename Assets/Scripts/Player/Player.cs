using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, Actor {

	public float speed = 1f;

	Vector2 directionalInput;
	float dir = 1f;
	SpriteRenderer mainRenderer;

	void Start(){
		Init ();
	}

	void Update () {
		DoUpdate ();
	}

	public void Init(){
		mainRenderer = GetComponentInChildren<SpriteRenderer> ();
	}

	public void DoUpdate(){
		ProcessInput ();
		Move ();
	}

	void ProcessInput(){
		directionalInput = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
	}

	void Move(){
		if (directionalInput.x != 0 && Mathf.Sign (directionalInput.x) != dir) {
			mainRenderer.flipX = !mainRenderer.flipX;
			dir = -dir;
		}
		transform.Translate (Vector2.right * directionalInput.x * speed * Time.deltaTime);
	}

}
