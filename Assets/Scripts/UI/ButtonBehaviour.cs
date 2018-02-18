using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour {

    [SerializeField] private int sceneToLoad;

    public void DoSceneChange() { SceneManager.LoadScene(sceneToLoad); }
}
