using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowDino : FallingObject {

    [SerializeField] private float walkSpeed;

    private float deathDelay;
    private Animator anim;

    void Awake() {
        deathDelay = 0.5f;
        anim = GetComponent<Animator>();
        InvokeRepeating("DebugGround", 0.0f, 3.0f);
    }
    void Update() { DoUpdate(); }

    public void DoUpdate() {
        if (isGrounded) transform.Translate(transform.forward * walkSpeed * Time.deltaTime);
    }

    public override void Behave() {
        this.gameObject.tag = "Enemy";
    }

    void DebugGround() { Debug.Log(isGrounded.ToString()); }
}
