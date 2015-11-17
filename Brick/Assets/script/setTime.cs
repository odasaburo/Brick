using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class setTime : MonoBehaviour {

    public Sprite[] numbers;
    public GameObject[] timeimages;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void timeset(int settime)
    {
        int min = settime / 60;
        int sec = settime % 60;

        timeimages[0].GetComponent<Image>().sprite = numbers[(sec % 10)]; // sec 1
        timeimages[1].GetComponent<Image>().sprite = numbers[(sec / 10)]; // sec 2
        timeimages[2].GetComponent<Image>().sprite = numbers[(min % 10)]; // min 1
        timeimages[3].GetComponent<Image>().sprite = numbers[(min / 10)]; // min 2
    }
}
