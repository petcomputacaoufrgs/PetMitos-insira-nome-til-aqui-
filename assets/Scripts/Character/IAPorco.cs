using UnityEngine;
using System.Collections;

public class IAPorco : MonoBehaviour {

	public Vector3 posicaoAtual;
	public float vel;
	public Vector3 scale;
	public float distance_esq;
	public float distance_dir;
	public float distance_aux;
	public GameObject jogador;

	// Use this for initialization
	void Start () {
		posicaoAtual = transform.position;
		scale = transform.localScale;
		vel = 3.0f;
		jogador = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if (CheckCloseToTag (5))
			transform.position = Vector3.MoveTowards (transform.position, jogador.transform.position, vel * Time.deltaTime);
		else {

			if ((transform.position.x > posicaoAtual.x - distance_esq) && transform.localScale.x > 0) {
				transform.Translate (-vel * Time.deltaTime, 0, 0);
			} else if (transform.position.x <= posicaoAtual.x - distance_esq && transform.localScale.x > 0) {
				Flip ();
			} else if (transform.position.x >= posicaoAtual.x + distance_dir && transform.localScale.x < 0) {
				Flip ();
			} else if ((transform.position.x >= posicaoAtual.x - distance_esq - distance_aux) && transform.localScale.x < 0) {
				transform.Translate (vel * Time.deltaTime, 0, 0);
			}
		}
	}

	void Flip(){
		scale.x *= -1;
		transform.localScale = scale;
	}

	bool CheckCloseToTag(float minimumDistance)
	{
		if (Vector3.Distance(transform.position, jogador.transform.position) <= minimumDistance)
				return true;
		
		return false;
	}

}


