using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTT_Juego : MonoBehaviour {
	public Jugador yo;
	public Comunicador comunicador;
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
			comunicador = go.GetComponent<Comunicador>();
		}

		go = GameObject.Find("_yo");
		if(go && !yo){
			yo = go.GetComponent<Jugador>();
		}
	}

	public void emitirComunicado(string metodo, Dictionary<string, string> mensaje){
		comunicador.Emitir(metodo,mensaje);
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

	public void tirar(int fila, int coliumna){
		Dictionary<string, string> data = new Dictionary<string, string>();
		data["nom"] = "Tir";
		data["ses"] = yo.sesion.ToString();
		data["tok"] = yo.token.ToString();
		data["fil"] = fila.ToString();
		data["col"] = coliumna.ToString();
		emitirComunicado("movimiento", data);
	}

	public void actualizar(){
		Dictionary<string, string> data = new Dictionary<string, string>();
		data["nom"] = "Act";
		data["ses"] = yo.sesion.ToString();
		data["tok"] = yo.token.ToString();
		emitirComunicado("gestion", data);
	}

	public void Acceder(){
		Dictionary<string, string> data = new Dictionary<string, string>();
		data["nom"] = "Acc";
		data["ses"] = yo.sesion.ToString();
		data["tok"] = yo.token.ToString();
		data["nam"] = yo.nombre.ToString();
		emitirComunicado("acceder", data);
		
	}
}
