using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Health : MonoBehaviour {


	public System.Collections.Generic.List<Image> HeartTank = new System.Collections.Generic.List<Image>(); //Lista com os coraçoes que aparecerao na HUD
	public Image HeartImage;

	private int  HeartNumber;
	private int HeartToAccess=0;
	public Vector3 HeartPos;// = new Vector3(124f,-90f,0f);
	public Vector3 HeartAddPos;
	public GameObject Hearts;
	//public int	HP;




	// Use this for initialization

	 
			


	void Start () {

		StartingHeartTank(6);

	}
	
	// Update is called once per frame
	void Update () {
		

			
	}
	public void StartingHeartTank(int MaxHealth){

		HeartNumber = MaxHealth / 2;

			for(int i=HeartToAccess; i<HeartNumber;i++){
				AddHeart();
			}

	}

	public void HeartUpdate(int NowHP, float Dano){   //Dano tem que ser 1 ou -1
		//Image Coracao;
		if ((NowHP+1)%2 == 1 && Dano < 0) {
			HeartToAccess +=1;
		}
	
		HeartTank [HeartToAccess].fillAmount -= Dano*0.5f;//GetComponentInChildren<Image>().fillAmount -= Dano*0.5f;
		//Coracao = HeartTank [HeartToAccess].transform.FindChild ("Heart");// -= Dano*0.5f;
		if((NowHP+1)%2 == 0 && Dano > 0){
			HeartToAccess-=1;
		}

	}

	void AddHeart (){
		Image HeartClone = (Image)Instantiate (HeartImage);
		HeartClone.transform.parent = Hearts.transform;
		HeartClone.rectTransform.anchoredPosition = HeartPos + HeartAddPos * HeartToAccess;
		//Instantiate (Heart);
		HeartTank.Add (HeartClone);
		//HeartTank [HeartToAccess].transform.parent = healthbar.transform;

		HeartToAccess++;

	}
}

