using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BestHTTP;
using BestHTTP.SocketIO;
using LitJson;

public class Comunicador_best : MonoBehaviour {
	public string servidor = "http://localhost:3000/socket.io/";
	public SocketManager manager;
	public ParametrosJuego parametrosJuego;
	public Gen_Juego gj; 

	void Awake(){
		Inicializar ();
	}

	public void Start () {
		manager.Open();
	}

	public bool estaActivo(){
		return manager.Socket.IsOpen;
	}
		
	public void EmitirRequest(string metodo,Dictionary<string, string> mensaje){
		Dictionary<string, object> data = new Dictionary<string, object>();
		data["request"] = mensaje;
		manager.Socket.Emit(metodo, data);
	}

	public void Emitir(string metodo,Dictionary<string, string> mensaje){
		manager.Socket.Emit(metodo, mensaje);
	}

	void OnServerConnect(Socket socket, Packet packet, params object[] args){
		Debug.Log("Conectado-" + socket.Id);
	}

	public void OnRespuesta(Socket socket, Packet packet, params object[] args){
		json js = new json ();
		List<object> list = js.Decode (packet.ToString ());
		gj.escucharRespuesta (list);
	}

	public void OnConnect(Socket socket, Packet packet, params object[] args){
		Dictionary<string, string> data = new Dictionary<string, string>();
		data["sesion"] = "Jhon";
		data["token"] = "secret";
		Emitir("authentication",data);
	}

	public void OnAuthenticated(Socket socket, Packet packet, params object[] args){
		Debug.Log ("OK conectadi"+packet.ToString());
	}
		
	void Inicializar(){
		GameObject go = GameObject.Find("_ParametrosJuego");
		if(go && !parametrosJuego){
			parametrosJuego = go.GetComponent<ParametrosJuego>();
			servidor = parametrosJuego.url;
		}
		gj = GameObject.Find("_juego").GetComponent<Gen_Juego>();

		SocketOptions options = new SocketOptions();
		options.AutoConnect = false;
		options.ReconnectionAttempts = 3;
		options.Reconnection = true;

		manager = new SocketManager(new Uri(servidor));

		manager.Socket.On(SocketIOEventTypes.Connect, OnServerConnect);
		manager.Socket.On("respuesta", OnRespuesta);
		manager.Socket.On("connect", OnConnect);
		manager.Socket.On("authenticated", OnAuthenticated);
	}
}

