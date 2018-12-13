using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class randomWeapons : MonoBehaviour 
{
	public string Class;
	public string weaponName;
	public int DamageStat, Durability, SpeedStat, Cost;
	public bool UniqueType, ClassWeapon;
	public string myUniqueTypes;	
	string [] weaponTypes;
	string [] classTypes;
	string [] uniqueNames;
	public GameObject weaponNameTextObj;
	public GameObject classText;
	public GameObject durabilityText;
	public GameObject speedText;
	public GameObject costText;
	public GameObject damageText;

	// Use this for initialization
	void Start () 
	{
		weaponTypes = new string[6];
		weaponTypes [0] = " Axe";
		weaponTypes [1] = " Sword";
		weaponTypes [2] = " Dagger";
		weaponTypes [3] = " Shield";
		weaponTypes [4] = " Mace";
		weaponTypes [5] = " Bow";

		classTypes = new string[3];
		classTypes [0] = " Barbarian";
		classTypes [1] = " Thief";
		classTypes [2] = " Paladin";

		uniqueNames = new string [6];
		uniqueNames [0] = " of Flame";
		uniqueNames [1] = " of Death";
		uniqueNames [2] = " of Despair";
		uniqueNames [3] = " of Sorrow";
		uniqueNames [4] = " of Lingering Anguish";
		uniqueNames [5] = " of Pain";

		GenerateWeapon();

	}

	public void GenerateWeapon(){
		int typeSelect = Random.Range (0,6);
		weaponName = weaponTypes[typeSelect];

		int classSelect = Random.Range (0,3);
		Class = classTypes[classSelect];



		if(Random.Range (0,2)==1){
			UniqueType = true;

		}else{
			UniqueType = false;


		}
		
		if (UniqueType){
			int uniqueSelect = Random.Range (0,6);
			myUniqueTypes = uniqueNames[uniqueSelect];

		}
		else{
			myUniqueTypes = "";
		}

		

		weaponName = weaponTypes[typeSelect] + myUniqueTypes;

		if(weaponTypes[typeSelect] == " Axe"){
			DamageStat = Random.Range(50,70);
			Cost = Random.Range(30,50);
			SpeedStat = Random.Range(5,20);
			Durability = Random.Range(20,40);
			Class = "Barbarian";
		}
		else if(weaponTypes[typeSelect] == " Sword"){
			DamageStat = Random.Range(30,50);
			Cost = Random.Range(25,40);
			SpeedStat = Random.Range(10,30);
			Durability = Random.Range(20,40);
			Class = "Barbarian";
		}
		else if(weaponTypes[typeSelect] == " Dagger"){
			DamageStat = Random.Range(20,40);
			Cost = Random.Range(5,20);
			SpeedStat = Random.Range(20,50);
			Durability = Random.Range(30,40);
			Class = "Thief";
		}
		else if(weaponTypes[typeSelect] == " Shield"){
			DamageStat = Random.Range(5,10);
			Cost = Random.Range(30,60);
			SpeedStat = Random.Range(0,10);
			Durability = Random.Range(60,80);
			Class = "Paladin";
		}
		else if(weaponTypes[typeSelect] == " Mace"){
			DamageStat = Random.Range(20,30);
			Cost = Random.Range(20,40);
			SpeedStat = Random.Range(30,50);
			Durability = Random.Range(20,50);
			Class = "Paladin";
		}
		else if(weaponTypes[typeSelect] == " Bow"){
			DamageStat = Random.Range(30,45);
			Cost = Random.Range(30,45);
			SpeedStat = Random.Range(30,50);
			Durability = Random.Range(10,30);
			Class = "Thief";
		}

	
		weaponNameTextObj.GetComponent<Text>().text = weaponName;
		classText.GetComponent<Text>().text = Class;
		damageText.GetComponent<Text>().text = DamageStat.ToString()+ " Damage";
		costText.GetComponent<Text>().text = Cost.ToString()+ " Cost";
		durabilityText.GetComponent<Text>().text = Durability.ToString()+ " Durability";	
		speedText.GetComponent<Text>().text = SpeedStat.ToString()+ " Speed";
	}


	// Update is called once per frame
	void Update () 
	{

	}
}
