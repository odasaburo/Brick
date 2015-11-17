using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Maincontrol : MonoBehaviour {

    public GameObject mainmenu;
    public GameObject pausemenu;
    public GameObject characterselect;
    public GameObject levelselect;
    public GameObject gameover;
    public GameObject gamewin;
    public GameObject[] levels;
    public GameObject changeCharacter;
    public GameObject gameoverDetect;
    public Sprite[] numbers;
    public GameObject[] point;
    public Sprite[] background;
    public GameObject gameplay;

    public GameObject ball;
    public GameObject cloud;
    public GameObject sun;
    public GameObject player;

    GameObject clone_ball;
    GameObject clone_player;
    GameObject clone_sun;
    GameObject[] cloneball2 = new GameObject[2];

    public int gameLevel;
    public bool gamestart_flag = false;
    public int gameState = 0;// 0 :mainmenu, 1:levelselectmenu, 2: umblellas select menu, 3:playing game, 4:pause state, 5:game Over, 6: game win.
    public int destroy_count;
    public int created_count;
    public float leveltime = 0;
    public int[] character_purchaseState = { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0};
    public int lives = 1;
    public int game_score;
    public int[] levelrecodedTime = { 0,0,0,0,0,0,0,0,0,0,0,0};
    public int[] characterprice = { 0, 0, 100, 150, 200, 200, 250, 250, 300, 300 };
    public Vector2 destroy_pos;
    public bool createspecial_flag = false;

    // Use this for initialization
    void Start() {
        mainmenu.SetActive(true);
        created_count = 0;
        destroy_count = 0;
        //LoadLevel(gameLevel);
        GetComponent<setTime>().timeset(0);
        
        //saveData();
        //saveCharacterState();
        loadData();
        loadCharacterState();
        setPoint(game_score);
        setleveltime();
        purchaseCharacter();
    }
	
	// Update is called once per frame
	void Update () {
        switch (gameState)
        {
            case 0: //main menu
                break;
            case 1: //level select menu
                break;
            case 2: // umbrella select menu
                break;
            case 3: // playing game
                setPoint(game_score);
                GetComponent<setTime>().timeset(0);
                if (!gamestart_flag)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        leveltime = 0;
                        GetComponent<setTime>().timeset((int)leveltime);
                        clone_ball.GetComponentInChildren<ballcontrol>().setSpeed(400f);
                        gamestart_flag = true;
                    }
                } else
                {
                    leveltime += Time.deltaTime;
                    GetComponent<setTime>().timeset((int)leveltime);
                    destroy_count = created_count - GameObject.FindGameObjectsWithTag("cloud").Length;
                    if(destroy_count%(30-gameLevel) == (gameLevel))
                    {
                        if (createspecial_flag)
                        {
                            Debug.Log(destroy_pos);
                            int spec = Random.Range(0, 6);
                           
                            GetComponent<specialPower>().createSpecial(destroy_pos, spec);
                            createspecial_flag = false;
                        }
                    } else
                    {
                         createspecial_flag = true;
                    }
                }

                if(created_count != 0 && destroy_count >= created_count)
                {
                    gameState = 6;
                    destroy_count = 0;
                    gamestart_flag = false;
                    Debug.Log("Game Win");
                    levelrecodedTime[gameLevel - 1] = (int)leveltime;
                    saveData();
                }

                if (gameoverDetect.GetComponent<gameOverDetect>().gameoverflag)
                {
                    if (GameObject.FindGameObjectsWithTag("ball").Length < 1)
                    {
                        lives--;


                        gamestart_flag = false;
                        gameoverDetect.GetComponent<gameOverDetect>().gameoverflag = false;
                        if (lives > 0)
                        {
                            clone_ball.GetComponentInChildren<ballcontrol>().setPosition(GameObject.FindGameObjectWithTag("player").GetComponent<Transform>().position.x, Screen.height * 0.15f);
                            clone_ball.GetComponentInChildren<ballcontrol>().setSpeed(0);

                        }
                        else if (lives <= 0)
                        {
                            GameOver();
                            setleveltime();

                        }
                    }
                }
                
                break;
            case 4: // pause
                break;
            case 5: // gameOver
                break;
            case 6: //gameWin
                saveData();
                GameWin();
                setleveltime();
                
                break;
        }
    }

    public void LevelSelectMenu()
    {
        
    }
    public void setLevel(int level)
    {
        purchaseCharacter();
        gameLevel = level;
        setleveltime();
    }

    public void LoadLevel(int level)
    {

        //clone_sun = Instantiate(sun);
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
                created_count = 37;
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
                created_count = 30;
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
                created_count = 52;
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
                created_count = 64;
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
                created_count = 57;
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
                created_count = 56;
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
                created_count = 75;
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
                created_count = 44;
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
                created_count = 31;
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
                created_count = 54;
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
                created_count = 56;
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
                created_count = 51;
                break;
        }

        clone_ball = Instantiate(ball);
        clone_ball.GetComponentInChildren<ballcontrol>().setPosition(Screen.width /2, Screen.height * 0.15f);

        clone_player = Instantiate(player);
        clone_player.GetComponentInChildren<playerControl>().setposition(Screen.width / 2);

        gameState = 3;

    }

    public void Pause()
    {
        gameState = 4;
        Time.timeScale = 0;
    }
    public void Resume()
    {
        gameState = 3;
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        gameplay.GetComponent<Image>().sprite = background[12];
        gameState = 0;
        gamestart_flag = false;
        GameObject[] clone_cloud = GameObject.FindGameObjectsWithTag("cloud");
        for (int i = 0; i < clone_cloud.Length; i++)
        {
            Destroy(clone_cloud[i]);
        }

        GameObject[] cloneballs = GameObject.FindGameObjectsWithTag("ball");
        for(int i =0;i< cloneballs.Length; i++)
        {
            Destroy(cloneballs[i]);
        }
        GameObject[] specials = GameObject.FindGameObjectsWithTag("special");
        for (int i = 0; i < specials.Length; i++)
        {
            Destroy(specials[i]);
        }
        Destroy(clone_ball);
        Destroy(clone_player);
        Destroy(clone_sun);
        Time.timeScale = 1;
        setPoint(game_score);
    }

    public void GameOver()
    {
        gameplay.GetComponent<Image>().sprite = background[14];
        Debug.Log("gameover");
        for (int i = 0; i < cloneball2.Length; i++)
        {
            Destroy(cloneball2[i]);
        }
        Destroy(clone_ball);
        Destroy(clone_player);
        Destroy(clone_sun);
        gamestart_flag = false;
        GameObject[] clone_cloud = GameObject.FindGameObjectsWithTag("cloud");
        GameObject[] cloneballs = GameObject.FindGameObjectsWithTag("ball");
        for (int i = 0; i < cloneballs.Length; i++)
        {
            Destroy(cloneballs[i]);
        }
        GameObject[] specials = GameObject.FindGameObjectsWithTag("special");
        for (int i = 0; i < specials.Length; i++)
        {
            Destroy(specials[i]);
        }
        lives = 1;
        destroy_count = 0;
        gameover.SetActive(true);
        gameState = 5;
    }

    public void CharacterMenu(int id)
    {
 
        if (character_purchaseState[id] == 1)
        {
            LoadLevel(gameLevel);
            gameState = 3;
            clone_player.GetComponentInChildren<playerControl>().setimage(id);
            characterselect.SetActive(false);
        }
        else
        {
            if (game_score >= characterprice[id]) // point
            {
                game_score -= characterprice[id];
                Debug.Log(game_score);
                character_purchaseState[id] = 1;
                saveCharacterState();
                setPoint(game_score);
                purchaseCharacter();
            }
            else
            {

            }
        }
    }

    public void characterchange(int id)
    {
        gameplay.GetComponent<Image>().sprite = background[14];
        if (character_purchaseState[id] == 1)
        {
            clone_player.GetComponentInChildren<playerControl>().setimage(id);
            changeCharacter.SetActive(false);
            Resume();
        }
        else
        {
            if( game_score>= characterprice[id]) // point
            {
                game_score -= characterprice[id];
                Debug.Log(game_score);
                character_purchaseState[id] = 1;
                saveCharacterState();
                setPoint(game_score);
                purchaseCharacter();
            }
            else
            {

            }
        }
    }

    public void restart()
    {
        gameplay.GetComponent<Image>().sprite = background[gameLevel];
        gamestart_flag = false;
        GameObject[] clone_cloud = GameObject.FindGameObjectsWithTag("cloud");
        for(int i = 0; i < clone_cloud.Length; i++)
        {
            Destroy(clone_cloud[i]);
        }
        GameObject[] cloneballs = GameObject.FindGameObjectsWithTag("ball");
        for (int i = 0; i < cloneballs.Length; i++)
        {
            Destroy(cloneballs[i]);
        }
        GameObject[] specials = GameObject.FindGameObjectsWithTag("special");
        for (int i = 0; i < specials.Length; i++)
        {
            Destroy(specials[i]);
        }
        Destroy(clone_ball);
        Destroy(clone_player);
        Destroy(clone_sun);
        
        Time.timeScale = 1;
        LoadLevel(gameLevel);
        gameState = 3;
        
    }

    public void AudioOnOff()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
        }
        else if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
        }
    }

    public void GameWin()
    {
        gameplay.GetComponent<Image>().sprite = background[14];
        GameObject[] cloneballs = GameObject.FindGameObjectsWithTag("ball");
        for (int i = 0; i < cloneballs.Length; i++)
        {
            Destroy(cloneballs[i]);
        }
        GameObject[] specials = GameObject.FindGameObjectsWithTag("special");
        for (int i = 0; i < specials.Length; i++)
        {
            Destroy(specials[i]);
        }
        Destroy(clone_sun);
        Destroy(clone_ball);
        Destroy(clone_player);
        gamewin.SetActive(true);
        gameState = 7;
    }

    public void nextLevel()
    {
        setleveltime();
        if (gameLevel < 12)
        {
            //lives++;
            setPoint(game_score);
            gameLevel++;
            gameplay.GetComponent<Image>().sprite = background[gameLevel];
            gamewin.SetActive(false);
            restart();

        }
    }

    public void setPoint(int score)
    {
        int score1 = score / 1000;
        int score2 = (score % 1000) / 100;
        int score3 = ((score % 1000) % 100) / 10;
        int score4 = ((score % 1000) % 100) % 10;
        point[0].GetComponent<Image>().sprite = numbers[score1];
        point[1].GetComponent<Image>().sprite = numbers[score2];
        point[2].GetComponent<Image>().sprite = numbers[score3];
        point[3].GetComponent<Image>().sprite = numbers[score4];
    }

    public void setleveltime()
    {
        for (int i = 0; i < 12; i++)
        {
            GetComponent<levelsettime>().leveltime(i + 1, levelrecodedTime[i]);
        }
    }


    public void saveData()
    {
        PlayerPrefs.SetInt("gamescore", game_score);
        PlayerPrefs.SetInt("recordedtimelevel1", levelrecodedTime[0]);
        PlayerPrefs.SetInt("recordedtimelevel2", levelrecodedTime[1]);
        PlayerPrefs.SetInt("recordedtimelevel3", levelrecodedTime[2]);
        PlayerPrefs.SetInt("recordedtimelevel4", levelrecodedTime[3]);
        PlayerPrefs.SetInt("recordedtimelevel5", levelrecodedTime[4]);
        PlayerPrefs.SetInt("recordedtimelevel6", levelrecodedTime[5]);
        PlayerPrefs.SetInt("recordedtimelevel7", levelrecodedTime[6]);
        PlayerPrefs.SetInt("recordedtimelevel8", levelrecodedTime[7]);
        PlayerPrefs.SetInt("recordedtimelevel9", levelrecodedTime[8]);
        PlayerPrefs.SetInt("recordedtimelevel10", levelrecodedTime[9]);
        PlayerPrefs.SetInt("recordedtimelevel11", levelrecodedTime[10]);
        PlayerPrefs.SetInt("recordedtimelevel12", levelrecodedTime[11]);
    }

    public void saveCharacterState()
    {
        PlayerPrefs.SetInt("character_purchase1", character_purchaseState[0]);
        PlayerPrefs.SetInt("character_purchase2", character_purchaseState[1]);
        PlayerPrefs.SetInt("character_purchase3", character_purchaseState[2]);
        PlayerPrefs.SetInt("character_purchase4", character_purchaseState[3]);
        PlayerPrefs.SetInt("character_purchase5", character_purchaseState[4]);
        PlayerPrefs.SetInt("character_purchase6", character_purchaseState[5]);
        PlayerPrefs.SetInt("character_purchase7", character_purchaseState[6]);
        PlayerPrefs.SetInt("character_purchase8", character_purchaseState[7]);
        PlayerPrefs.SetInt("character_purchase9", character_purchaseState[8]);
        PlayerPrefs.SetInt("character_purchase10", character_purchaseState[9]);
    }

    public void loadData()
    {
        game_score = PlayerPrefs.GetInt("gamescore");

        levelrecodedTime[0] = PlayerPrefs.GetInt("recordedtimelevel1");
        levelrecodedTime[1] = PlayerPrefs.GetInt("recordedtimelevel2");
        levelrecodedTime[2] = PlayerPrefs.GetInt("recordedtimelevel3");
        levelrecodedTime[3] = PlayerPrefs.GetInt("recordedtimelevel4");
        levelrecodedTime[4] = PlayerPrefs.GetInt("recordedtimelevel5");
        levelrecodedTime[5] = PlayerPrefs.GetInt("recordedtimelevel6");
        levelrecodedTime[6] = PlayerPrefs.GetInt("recordedtimelevel7");
        levelrecodedTime[7] = PlayerPrefs.GetInt("recordedtimelevel8");
        levelrecodedTime[8] = PlayerPrefs.GetInt("recordedtimelevel9");
        levelrecodedTime[9] = PlayerPrefs.GetInt("recordedtimelevel10");
        levelrecodedTime[10] = PlayerPrefs.GetInt("recordedtimelevel11");
        levelrecodedTime[11] = PlayerPrefs.GetInt("recordedtimelevel12");
    }

    public void loadCharacterState()
    {
        character_purchaseState[0] = PlayerPrefs.GetInt("character_purchase1");
        character_purchaseState[1] = PlayerPrefs.GetInt("character_purchase2");
        character_purchaseState[2] = PlayerPrefs.GetInt("character_purchase3");
        character_purchaseState[3] = PlayerPrefs.GetInt("character_purchase4");
        character_purchaseState[4] = PlayerPrefs.GetInt("character_purchase5");
        character_purchaseState[5] = PlayerPrefs.GetInt("character_purchase6");
        character_purchaseState[6] = PlayerPrefs.GetInt("character_purchase7");
        character_purchaseState[7] = PlayerPrefs.GetInt("character_purchase8");
        character_purchaseState[8] = PlayerPrefs.GetInt("character_purchase9");
        character_purchaseState[9] = PlayerPrefs.GetInt("character_purchase10");
    }

    public void purchaseCharacter()
    {
        GetComponent<characterPurchaseControl>().purchase(character_purchaseState);
        changeCharacter.GetComponent<characterPurchaseControl>().purchase(character_purchaseState);
    }

    public void cloneball(int count)
    {
        for (int i = 0; i < count; i++)
        {
            
            cloneball2[i] = Instantiate(ball);
            cloneball2[i].GetComponentInChildren<ballcontrol>().setPosition(GameObject.FindGameObjectWithTag("ball").GetComponentInChildren<ballcontrol>().current_pos.x, GameObject.FindGameObjectWithTag("ball").GetComponentInChildren<ballcontrol>().current_pos.y);
            cloneball2[i].GetComponentInChildren<ballcontrol>().setSpeed(Random.Range(300,600));
        }

    }
}
