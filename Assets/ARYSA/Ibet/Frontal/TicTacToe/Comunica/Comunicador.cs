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

		socket.On("foreignMessage", OnForeignMessage);
		socket.On("open", OnSocketOpen);
	}

	public void Emitir(string metodo,Dictionary<string, string> mensaje){
		JSONObject json = new JSONObject (mensaje);
		socket.Emit(metodo, json);
	}

	public void Emitir(string metodo,JSONObject json){
		socket.Emit(metodo, json);
	}
		
	public void OnSocketOpen(SocketIOEvent ev){
		Debug.Log("updated socket id " + socket.sid);
	}

	public void OnForeignMessage(SocketIOEvent ev){
		Debug.Log(string.Format("[ansewer: {0}]", ev.data));
	}
}
