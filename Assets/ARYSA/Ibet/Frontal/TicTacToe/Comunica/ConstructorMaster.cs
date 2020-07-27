using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConstructorMaster : MonoBehaviour {
	public ParametrosJuego parametrosJuego;

	void Awake () {
		Inicializar ();
		Iniciar ();
	}

	void Iniciar(){
		Type tipo = Type.GetType (parametrosJuego.tipoJuego);
		GameObject.Find("_juego").AddComponent(tipo);
	}

	void Inicializar(){
		GameObject go = GameObject.Find("_ParametrosJuego");
		if(go && !parametrosJuego){
			parametrosJuego = go.GetComponent<ParametrosJuego>();
		}
	}
}
