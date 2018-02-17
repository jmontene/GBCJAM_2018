using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour, Actor {

    [SerializeField] GameObject[] spawned;
    [SerializeField] float updateTime;
    private float playerX = 0; //temporary

    private bool flipSpawn;

	public void Init(){ InvokeRepeating("SpawnFalls", 0.0f, updateTime); }

    void Start() { Init(); }

	public void DoUpdate(){ }

    void SpawnFalls() {
        //float temp = GameObject.Find("Player").transform.position.x;
        //playerX = (temp!=null) ? temp : 0.0f;
        int index;
        if(Random.Range(0.0f, 1.0f) < 0.7f) index = 0;
        else index = 1;
        //created a vector2 to store the location separately
        Vector2 newSpawn = new Vector2(Random.Range(-5.0f, 5.0f), transform.position.y);
        //the Instantiate reads the vector and rotates the object towards the center of the screen... Can refine later...
        GameObject go = Instantiate(spawned[index], newSpawn, ((newSpawn.x >= playerX) ? Quaternion.AngleAxis(180, Vector3.up) : transform.rotation)) as GameObject;
    }
}
