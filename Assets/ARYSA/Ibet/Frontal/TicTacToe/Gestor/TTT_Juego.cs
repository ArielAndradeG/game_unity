using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class TTT_Juego : MonoBehaviour {
	public Comunicador comunicador;
	public bool esTurno;
	public string simbolo;
	public string[][] tablero;

	void Start () {
		GameObject go = GameObject.Find("_Comunicador");
		if(go && !comunicador){
			comunicador = go.GetComponent<Comunicador>();
		}
	}

	public void recibirAccion (SocketIOEvent ev){
		Debug.Log(ev.name);
	}

	public void tirar(int fila, int coliumna){
		Dictionary<string, string> data = new Dictionary<string, string>();
		data["nom"] = "Movimiento";
		data["fil"] = fila.ToString();
		data["col"] = coliumna.ToString();
		//Debug.Log (new JSONObject (data));
		comunicador.Emitir("hello", new JSONObject(data));
	}

	public void actualizar(){
		Dictionary<string, string> data = new Dictionary<string, string>();
		data["nom"] = "Actualizar";
		//Debug.Log (new JSONObject (data));
		comunicador.Emitir("hello", new JSONObject(data));
	}
}
