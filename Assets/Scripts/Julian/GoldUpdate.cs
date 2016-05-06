using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoldUpdate : MonoBehaviour {
    
    [SerializeField]
    private Text gold;
	
	// Update is called once per frame
	void Update () {
        gold.text = LevelManager.Money.ToString();
	}
}
