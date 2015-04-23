using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Health : MonoBehaviour {


	//public System.Collections.Generic.List<Image> HeartTank = new System.Collections.Generic.List<Image>(); //Lista com os coraçoes que aparecerao na HUD
	Image[] HeartTank = new Image[6];
	public Image HeartImage;

	private int  HeartNumber;
	private int HeartToAccess=-1;
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

		for(int i=0; i<HeartNumber;i++){
				HeartToAccess ++;
				AddHeart();

			}

	}

	public void HeartUpdate(int NowHP, bool isdamage){   //Dano tem que ser 1 ou -1
		//Image Coracao;
	/*	if ((NowHP+1)%2 == 1 && Dano < 0) {
			HeartToAccess +=1;
		}*/
		GameObject Heartchild = HeartTank [HeartToAccess].transform.GetChild(0).gameObject;	//Pega o coraçao que e filho do contorno dele
		if(isdamage){


			Heartchild.GetComponent<Image>().fillAmount-=0.5f;
			if((NowHP)%2 == 0 ){
				HeartToAccess--;
				}
		}
		else{
			if((NowHP)%2 == 1 ){
				HeartToAccess++;
			}
			Heartchild.GetComponent<Image>().fillAmount+=0.5f;
		}

	}

	void AddHeart (){
		Image HeartClone = (Image)Instantiate (HeartImage);
		HeartClone.transform.SetParent(Hearts.transform,false);
		//HeartClone.transform.parent = Hearts.transform;
		HeartClone.rectTransform.anchoredPosition = HeartPos + HeartAddPos * HeartToAccess;
		//Instantiate (Heart);
		HeartTank[HeartToAccess] = HeartClone;
		//HeartTank.Add (HeartClone);
		//HeartTank [HeartToAccess].transform.parent = healthbar.transform;



	}
}

