using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowDino : FallingObject {

    private float walkSpeed;

    void Awake() {
        deathDelay = 0.5f;
        walkSpeed = Random.Range(1.0f, 7.0f);
        anim = GetComponent<Animator>();
    }

    void Update() { DoUpdate(); }

    public void DoUpdate() {
        if (isGrounded) transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
    }

    public override void Behave() {
        this.gameObject.tag = "Enemy";
    }

    void OnCollisionEnter2D(Collision2D other) {
        base.OnCollisionEnter2D(other);
        if (other.gameObject.tag == "Player") {
            isGrounded = false;
            if (anim != null) anim.SetTrigger("wasHurt");
            Destroy(this.gameObject, deathDelay);
        }
    }
}
