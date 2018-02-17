using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour, Actor {

    [SerializeField] GameObject spawned;
    [SerializeField] float updateTime;

	public void Init(){
        InvokeRepeating("SpawnFalls", 0.0f, updateTime);
	}

    void Start() { Init(); }

	public void DoUpdate(){
		
	}

    void SpawnFalls() {
        GameObject go = Instantiate(spawned, new Vector2(Random.Range(-5.0f, 5.0f), transform.position.y), transform.rotation) as GameObject;
    }
}
