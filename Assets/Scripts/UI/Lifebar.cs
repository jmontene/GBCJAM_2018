using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lifebar : MonoBehaviour {
	Image bar;

	void Start(){
		bar = GetComponent<Image> ();
	}

	public void SetPerc(float p){
		bar.fillAmount = p;
	}
}
