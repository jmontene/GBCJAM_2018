using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FallingObject : MonoBehaviour, Actor {

    public int fallingDamage = 5;
    public int groundedDamage;

    protected float deathDelay;
    protected bool isGrounded;

    void Awake() { deathDelay = 0.5f; }

    public void Init() { }
    public void DoUpdate () { }
    
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground") {
            isGrounded = true;
            Behave();
        }
        if (other.gameObject.tag == "Player") {
            isGrounded = false;
            Behave();
        }
        if (other.gameObject.tag == "Death") Destroy(this.gameObject);
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Falling") Physics2D.IgnoreCollision(this.gameObject.GetComponent<Collider2D>(), other.gameObject.GetComponent<Collider2D>(), true);
    }

    public abstract void Behave();
}
