using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterControl : MonoBehaviour
{
    public string scene;
    private bool canEnter;
    private void Awake()
    {
        canEnter = false;
        EventCenter.Instance.AddEventListener<bool>("Í¨¹ØÇ°ÖÃ",(o)=>CanGo(o));
    }
    private void CanGo(bool o)
    {
        if(o)
        {
            canEnter = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && canEnter)
        {
            Invoke("ReadyLoadSceneAsy", 0.1f);
        }
    }

    private void ReadyLoadSceneAsy()
    {
        GameRoot.Instance.rootUIManager.Pop(true);
        EventCenter.Instance.Clear();
        GameRoot.Instance.rootUIManager.Push(new PanelPass());
        Invoke("LoadSceneAsy", 0.5f);
    }

    private void LoadSceneAsy()
    {
        SceneController.Instance.LoadSceneAsyn(scene);
    }
}
