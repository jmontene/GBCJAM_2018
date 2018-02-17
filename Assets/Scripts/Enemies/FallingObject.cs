using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FallingObject : MonoBehaviour, Actor {

    public int fallingDamage = 5;
    public int groundedDamage;

    protected bool isGrounded;

    public void Init() { }
    public void DoUpdate () { }
    
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Ground") {
            isGrounded = true;
            Behave();
        }
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Death") Destroy(this.gameObject);
    }

    public abstract void Behave();
}
