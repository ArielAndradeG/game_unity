﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour {
	public string id;
	public string alias;
	public string nombre;
	public string apuesta;
	public string sesion;
	public string token;
	public ParametrosJuego parametrosJuego;

	void Start () {
		Inicializar ();
	}

	void Inicializar(){
		GameObject go = GameObject.Find("_ParametrosJuego");
		if(go && !parametrosJuego){
			parametrosJuego = go.GetComponent<ParametrosJuego>();
		}
		this.token = parametrosJuego.token;
	}
}
