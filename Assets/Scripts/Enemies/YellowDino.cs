using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowDino : FallingObject {

    private float deathDelay;
    private Animator anim;

    void Awake() {
        deathDelay = 0.5f;
        anim = GetComponent<Animator>();
    }

    public override void Behave() {
        this.gameObject.tag = "Enemy";
        if (anim != null) anim.SetTrigger("wasHurt");
    }
}
