using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowDino : FallingObject {

    private float walkSpeed;
    private float deathDelay;
    private Animator anim;

    void Awake() {
        walkSpeed = Random.Range(1.0f, 7.0f);
        deathDelay = 0.5f;
        anim = GetComponent<Animator>();
    }

    void Update() { DoUpdate(); }

    public void DoUpdate() {
        if (isGrounded) transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);
    }

    public override void Behave() {
        this.gameObject.tag = "Enemy";
    }
}
