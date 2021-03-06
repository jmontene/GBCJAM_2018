﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, Actor {

	public int maxLife = 100;
	public int lifeLoss = 10;
	public float blinkTime = 0.1f;
	public float groundedDistance = 0.01f;
	public float jumpForce = 1000f;
	public LayerMask groundLayer;

	public AudioClip hurtClip;

	[HideInInspector]
	public int life;
	public float speed = 1f;

	Vector2 directionalInput;
	float dir = 1f;
	SpriteRenderer mainRenderer;
	Animator mainAnim;
	Rigidbody2D rbody;
	bool grounded;
	Transform groundedTransform;
	bool blinking;
	bool control = true;

	void Start(){
		Init ();
	}

	void Update () {
		DoUpdate ();
	}

	public void Init(){
		mainRenderer = GetComponentInChildren<SpriteRenderer> ();
		mainAnim = GetComponentInChildren<Animator> ();
		life = maxLife;
		rbody = GetComponent<Rigidbody2D> ();
		grounded = false;
		groundedTransform = transform.Find ("GroundCheck");
		blinking = false;
	}

	public void DoUpdate(){
		if (control) {
			ProcessInput ();
			Move ();
		}
		CheckGrounded ();

		mainAnim.SetBool ("Grounded", grounded);
		mainAnim.SetFloat ("xSpeed", Mathf.Abs(directionalInput.x));
	}

	void ProcessInput(){
		directionalInput = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxis ("Vertical"));
		if (grounded && Input.GetButtonDown ("Jump")) {
			Jump ();
		}
	}

	void Move(){
		float effectiveXSpeed = directionalInput.x * speed * Time.deltaTime;

		if (directionalInput.x != 0 && Mathf.Sign (directionalInput.x) != dir) {
			mainRenderer.flipX = !mainRenderer.flipX;
			dir = -dir;
		}

		transform.Translate (Vector2.right * effectiveXSpeed);
	}

	void LoseLife(){
		life = Mathf.Clamp(life - lifeLoss, 0, maxLife);
		GameManager.instance.SetLife((float)life / (float)maxLife);

		if (life == 0) {
			control = false;
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Falling" || other.gameObject.tag == "Enemy") {
			SoundManager.instance.PlaySFX (hurtClip);
			StartCoroutine (Blink (blinkTime));
			LoseLife ();
		}
	}

	void Jump(){
		rbody.AddForce (Vector2.up * jumpForce);
	}

	void CheckGrounded(){
		if (Physics2D.Raycast (groundedTransform.position, Vector2.down, groundedDistance, groundLayer)) {
			grounded = true;
		} else {
			grounded = false;
		}
	}

	IEnumerator Blink(float seconds){
		if (blinking) {
			yield break;
		}
		blinking = true;
		Material old = mainRenderer.material;
		Material m = new Material (Shader.Find ("Mobile/Particles/Additive"));
		mainRenderer.material = m;
		yield return new WaitForSeconds (seconds);
		mainRenderer.material = old;
		blinking = false;
	}

}
