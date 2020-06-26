using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TTT_EntradaSalida : MonoBehaviour {
	public TTT_Juego juego;
	public Text[] bloques;
	public bool esActiva = false;

	void Start () {
		if(!juego){
			juego = this.GetComponent<TTT_Juego>();
		}
	}

	void Update(){
		if (esActiva) {
			RedibujarComponentes ();
		}
	}

	public void Tirar(string fila_coliumna){
		string[] valores = fila_coliumna.Split(',');
		int renglon = int.Parse(valores[0]);
		int columna = int.Parse(valores[1]);
		if(juego.tablero[renglon][columna] == "."){
			juego.tirar(renglon,columna);
			setHueco(renglon,columna);
		}
	}

	public void Acceder(){
		juego.acceder ();
	}

	public void Actualizar(){
		juego.actualizar();
	}

	public void RedibujarComponentes(){
		foreach(Text text in bloques){
			string[] valores = text.name.Split(',');
			int renglon = int.Parse(valores[1]);
			int columna = int.Parse(valores[2]);
			text.text = juego.tablero[renglon][columna];
		}
	}

	public void reiniciarComponetes(){
		juego.reiniciarTablero ();
	}

	public void setHueco(int renglon, int columna){
		juego.tablero[renglon][columna]= "x";
	}
}
