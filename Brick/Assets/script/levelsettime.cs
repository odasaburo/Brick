using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class levelsettime : MonoBehaviour {

    public GameObject[] level1;
    public GameObject[] level2;
    public GameObject[] level3;
    public GameObject[] level4;
    public GameObject[] level5;
    public GameObject[] level6;
    public GameObject[] level7;
    public GameObject[] level8;
    public GameObject[] level9;
    public GameObject[] level10;
    public GameObject[] level11;
    public GameObject[] level12;

    public Sprite[] numbers;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void leveltime(int level, int time)
    {
        
        switch (level)
        {
            case 1:
                int sec1 = time % 60;
                int min1 = time / 60;
                level1[0].GetComponent<Image>().sprite = numbers[sec1 % 10];
                level1[1].GetComponent<Image>().sprite = numbers[sec1 / 10];
                level1[2].GetComponent<Image>().sprite = numbers[min1 % 10];
                level1[3].GetComponent<Image>().sprite = numbers[min1 / 10];
                break;
            case 2:
                int sec2 = time % 60;
                int min2 = time / 60;
                level2[0].GetComponent<Image>().sprite = numbers[sec2 % 10];
                level2[1].GetComponent<Image>().sprite = numbers[sec2 / 10];
                level2[2].GetComponent<Image>().sprite = numbers[min2 % 10];
                level2[3].GetComponent<Image>().sprite = numbers[min2 / 10];
                break;
            case 3:
                int sec3 = time % 60;
                int min3 = time / 60;
                level3[0].GetComponent<Image>().sprite = numbers[sec3 % 10];
                level3[1].GetComponent<Image>().sprite = numbers[sec3 / 10];
                level3[2].GetComponent<Image>().sprite = numbers[min3 % 10];
                level3[3].GetComponent<Image>().sprite = numbers[min3 / 10];
                break;
            case 4:
                int sec4 = time % 60;
                int min4 = time / 60;
                level4[0].GetComponent<Image>().sprite = numbers[sec4 % 10];
                level4[1].GetComponent<Image>().sprite = numbers[sec4 / 10];
                level4[2].GetComponent<Image>().sprite = numbers[min4 % 10];
                level4[3].GetComponent<Image>().sprite = numbers[min4 / 10];
                break;
            case 5:
                int sec5 = time % 60;
                int min5 = time / 60;
                level5[0].GetComponent<Image>().sprite = numbers[sec5 % 10];
                level5[1].GetComponent<Image>().sprite = numbers[sec5 / 10];
                level5[2].GetComponent<Image>().sprite = numbers[min5 % 10];
                level5[3].GetComponent<Image>().sprite = numbers[min5 / 10];
                break;
            case 6:
                int sec6 = time % 60;
                int min6 = time / 60;
                level6[0].GetComponent<Image>().sprite = numbers[sec6 % 10];
                level6[1].GetComponent<Image>().sprite = numbers[sec6 / 10];
                level6[2].GetComponent<Image>().sprite = numbers[min6 % 10];
                level6[3].GetComponent<Image>().sprite = numbers[min6 / 10];
                break;
            case 7:
                int sec7 = time % 60;
                int min7 = time / 60;
                level7[0].GetComponent<Image>().sprite = numbers[sec7 % 10];
                level7[1].GetComponent<Image>().sprite = numbers[sec7 / 10];
                level7[2].GetComponent<Image>().sprite = numbers[min7 % 10];
                level7[3].GetComponent<Image>().sprite = numbers[min7 / 10];
                break;
            case 8:
                int sec8 = time % 60;
                int min8 = time / 60;
                level8[0].GetComponent<Image>().sprite = numbers[sec8 % 10];
                level8[1].GetComponent<Image>().sprite = numbers[sec8 / 10];
                level8[2].GetComponent<Image>().sprite = numbers[min8 % 10];
                level8[3].GetComponent<Image>().sprite = numbers[min8 / 10];
                break;
            case 9:
                int sec9 = time % 60;
                int min9 = time / 60;
                level9[0].GetComponent<Image>().sprite = numbers[sec9 % 10];
                level9[1].GetComponent<Image>().sprite = numbers[sec9 / 10];
                level9[2].GetComponent<Image>().sprite = numbers[min9 % 10];
                level9[3].GetComponent<Image>().sprite = numbers[min9 / 10];
                break;
            case 10:
                int sec10 = time % 60;
                int min10 = time / 60;
                level10[0].GetComponent<Image>().sprite = numbers[sec10 % 10];
                level10[1].GetComponent<Image>().sprite = numbers[sec10 / 10];
                level10[2].GetComponent<Image>().sprite = numbers[min10 % 10];
                level10[3].GetComponent<Image>().sprite = numbers[min10 / 10];
                break;
            case 11:
                int sec11 = time % 60;
                int min11 = time / 60;
                level11[0].GetComponent<Image>().sprite = numbers[sec11 % 10];
                level11[1].GetComponent<Image>().sprite = numbers[sec11 / 10];
                level11[2].GetComponent<Image>().sprite = numbers[min11 % 10];
                level11[3].GetComponent<Image>().sprite = numbers[min11 / 10];
                break;
            case 12:
                int sec12 = time % 60;
                int min12 = time / 60;
                level12[0].GetComponent<Image>().sprite = numbers[sec12 % 10];
                level12[1].GetComponent<Image>().sprite = numbers[sec12 / 10];
                level12[2].GetComponent<Image>().sprite = numbers[min12 % 10];
                level12[3].GetComponent<Image>().sprite = numbers[min12 / 10];
                break;
        }
    }
}
