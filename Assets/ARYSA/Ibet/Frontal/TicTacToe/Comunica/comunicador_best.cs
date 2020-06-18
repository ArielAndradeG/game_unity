using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BestHTTP;
using BestHTTP.SocketIO;

public class Comunicador_best : MonoBehaviour {
	public SocketManager manager;
	void Start () {
		manager = new SocketManager(new Uri("https://socket-io-chat.now.sh/socket.io/"));
	}
}
