using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroDino : MonoBehaviour {
    
    [SerializeField] private int sceneToLoad;

    private Animator textAnim;
    private AudioSource aud;
    private float speed;
    private float sceneDuration = 5.0f;

    void Awake(){
        textAnim = GameObject.Find("SplashText").GetComponent<Animator>();
        speed = 10.0f;
        Invoke("Transition", sceneDuration);
    }

    void Update() {
        transform.Translate(Vector2.right*speed*Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) {
        textAnim.SetTrigger("knockedAway");
    }
    
    void Transition(){ SceneManager.LoadScene(sceneToLoad); }
}
