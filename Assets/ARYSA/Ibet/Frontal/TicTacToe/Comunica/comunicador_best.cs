using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BestHTTP;
using BestHTTP.SocketIO;
using LitJson;

public class Comunicador_best : MonoBehaviour {
	public string servidor = "http://localhost:3000/socket.io/";
	public string ruta = "/";
	public SocketManager manager;
	public GameObject juego;
	public Gen_Juego gj; 

	void Awake(){
		SocketOptions options = new SocketOptions();
		options.AutoConnect = false;
		options.ReconnectionAttempts = 3;
		options.Reconnection = true;

		manager = new SocketManager(new Uri(servidor));//Socket root = manager.Socket;
		Socket nsp = manager.GetSocket(ruta);

		manager.Socket.On(SocketIOEventTypes.Connect, OnServerConnect);
		manager.Socket.On("respuesta", OnRespuesta);
	}

	public void Start () {
		gj = GameObject.Find("_juego").GetComponent<Gen_Juego>();
		manager.Open();
	}

	public bool estaActivo(){
		return manager.Socket.IsOpen;
	}
		
	public void AccesoTest(){
		Dictionary<string, object> arg = new Dictionary<string, object>();
		arg.Add("ses", "sesion1");
		arg.Add("tok", "token1");
		manager.Socket.Emit("authenticate", arg);
	}

	public void EmitirRequest(string metodo,Dictionary<string, string> mensaje){
		Dictionary<string, object> data = new Dictionary<string, object>();
		data["request"] = mensaje;
		manager.Socket.Emit(metodo, data);
	}

	void OnServerConnect(Socket socket, Packet packet, params object[] args){
		Debug.Log("Conectado-" + socket.Id);
	}

	public void OnRespuesta(Socket socket, Packet packet, params object[] args){
		json js = new json ();
		List<object> list = js.Decode (packet.ToString ());
		gj.escucharRespuesta (list);
	}
}

