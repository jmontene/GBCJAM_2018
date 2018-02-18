using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems; // for Mouse Event handlers on Canvas

public class ButtonBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    [SerializeField] private int sceneToLoad;

    private GameObject sprite;
    private GameObject sprite2;

    void Awake() { 
        sprite = transform.Find("IconSelect").gameObject;
        sprite2 = transform.Find("IconSelect2").gameObject;
    }

    void Start() { 
        sprite.SetActive(false);
        if (sprite2 != null) sprite2.SetActive(false);
    }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData d) { 
        if (sprite != null) sprite.SetActive(true);
        if (sprite2 != null) sprite2.SetActive(true);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData d) {
        if (sprite != null) sprite.SetActive(false);
        if (sprite2 != null) sprite2.SetActive(false);
    }

    public void DoSceneChange() { SceneManager.LoadScene(sceneToLoad); }

    public void QuitApp() { Application.Quit(); }
}
