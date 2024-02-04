using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BoxControl : MonoBehaviour
{

    private Rigidbody2D rg;
    private SpriteRenderer sp;
    private BoxCollider2D box;
    private GameObject player;
    private Animator ani;
    public string thisScene;
    [SerializeField] bool isDown, isHurt;

    private void Start()
    {
        ani = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        box = GetComponent<BoxCollider2D>();
        sp = GetComponent<SpriteRenderer>();
        rg = GetComponent<Rigidbody2D>();
        EventCenter.Instance.AddEventListener("ÇÐ»»ÊÀ½ç", () => ChangeScene());    
    }

    private void Update()
    {
        ChangeGrivaty();
        CanHurt();
    }

    private void CanHurt()
    {
        if(isHurt)
        {
            box.isTrigger = true;
        }
        else if(!isHurt) 
        {
            box.isTrigger = false;
        }
    }
    private void ChangeGrivaty()
    {
        if(isDown && rg.gravityScale<0)
        {
            rg.gravityScale = -rg.gravityScale;
            ani.SetBool("canChange", false);
        }
        else if(!isDown && rg.gravityScale>0)
        {
            rg.gravityScale = -rg.gravityScale;
            ani.SetBool("canChange", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            KillPlayer();
        }
    }
    private void ChangeScene()
    {
        isDown = !isDown;
        isHurt = !isHurt;
    }

    private void KillPlayer()
    {
        DG.Tweening.Sequence sequence = DOTween.Sequence(player);
        sequence.Append(player.transform.DOScale(0.15f, 0.1f));
        sequence.OnComplete(()=>Destroy(player));
        Invoke("ReStart", 0.3f);
    }
    private void ReStart()
    {
        GameRoot.Instance.rootUIManager.Pop(true);
        EventCenter.Instance.Clear();
        GameRoot.Instance.rootUIManager.Push(new PanelPass());
        Invoke("ReScene", 0.6f);
    }
    private void ReScene()
    {
        SceneController.Instance.LoadSceneAsyn(thisScene);
    }
}
