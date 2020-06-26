using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTT_Juego : MonoBehaviour,Gen_Juego {
	public Jugador yo;
	public Comunicador_best comunicador;
	public string turno;
	public string ganador;
	public string simbolo;
	public string[][] tablero = new string[][]{
		new string[] {".",".","."},
		new string[] {".",".","."},
		new string[] {".",".","."}
	};

	void Start () {
		GameObject go = GameObject.Find("_Comunicador");
		if(go && !comunicador){
			comunicador = go.GetComponent<Comunicador_best>();
		}

		go = GameObject.Find("_yo");
		if(go && !yo){
			yo = go.GetComponent<Jugador>();
		}
	}

	public void emitirRequest(string metodo, Dictionary<string, string> mensaje){
		comunicador.EmitirRequest(metodo,mensaje);
	}	

	public void recibirRespuesta(string ev){
		Debug.Log(ev);
		//en la respuesta de seteo de ficha
		//tablero[renglon][columna] = valor;
	}

	public void recibirGestion(string ev){
		Debug.Log(ev);
		//en la respuesta de actaulizar
		//for->tablero[renglon][columna] = valor

		//en la respuesta de loguear
		//for->tablero[renglon][columna] = valor
	}

	public void reiniciarTablero(){
		tablero = new string[][]{
			new string[] {".",".","."},
			new string[] {".",".","."},
			new string[] {".",".","."}
		};
		reconectar ();
	}

	public void tirar(int fila, int coliumna){
		Dictionary<string, string> data = new Dictionary<string, string>();
		data["accion"] = "Tirar";
		data["sesion"] = yo.sesion.ToString();
		data["token"] = yo.token.ToString();
		data["fil"] = fila.ToString();
		data["col"] = coliumna.ToString();
		emitirRequest("movimiento", data);
	}

	public void actualizar(){
		Dictionary<string, string> data = new Dictionary<string, string>();
		data["accion"] = "Actualizar";
		data["sesion"] = yo.sesion.ToString();
		data["token"] = yo.token.ToString();
		emitirRequest("gestion", data);
	}

	public void acceder(){
		Dictionary<string, string> data = new Dictionary<string, string>();
		data["accion"] = "Acceder";
		data["sesion"] = yo.sesion.ToString();
		data["token"] = yo.token.ToString();
		data["nombre"] = yo.nombre.ToString();
		emitirRequest("gestion", data);
	}

	public bool esConexionActiva(){
		return comunicador.estaActivo ();
	}

	public void reconectar(){
		comunicador.Start ();
		acceder ();
		actualizar ();
	}

	public void escucharRespuesta(List<object> respuesta){
		foreach (object str in respuesta) {
			//Debug.Log (str.ToString());
		}
		JSONObject jo = new JSONObject ();
		Debug.Log ("nueva--"+respuesta);
	}
}
