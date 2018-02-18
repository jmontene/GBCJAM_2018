using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems; // for Mouse Event handlers on Canvas

public class ButtonBehaviour : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    [SerializeField] private int sceneToLoad;

    private GameObject sprite;

    void Awake() { sprite = transform.Find("IconSelect").gameObject; }

    void Start() { sprite.SetActive(false); }

    void IPointerEnterHandler.OnPointerEnter(PointerEventData d) { if (sprite != null) sprite.SetActive(true); }

    void IPointerExitHandler.OnPointerExit(PointerEventData d) { if (sprite != null) sprite.SetActive(false); }

    public void DoSceneChange() { SceneManager.LoadScene(sceneToLoad); }

    public void QuitApp() { Application.Quit(); }
}
