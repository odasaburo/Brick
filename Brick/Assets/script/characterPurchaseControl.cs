using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class characterPurchaseControl : MonoBehaviour {

    public GameObject[] characters;
    public Sprite[] characteractiveimages;
    public Sprite[] characterinactiveimages;
    public GameObject[] prices;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void purchase(int[] characterpurchase)
    {
        for(int i = 0; i < characterpurchase.Length; i++)
        {
            if (characterpurchase[i] == 1)
            {
                characters[i].GetComponent<Image>().sprite = characteractiveimages[i];
                prices[i].SetActive(false);

            } else if(characterpurchase[i] == 0)
            {
                characters[i].GetComponent<Image>().sprite = characterinactiveimages[i];
                prices[i].SetActive(true);
            }
        }
    }
}
