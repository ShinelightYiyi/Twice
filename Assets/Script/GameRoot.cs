using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    private static GameRoot instance;
    public static GameRoot Instance { get=>instance; }

    public UIManager rootUIManager;

    private GameObject AudioObj;

    public void Awake()
    {
        rootUIManager = new UIManager();

        AudioObj = GameObject.FindGameObjectWithTag("Audio");
        if(instance == null )
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        GameObject go = GameObject.FindGameObjectWithTag("NormalCanvas");
        DontDestroyOnLoad(go);
        DontDestroyOnLoad(this);
        DontDestroyOnLoad(AudioObj);
    }

    public void ReadyStartGame()
    {
        SceneController.Instance.LoadScene("level0 1");
     //   AuidoMag.Instance.Play("Music/¹Ø¿¨");
    }

}
