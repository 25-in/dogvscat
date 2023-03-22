using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour
{
    float full = 5f;
    float energy = 0f;
    bool isFull = false;
    public int type;

    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-8.5f, 8.5f);
        float y = 30f;

        if (type == 1)
        {
            full = 10f;
        }

        transform.position = new Vector3(x, y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (energy < full)
        {
            if (type == 0)
            {
                transform.position += new Vector3(0.0f, -0.05f, 0.0f);
            }
            else if (type == 1)
            {
                transform.position += new Vector3(0.0f, -0.03f, 0.0f);
            }
            else if (type == 2)
            {
                transform.position += new Vector3(0.0f, -0.01f, 0.0f);
            }

            if (transform.position.y < -16.0f)
            {
                gameManager.I.gameOver();
            }
        }
        else
        {
            if (transform.position.x > 0)
            {
                transform.position += new Vector3(0.05f, 0.0f, 0.0f);
            }
            else
            {
                transform.position += new Vector3(-0.05f, 0.0f, 0.0f);
            }
            Destroy(gameObject, 3.0f);
        }
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "food")
        {
            if (energy < full)
            {
                energy += 1.0f;
                Destroy(coll.gameObject);   //���� ��븦 ����.
                gameObject.transform.Find("hungry/Canvas/front").transform.localScale = new Vector3(energy / full, 1.0f, 1.0f);
            }
            else
            {
                if (isFull == false) //�ε�������==��θ� �����϶� �� �ѹ��� �Ҹ��� �ؾ��Ѵ�. �ƴϸ� ��� �Ҹ��� ���װ� �߻���.
                {
                    gameManager.I.addCat();
                    gameObject.transform.Find("hungry").gameObject.SetActive(false);
                    gameObject.transform.Find("full").gameObject.SetActive(true);
                    isFull = true;  //���¸� �ٲ��༭ �ٽ� �Ҹ��� �ʰ���.
                }


            }

        }
    }

}
