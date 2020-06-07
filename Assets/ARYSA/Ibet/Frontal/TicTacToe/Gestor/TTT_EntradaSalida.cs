using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTT_EntradaSalida : MonoBehaviour {
	public TTT_Juego juego;

	void Start () {
		if(!juego){
			juego = this.GetComponent<TTT_Juego>();
		}
	}

	public void Tirar(string fila_coliumna){
		string[] valores = fila_coliumna.Split(',');
		int renglon = int.Parse(valores[0]);
		int columna = int.Parse(valores[1]);
		juego.tirar(renglon,columna);
	}

	public void Actualizar(){
		juego.actualizar();
	}

	public void RedibujarComponentes(){
		
	}

	public void Agregar(){

	}
}
