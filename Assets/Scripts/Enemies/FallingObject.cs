using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FallingObject : MonoBehaviour, Actor {

    public int fallingDamage = 5;
    public int groundedDamage;

    protected float deathDelay;
    protected bool isGrounded;
    protected Animator anim;

    void Awake() { deathDelay = 0.5f; }

    public void Init() { }
    public void DoUpdate () { }
    
    protected void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Player") {
            isGrounded = true;
            Behave();
        }
        if (other.gameObject.tag == "Death") Destroy(this.gameObject);
    }

    public abstract void Behave();
}
