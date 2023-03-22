using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //외부에서 스타트버튼 함수를 사용하려면
    public void GameStart()
    {
        SceneManager.LoadScene("MainScene");
    }
}
