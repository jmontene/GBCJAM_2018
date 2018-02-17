using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour, Actor {

    [SerializeField] GameObject[] spawned;
    [SerializeField] float updateTime;

	public void Init(){
        InvokeRepeating("SpawnFalls", 0.0f, updateTime);
	}

    void Start() { Init(); }

	public void DoUpdate(){
		
	}

    void SpawnFalls() {
        int index;
        if(Random.Range(0.0f, 1.0f) < 0.5f) index = 0;
        else index = 1;
        GameObject go = Instantiate(spawned[index], new Vector2(Random.Range(-5.0f, 5.0f), transform.position.y), transform.rotation) as GameObject;
    }
}
