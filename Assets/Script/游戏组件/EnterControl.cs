using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class EnterControl : MonoBehaviour
{
    public string scene;
    private BoxCollider2D bx;
    private SpriteRenderer spriteRenderer;
    private bool canEnter;
    private bool canChange;
    
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        bx = GetComponent<BoxCollider2D>();
        canEnter = false;
        EventCenter.Instance.AddEventListener<bool>("通关前置",(o)=>CanGo(o));
        EventCenter.Instance.AddEventListener("切换世界",()=>ChangeScene());    
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

    private void Update()
    {
        CanGet();
    }
    private void ChangeScene()
    {
        canChange = !canChange;
    }
    private void CanGet()
    {
        if (canChange)
        {
            bx.isTrigger = true;
            bx.size = new Vector2(5.831726f, 8.549131f);
            spriteRenderer.DOFade(1f, 0.2f);
        }
        else
        {
            bx.isTrigger = false;
            bx.size = new Vector2(0, 0);
            spriteRenderer.DOFade(0.5f, 0.2f);
        }
    }

    private void ReadyLoadSceneAsy()
    {
        GameRoot.Instance.rootUIManager.Pop(false);
        EventCenter.Instance.Clear();
        GameRoot.Instance.rootUIManager.Push(new PanelPass());
        Invoke("LoadSceneAsy", 0.5f);
    }

    private void LoadSceneAsy()
    {
        SceneController.Instance.LoadSceneAsyn(scene);
        
    }
}
