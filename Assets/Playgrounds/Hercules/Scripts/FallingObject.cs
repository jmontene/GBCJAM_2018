using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour, Actor {

    [SerializeField] float fallingSpeed;

    public void DoUpdate () {
        transform.Translate(Vector3.down*fallingSpeed*Time.deltaTime);
	}

	public void Init(){
		
	}

    void OnCollisionEnter2D(Collision2D other) { Destroy(this.gameObject); }
}
