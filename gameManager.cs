using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public GameObject dog;
    public GameObject food;
    public GameObject normalCat;
    public GameObject fatCat;
    public GameObject pirateCat;
    public GameObject retryBtn;
    public static gameManager I;
    public Text levelText;
    public GameObject levelFront;

    int level = 0;
    int cat = 0;

    void Awake()
    {
        I = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;    //시간을 다시 되돌린다.
        InvokeRepeating("makeFood", 0.0f, 0.1f); //0.1초마다
        InvokeRepeating("makeCat", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void makeFood()
    {
        
        float x = dog.transform.position.x;
        float y = dog.transform.position.y + 2.0f;
        Instantiate(food, new Vector3(x, y, 0), Quaternion.identity);//Quaternion.identity(회전을 표현할 수 있는 데이터타입) / 이 위치에 생성시켜라.

    }

    void makeCat()
    {
        Instantiate(normalCat);

        if (level == 1)
        {
            float p = Random.Range(0, 10);
            if (p < 2) Instantiate(normalCat);
        }
        else if (level == 2)
        {
            float p = Random.Range(0, 10);
            if (p < 5) Instantiate(normalCat);
        }
        else if (level == 3)
        {
            float p = Random.Range(0, 10);
            if (p < 6) Instantiate(normalCat);
        }
        else if (level >= 4)
        {
            float p = Random.Range(0, 10);
            if (p < 8) Instantiate(normalCat);
            Instantiate(fatCat);
            Instantiate(pirateCat);
        }
    }

    public void gameOver()
    {
        retryBtn.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void addCat()
    {
        cat += 1;
        level = cat / 5;    //고양이 다섯마리 잡으면 레벨업

        levelText.text = level.ToString();
        levelFront.transform.localScale = new Vector3((cat - level * 5) / 5.0f, 1.0f, 1.0f); //소수점 float로 나눠준다.

    }
}
