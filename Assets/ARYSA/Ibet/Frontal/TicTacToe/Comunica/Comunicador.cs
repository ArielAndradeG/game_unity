using System.Collections;
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
	}

	public void Emitir(string metodo,Dictionary<string, string> mensaje){
		JSONObject json = new JSONObject (mensaje);
		socket.Emit(metodo, json);
	}

	public void Emitir(string metodo,JSONObject json){
		socket.Emit(metodo, json);
	}
		
	public void OnAcceso(SocketIOEvent ev){
		juego.recibirGestion (ev);
	}

	public void OnGestion(SocketIOEvent ev){
		juego.recibirGestion (ev);
	}

	public void OnRespuesta(SocketIOEvent ev){
		juego.recibirRespuesta (ev);
	}
}
