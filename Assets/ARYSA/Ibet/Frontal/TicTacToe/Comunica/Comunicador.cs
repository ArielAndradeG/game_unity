﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class Comunicador : MonoBehaviour {
	public SocketIOComponent socket;
	public TTT_Juego juego;
	// Use this for initialization
	void Awake () {
		GameObject go = GameObject.Find("_Socket");
		if(go && !socket){
			socket = go.GetComponent<SocketIOComponent>();
		}

		go = GameObject.Find ("_TicTacToe");
		if(go && !juego){
			juego = go.GetComponent<TTT_Juego>();
		}

		socket.On("respuesta", OnRespuesta);
		socket.On("gestion", OnGestion);
		socket.On("acceso", OnAcceso);
		socket.On("aviso", OnAviso);
	}

	public void Emitir(string metodo,Dictionary<string, string> mensaje){
		JSONObject json = new JSONObject (mensaje);
		//Debug.Log (new JSONObject (data));
		socket.Emit(metodo, json);
	}
		
	public void OnAviso(SocketIOEvent ev){
		Debug.Log("error");
		//juego.recibirRespuesta (string.parse(ev.data));
	}
	public void OnAcceso(SocketIOEvent ev){
		//juego.recibirGestion (ev.data.toString());
	}

	public void OnGestion(SocketIOEvent ev){
		//juego.recibirGestion (ev.data.toString());
	}

	public void OnRespuesta(SocketIOEvent ev){
		//juego.recibirRespuesta (ev.data.toString());
	}
}
