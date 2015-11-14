using UnityEngine;
using System.Collections;

public class Maincontrol : MonoBehaviour {

    public GameObject mainmenu;
    public GameObject pausemenu;
    public GameObject characterselect;
    public GameObject levelselect;
    public GameObject gameover;
    public GameObject gamewin;
    public GameObject[] levels;

    public GameObject ball;
    public GameObject cloud;
    public GameObject sun;
    public GameObject player;

    GameObject clone_ball;
    GameObject clone_player;

    public int gameLevel;
	// Use this for initialization
	void Start () {
        // mainmenu.SetActive(true);
        LoadLevel(gameLevel);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void LevelSelectMenu()
    {

    }
    public void LoadLevel(int level)
    {

        Instantiate(sun);
        switch (level)
        {
            case 1:
                for (int i = 1; i <= 37; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    if (i <= 7)
                    {
                        cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * i / 10, Screen.height * 0.8f);
                    } else if( i > 7 && i <= 15)
                    {
                        cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 14f + Screen.width * (i-7) / 10, Screen.height * 0.75f);
                    } else if( i > 15 && i <= 22)
                    {
                        cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * (i-15) / 10, Screen.height * 0.7f);
                    } else if( i > 22 && i <= 30)
                    {
                        cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 14f + Screen.width * (i - 22) / 10, Screen.height * 0.65f);
                    } else if( i > 30)
                    {
                        cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * (i - 30) / 10, Screen.height * 0.6f);
                    }
                }
                break;
            case 2:
                for(int i = 1; i <= 30; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    if(i <= 5)
                    {
                        cloud_element.GetComponentInChildren<cloudcontrol>().setPosition( Screen.width / 5 + Screen.width / 2 * ((i+1) % 2), Screen.height * 0.96f -  Screen.width * ((i-1)* 3/14f));
                    } else if (i > 5 && i <= 10)
                    {
                        cloud_element.GetComponentInChildren<cloudcontrol>().setPosition( -Screen.width/22 + Screen.width / 5 + Screen.width / 2 * ((i-4) % 2), Screen.height * 0.96f - Screen.width/14f - Screen.width * ((i-6) * 3 / 14f));
                    } else if(i > 10 && i <= 15)
                    {
                        cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 22 + Screen.width / 5 + Screen.width / 2 * ((i-9) % 2), Screen.height * 0.96f - Screen.width / 14f - Screen.width * ((i-11) * 3 / 14f));
                    } else if(i > 15 && i <= 20)
                    {
                        cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(-Screen.width / 11 + Screen.width / 5 + Screen.width / 2 * ((i-14) % 2), Screen.height * 0.96f - Screen.width / 7f - Screen.width * ((i-16) * 3 / 14f));
                    } else if (i > 20 && i<=25)
                    {
                        cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 11 + Screen.width / 5 + Screen.width / 2 * ((i-19) % 2), Screen.height * 0.96f - Screen.width / 7f - Screen.width * ((i-21) * 3 / 14f));
                    } else if (i > 25)
                    {
                        cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 5 + Screen.width / 2 * ((i-24) % 2), Screen.height * 0.96f - Screen.width / 7f - Screen.width * ((i - 26) * 3 / 14f));
                    }
                }
                break;
            case 3:
                for (int i = 1; i<=52; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    if (i <= 15)
                    {
                        cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 10 + Screen.width * i / 20, Screen.height * 0.98f - Screen.width * i/ 14f);
                    } else if(i>15 && i <= 30)
                    {
                        cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 10 + Screen.width * (i - 15) / 20, Screen.height * 0.98f - Screen.width * (31-i) / 14f);
                    }
                    else if(i>30 && i <= 36)
                    {
                        cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 10 + Screen.width * (i - 30) / 20, Screen.height * 0.98f - Screen.width * (i-28) / 14f);
                    } else if(i>36 && i <= 42)
                    {
                        cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 10 + Screen.width * (52 - i) / 20, Screen.height * 0.98f - Screen.width * (i-34) / 14f);
                    } else if( i>42 && i <= 47)
                    {
                        cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 10 + Screen.width * (i - 32) / 20, Screen.height * 0.98f - Screen.width * (i - 34) / 14f);
                    }
                    else if (i > 47)
                    {
                        cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 10 + Screen.width * (53 - i) / 20, Screen.height * 0.98f - Screen.width * ( i - 39) / 14f);
                    }
                }
                break;
            case 4:
                for(int i=1; i <= 16; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 5f + Screen.width * (Mathf.Pow(-1,i)) / 34f, Screen.height * 0.98f - Screen.width * i / 15f);
                }
                for (int i = 1; i <= 16; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width  *2 / 5f + Screen.width * (Mathf.Pow(-1, i)) / 34f, Screen.height * 0.98f - Screen.width * i / 15f);
                }
                for (int i = 1; i <= 16; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width  * 3 / 5f + Screen.width * (Mathf.Pow(-1, i)) / 34f, Screen.height * 0.98f - Screen.width * i / 15f);
                }
                for (int i = 1; i <= 16; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width * 4 / 5f + Screen.width * (Mathf.Pow(-1, i)) / 34f, Screen.height * 0.98f - Screen.width * i / 15f);
                }
                break;
            case 5:
                for(int i = 1; i <= 8; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 14f + Screen.width * i / 10, Screen.height * 0.65f);
                }
                for (int i = 1; i <= 9; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 42f + Screen.width * i / 10, Screen.height * 0.65f - Screen.width/15);
                }
                for (int i = 1; i <= 8; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 14f + Screen.width * i / 10, Screen.height * 0.65f - 2* Screen.width / 15);
                }
                for(int i = 1; i <= 3; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 42f + Screen.width * (3+i) / 10, Screen.height * 0.65f + Screen.width / 15);
                }
                for (int i = 1; i <= 3; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 42f + Screen.width * (3 + i) / 10, Screen.height * 0.65f + 3 * Screen.width / 15);
                }
                for (int i = 1; i <= 3; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 42f + Screen.width * (3 + i) / 10, Screen.height * 0.65f + 5 * Screen.width / 15);
                }
                for (int i = 1; i <= 3; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 42f + Screen.width * (3 + i) / 10, Screen.height * 0.65f - 3 * Screen.width / 15);
                }
                for (int i = 1; i <= 3; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 42f + Screen.width * (3 + i) / 10, Screen.height * 0.65f - 5 * Screen.width / 15);
                }
                for (int i = 1; i <= 3; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 42f + Screen.width * (3 + i) / 10, Screen.height * 0.65f - 7 * Screen.width / 15);
                }

                for (int i = 1; i <= 2; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 14f + Screen.width * (3 + i) / 10, Screen.height * 0.65f + 2 * Screen.width / 15);
                }
                for (int i = 1; i <= 2; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 14f + Screen.width * (3 + i) / 10, Screen.height * 0.65f + 4 * Screen.width / 15);
                }
                for (int i = 1; i <= 2; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 14f + Screen.width * (3 + i) / 10, Screen.height * 0.65f + 6 * Screen.width / 15);
                }
                for (int i = 1; i <= 2; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 14f + Screen.width * (3 + i) / 10, Screen.height * 0.65f + 2 * Screen.width / 15);
                }
                for (int i = 1; i <= 2; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 14f + Screen.width * (3 + i) / 10, Screen.height * 0.65f - 4 * Screen.width / 15);
                }
                for (int i = 1; i <= 2; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 14f + Screen.width * (3 + i) / 10, Screen.height * 0.65f - 6 * Screen.width / 15);
                }
                for (int i = 1; i <= 2; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 14f + Screen.width * (3 + i) / 10, Screen.height * 0.65f - 8 * Screen.width / 15);
                }
                break;
            case 6:
                for (int i = 1; i <= 7; i++)
                {
                    GameObject cloud_element = Instantiate(cloud); ;
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * i / 10, Screen.height * 0.98f - Screen.width / 15f);
                }
                for (int i = 1; i <= 7; i++)
                {
                    GameObject cloud_element = Instantiate(cloud); ;
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * i / 10, Screen.height * 0.98f - Screen.width * 3 / 15f);
                }
                for (int i = 1; i <= 7; i++)
                {
                    GameObject cloud_element = Instantiate(cloud); ;
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * i / 10, Screen.height * 0.98f - Screen.width * 5 / 15f);
                }
                for (int i = 1; i <= 7; i++)
                {
                    GameObject cloud_element = Instantiate(cloud); ;
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * i / 10, Screen.height * 0.98f - Screen.width * 7 / 15f);
                }
                for (int i = 1; i <= 7; i++)
                {
                    GameObject cloud_element = Instantiate(cloud); ;
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * i / 10, Screen.height * 0.98f - Screen.width * 9 / 15f);
                }
                for (int i = 1; i <= 7; i++)
                {
                    GameObject cloud_element = Instantiate(cloud); ;
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * i / 10, Screen.height * 0.98f - Screen.width * 11 / 15f);
                }
                for (int i = 1; i <= 7; i++)
                {
                    GameObject cloud_element = Instantiate(cloud); ;
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * i / 10, Screen.height * 0.98f - Screen.width * 13 / 15f);
                }
                for (int i = 1; i <= 7; i++)
                {
                    GameObject cloud_element = Instantiate(cloud); ;
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * i / 10, Screen.height * 0.98f - Screen.width * 15 / 15f);
                }
                break;
            case 7:
                for (int i = 1; i <= 7; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 7f + Screen.width * (i-1) / 10, Screen.height * 0.9f);
                }
                for (int i = 1; i <= 8; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width /14f + Screen.width * (i-1) / 10, Screen.height * 0.9f - Screen.width/15f);
                }

                for (int i = 1; i <= 7; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 14f + Screen.width * (i + 1) / 10, Screen.height * 0.9f - 3* Screen.width / 15f);
                }
                for (int i = 1; i <= 8; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 28f + Screen.width * (i + 1) / 10, Screen.height * 0.9f - 4*Screen.width / 15f);
                }

                for (int i = 1; i <= 7; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 7f + Screen.width * (i - 1) / 10, Screen.height * 0.9f - 6*Screen.width/15f);
                }
                for (int i = 1; i <= 8; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 14f + Screen.width * (i - 1) / 10, Screen.height * 0.9f -7* Screen.width / 15f);
                }

                for (int i = 1; i <= 7; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 14f + Screen.width * (i + 1) / 10, Screen.height * 0.9f - 9 * Screen.width / 15f);
                }
                for (int i = 1; i <= 8; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 28f + Screen.width * (i + 1) / 10, Screen.height * 0.9f - 10 * Screen.width / 15f);
                }

                for (int i = 1; i <= 7; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 7f + Screen.width * (i - 1) / 10, Screen.height * 0.9f - 12 * Screen.width / 15f);
                }
                for (int i = 1; i <= 8; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 14f + Screen.width * (i - 1) / 10, Screen.height * 0.9f - 13 * Screen.width / 15f);
                }
                break;
            case 8:
                for (int i = 1; i <= 7; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * i / 10, Screen.height * 0.9f );
                }
                for (int i = 1; i <= 9; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width * 1f/ 5f + Screen.width * (Mathf.Pow(-1, i)) / 34f, Screen.height * 0.9f - Screen.width * i / 15f);
                }
                for (int i = 1; i <= 7; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * i / 10, Screen.height * 0.9f - Screen.width * 10 / 15f);
                }
                for (int i = 1; i <= 9; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width * 73f / 90f + Screen.width * (Mathf.Pow(-1, i)) / 34f, Screen.height * 0.9f - Screen.width * i / 15f);
                }

                for (int i = 1; i <= 3; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * 4 / 10 - Screen.width *(i-1)/28f, Screen.height * 0.9f - Screen.width * (i+1) / 15f);
                }
                for (int i = 1; i <= 3; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * 4 / 10 - Screen.width * (4-i) / 28f, Screen.height * 0.9f - Screen.width * (i + 4) / 15f);
                }
                for (int i = 1; i <= 3; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * 4 / 10 + Screen.width * (i-1) / 28f, Screen.height * 0.9f - Screen.width * (9-i) / 15f);
                }
                for (int i = 1; i <= 3; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * 4 / 10 + Screen.width * i / 28f, Screen.height * 0.9f - Screen.width * (i + 2) / 15f);
                }
                break;
            case 9:
                for(int i = 1; i <= 3;i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * i*2 / 10 , Screen.height * 0.9f);
                }
                for (int i = 1; i <= 4; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * (i * 2 - 1)  / 10, Screen.height * 0.9f - Screen.width * 1.5f / 15f);
                }
                for (int i = 1; i <= 3; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * i * 2 / 10, Screen.height * 0.9f - Screen.width * 3/15f);
                }
                for (int i = 1; i <= 4; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * (i * 2 - 1) / 10, Screen.height * 0.9f - Screen.width * 4.5f / 15f);
                }
                for (int i = 1; i <= 3; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * i * 2 / 10, Screen.height * 0.9f - Screen.width * 6 / 15f);
                }
                for (int i = 1; i <= 4; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * (i * 2 - 1) / 10, Screen.height * 0.9f - Screen.width * 7.5f / 15f);
                }
                for (int i = 1; i <= 3; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * i * 2 / 10, Screen.height * 0.9f - Screen.width * 9 / 15f);
                }
                for (int i = 1; i <= 4; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * (i * 2 - 1) / 10, Screen.height * 0.9f - Screen.width * 10.5f / 15f);
                }
                for (int i = 1; i <= 3; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * i * 2 / 10, Screen.height * 0.9f - Screen.width * 12 / 15f);
                }
                break;
            case 10:
                for(int i = 1; i <= 11; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width / 10 + Screen.width * i / 22f, Screen.height * 0.96f - Screen.width *i / 15f);
                }
                for (int i = 1; i <= 10; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width / 10 + Screen.width * (i-1) / 22f, Screen.height * 0.96f - Screen.width * (i+1) / 15f);
                }
                for (int i = 1; i <= 10; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width *3/ 10 + Screen.width * (i - 1) / 22f, Screen.height * 0.96f - Screen.width * i / 15f);
                }
                for (int i = 1; i <= 8; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * 4 / 10 + Screen.width * (i - 1) / 22f, Screen.height * 0.96f - Screen.width * i / 15f);
                }
                for (int i = 1; i <= 4; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * 6 / 10 + Screen.width * (i - 1) / 22f, Screen.height * 0.96f - Screen.width * i / 15f);
                }
                for (int i = 1; i <= 3; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * 7 / 10 + Screen.width * (i - 1) / 22f, Screen.height * 0.96f - Screen.width * i / 15f);
                }
                for (int i = 1; i <= 5; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width / 10 + Screen.width * i / 22f, Screen.height * 0.96f - Screen.width * (i + 6) / 15f);
                }
                for (int i = 1; i <= 4; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width / 10 + Screen.width * (i-1) / 22f, Screen.height * 0.96f - Screen.width * (i + 7) / 15f);
                }
                break;
            case 11:
                for(int i = 1; i <= 8; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * i / 22, Screen.height * 0.6f + Screen.width * i/15);
                }
                for (int i = 1; i <= 8; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * (i+1) / 22, Screen.height * 0.6f + Screen.width * (i-1) / 15);
                }
                for (int i = 1; i <= 8; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * (i + 2) / 22, Screen.height * 0.6f + Screen.width * (i - 2) / 15);
                }
                for (int i = 1; i <= 8; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * (i + 3) / 22, Screen.height * 0.6f + Screen.width * (i - 3) / 15);
                }
                for (int i = 1; i <= 8; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * (i + 4) / 22, Screen.height * 0.6f + Screen.width * (i - 4) / 15);
                }
                for (int i = 1; i <= 8; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * (i + 5) / 22, Screen.height * 0.6f + Screen.width * (i - 5) / 15);
                }
                for (int i = 1; i <= 8; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * (i + 6) / 22, Screen.height * 0.6f + Screen.width * (i - 6) / 15);
                }
                for (int i = 1; i <= 8; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * (i + 7) / 22, Screen.height * 0.6f + Screen.width * (i - 7) / 15);
                }
                break;
            case 12:
                for(int i = 1; i <= 7; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * i / 10, Screen.height * 0.9f);
                }
                for (int i = 1; i <= 8; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 14f + Screen.width * i / 10, Screen.height * 0.9f - Screen.width /15f);
                }
                for (int i = 1; i <= 7; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * i / 10, Screen.height * 0.9f - Screen.width * 2 / 15f);
                }
                for (int i = 1; i <= 2; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 14f + Screen.width * (i+3) / 10, Screen.height * 0.9f - Screen.width * 6 / 15f);
                }
                for (int i = 1; i <= 2; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 14f + Screen.width * (i+3) / 10, Screen.height * 0.9f - Screen.width * 8/ 15f);
                }
                for (int i = 1; i <= 3; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * (i+2) / 10, Screen.height * 0.9f - Screen.width * 7 / 15f);
                }
                for (int i = 1; i <= 8; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 14f + Screen.width * i / 10, Screen.height * 0.9f - Screen.width * 13 / 15f);
                }
                for (int i = 1; i <= 7; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 9f + Screen.width * i / 10, Screen.height * 0.9f - Screen.width * 14 / 15f);
                }
                for (int i = 1; i <= 8; i++)
                {
                    GameObject cloud_element = Instantiate(cloud);
                    cloud_element.GetComponentInChildren<cloudcontrol>().setPosition(Screen.width / 14f + Screen.width * i / 10, Screen.height * 0.9f - Screen.width );
                }
                break;
        }

        clone_ball = Instantiate(ball);
        clone_ball.GetComponentInChildren<ballcontrol>().setPosition(Screen.width /2, Screen.height * 0.2f);

        clone_player = Instantiate(player);
        clone_player.GetComponentInChildren<playerControl>().setposition(Screen.width / 2);

    }

    public void PauseMenu()
    {

    }

    public void MainMenu()
    {

    }

    public void GameOver()
    {

    }

    public void CharacterMenu()
    {

    }

    public void AudioOnOff()
    {

    }

    public void GameWin()
    {

    }
}
