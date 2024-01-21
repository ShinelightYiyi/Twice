using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    private static GameRoot instance;
    public static GameRoot Instance { get=>instance; }

    public UIManager rootUIManager;

    public void Awake()
    {
        rootUIManager = new UIManager();

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
    }

    private void Start()
    {
        //  rootUIManager.Push(new PanelA());
        AuidoMag.Instance.Play("Music/AudioA");
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape)) 
        {
            rootUIManager.Pop(false);
            rootUIManager.Push(new PanelAudio());
        }
        else if(Input.GetKeyUp(KeyCode.R))
        {
            rootUIManager.Pop(false);
            rootUIManager.Push(new PanelA());
        }
    }
}
