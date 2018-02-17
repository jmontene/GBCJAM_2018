using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour, Actor {

    [SerializeField] float fallingSpeed;
    [SerializeField] float deathDelayTime;
    private Animator anim;

    void Awake(){
        anim = GetComponent<Animator>();
    }

    public void DoUpdate () {
        transform.Translate(Vector3.down*fallingSpeed*Time.deltaTime);
	}

	public void Init(){
		
	}

    void OnCollisionEnter2D(Collision2D other) {
        if (anim!=null) anim.SetTrigger("wasHurt");
        Destroy(this.gameObject, deathDelayTime);
    }
}
