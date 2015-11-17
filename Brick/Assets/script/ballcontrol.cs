using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class ballcontrol : MonoBehaviour {

    public Rigidbody2D rigibody;
    public CircleCollider2D circlecollider;
    public int special_state;
    public bool special_flag;
    public GameObject lighting;
    public Vector2 current_pos;
    public Sprite ballImage;
    public Sprite snowBall;
    public Sprite leafBall;
    public Sprite rainBall;
    public bool snow_flag;
   
    float count = 0;
    float limit = 1000;
	// Use this for initialization
	void Start () {
        circlecollider = GetComponent<CircleCollider2D>();
        GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 20, Screen.width / 20);
        circlecollider.radius = Screen.width / 40;
        //rigibody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        current_pos = GetComponent<RectTransform>().position;

        if (special_flag)
        {
            count += Time.deltaTime;
            if(count >= limit)
            {
                if(limit == 4)
                {
                    speedUP();
                }
                if(limit == 3.5f)
                {
                    speedDOWN();
                }
                count = 0;
                special_flag = false;
                GetComponent<Image>().sprite = ballImage;
                GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 20, Screen.width / 20);
                circlecollider.radius = Screen.width / 40;
            }

            if (snow_flag)
            {
                GetComponent<Image>().sprite = ballImage;
                GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 20, Screen.width / 20);
                circlecollider.radius = Screen.width / 40;
                count = 0;
                //limit = 0;
                special_flag = false;
                snow_flag = false;
                special_state = 6;
                Debug.Log("statestatetastasetsetset");
            }

            switch (special_state)
            {
                case 0: // shoot special
                    Instantiate(lighting);
                    Debug.Log("lighting");
                    special_state = 6;
                    limit = 3;
                    break;
                case 1: // clone 3 balls
                    limit = 3;
                    special_state = 6;
                    break;
                case 2: // snowman
                    GetComponent<Image>().sprite = snowBall;
                    circlecollider.radius = Screen.width / 5;
                    GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 10, Screen.width / 10);
                    limit = 9999;
                    //special_state = 6;
                    break;
                case 3: // leaf
                    GetComponent<Image>().sprite = leafBall;
                    speedDOWN();
                    special_state = 6;
                    limit = 4;
                    break;
                case 4: // addpoint
                    special_state = 6;
                    GameObject.FindGameObjectWithTag("GameManager").GetComponent<Maincontrol>().game_score += 1;
                    special_flag = false;
                    break;
                case 5: // rainbow
                    limit = 3.5f;
                    GetComponent<Image>().sprite = rainBall;
                    speedUP();
                    special_state = 6;
                    break;
                case 6:
                    break;
            }
        }
    }

    public void setPosition(float x, float y)
    {
        GetComponent<RectTransform>().position = new Vector2(x, y);
    }

    public void setSpeed(float speed)
    {
        rigibody.velocity = new Vector2(speed, speed);
    }
    public void speedUP()
    {
        rigibody.velocity = new Vector2(rigibody.velocity.x * 2f, rigibody.velocity.y * 2f);
    }

    public void speedDOWN()
    {
        rigibody.velocity = new Vector2(rigibody.velocity.x * 0.5f, rigibody.velocity.y * 0.5f);
    }
}
