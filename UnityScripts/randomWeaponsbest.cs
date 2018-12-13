using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class randomWeapons : MonoBehaviour 
{
	public string Class;
	public string weaponName;
	public string modName;
	public string modName2;
	public int DamageStat, Durability, SpeedStat, Cost;
	public bool UniqueType, ClassWeapon;
	public string myUniqueTypes;	
	string [] weaponTypes;
	string [] classTypes;
	string [] uniqueNames;
	string [] Modifier;
	string [] Modifier2;
	public GameObject weaponNameTextObj;
	public GameObject classText;
	public GameObject durabilityText;
	public GameObject speedText;
	public GameObject costText;
	public GameObject damageText;
	public GameObject modifierText;
	public GameObject modifier2Text;



	void Start () 
	{
		weaponTypes = new string[6];
		weaponTypes [0] = " Axe";
		weaponTypes [1] = " Sword";
		weaponTypes [2] = " Dagger";
		weaponTypes [3] = " Shield";
		weaponTypes [4] = " Mace";
		weaponTypes [5] = " Crossbow";

		classTypes = new string[4];
		classTypes [0] = " Barbarian";
		classTypes [1] = " Thief";
		classTypes [2] = " Paladin";
		classTypes [3] = "";

		uniqueNames = new string [6];
		uniqueNames [0] = " of Flame";
		uniqueNames [1] = " of Death";
		uniqueNames [2] = " of Despair";
		uniqueNames [3] = " of Sorrow";
		uniqueNames [4] = " of Lingering Anguish";
		uniqueNames [5] = " of Pain";

		Modifier = new string [10];
		Modifier [0] = "+1 to Strength";
		Modifier [1] = "+2 to Dexterity";
		Modifier [2] = "+3 to Durability";
		Modifier [3] = "+4 to Armour";
		Modifier [4] = "+5 to Dodge";
		Modifier [5] = "-1 to Cost";
		Modifier [6] = "-2 to Speed";
		Modifier [7] = "-3 to Health";
		Modifier [8] = "-4 to Experience";
		Modifier [9] = "-5 to Accuracy";

		Modifier2 = new string [10];
		Modifier2 [0] = "+1 to Strength";
		Modifier2 [1] = "+2 to Dexterity";
		Modifier2 [2] = "+3 to Durability";
		Modifier2 [3] = "+4 to Armour";
		Modifier2 [4] = "+5 to Dodge";
		Modifier2 [5] = "-1 to Cost";
		Modifier2 [6] = "-2 to Speed";
		Modifier2 [7] = "-3 to Health";
		Modifier2 [8] = "-4 to Experience";
		Modifier2 [9] = "-5 to Accuracy";




		GenerateWeapon();

	}

	public void GenerateWeapon(){
		int typeSelect = Random.Range (0,6);
		weaponName = weaponTypes[typeSelect];

		int classSelect = Random.Range (0,4);
		Class = classTypes[classSelect];

		int modSelect = Random.Range (0, 10);
		modName = Modifier[modSelect];

		int modSelect2 = Random.Range (0, 10);
		modName2 = Modifier2[modSelect2];





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

		if (weaponTypes [typeSelect] == " Axe") {
			DamageStat = Random.Range (50, 70);
			Cost = Random.Range (30, 50);
			SpeedStat = Random.Range (5, 20);
			Durability = Random.Range (20, 40);
			Class = classTypes[classSelect];
			modName = Modifier[modSelect];
			modName2 = Modifier2[modSelect2];

		} else if (weaponTypes [typeSelect] == " Sword") {
			DamageStat = Random.Range (30, 50);
			Cost = Random.Range (25, 40);
			SpeedStat = Random.Range (10, 30);
			Durability = Random.Range (20, 40);
			Class = classTypes[classSelect];
			modName = Modifier[modSelect];
			modName2 = Modifier2[modSelect2];
		} else if (weaponTypes [typeSelect] == " Dagger") {
			DamageStat = Random.Range (20, 40);
			Cost = Random.Range (5, 20);
			SpeedStat = Random.Range (20, 50);
			Durability = Random.Range (30, 40);
			Class = classTypes[classSelect];
			modName = Modifier[modSelect];
			modName2 = Modifier2[modSelect2];
		} else if (weaponTypes [typeSelect] == " Shield") {
			DamageStat = Random.Range (5, 10);
			Cost = Random.Range (30, 60);
			SpeedStat = Random.Range (0, 10);
			Durability = Random.Range (60, 80);
			Class = classTypes[classSelect];
			modName = Modifier[modSelect];
			modName2 = Modifier2[modSelect2];
		} else if (weaponTypes [typeSelect] == " Mace") {
			DamageStat = Random.Range (20, 30);
			Cost = Random.Range (20, 40);
			SpeedStat = Random.Range (30, 50);
			Durability = Random.Range (20, 50);
			Class = classTypes[classSelect];
			modName = Modifier[modSelect];
			modName2 = Modifier2[modSelect2];
		} else if (weaponTypes [typeSelect] == " Crossbow") {
			DamageStat = Random.Range (30, 45);
			Cost = Random.Range (30, 45);
			SpeedStat = Random.Range (30, 50);
			Durability = Random.Range (10, 30);
			Class = classTypes[classSelect];
			modName = Modifier[modSelect];
			modName2 = Modifier2[modSelect2];
		} 

		weaponNameTextObj.GetComponent<Text>().text = weaponName;
		classText.GetComponent<Text>().text = Class;
		damageText.GetComponent<Text>().text = DamageStat.ToString()+ " %Bonus Damage";
		costText.GetComponent<Text>().text = Cost.ToString()+ " Gold";
		durabilityText.GetComponent<Text>().text = Durability.ToString()+ " %Bonus Durability";	
		speedText.GetComponent<Text>().text = SpeedStat.ToString()+ " %Bonus Speed";
		modifierText.GetComponent<Text> ().text = modName; 
		modifier2Text.GetComponent<Text> ().text = modName2;
	}



}
