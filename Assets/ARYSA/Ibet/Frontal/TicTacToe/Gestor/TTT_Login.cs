using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TTT_Login : MonoBehaviour {
	public Text token;
	public Text nombre;
	public Text apuesta;
	public Text sesion;
	public Jugador jugador;
	public GameObject juego;

	void Start () {
		
	}

	public void Login () {
		jugador.token = token.text.ToString();
		jugador.nombre = nombre.text.ToString();
		jugador.sesion = sesion.text.ToString();
		jugador.apuesta = apuesta.text.ToString();

		this.gameObject.SetActive (false);
		juego.gameObject.SetActive (true);
	}
}
