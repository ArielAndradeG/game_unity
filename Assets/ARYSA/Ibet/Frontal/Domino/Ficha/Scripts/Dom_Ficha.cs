using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dom_Ficha : MonoBehaviour {

	public int valorSup = 0;
	public int valorInf = 0;
	public SpriteRenderer superior;
	public SpriteRenderer inferior;
	public Sprite[] sprites;

	void Start(){
		RefrescarFicha ();
	}

	void RefrescarFicha () {
		if(valorSup <sprites.Length)
			superior.sprite = sprites [valorSup];
		if(valorInf <sprites.Length)
			inferior.sprite = sprites [valorInf];
	}
}
