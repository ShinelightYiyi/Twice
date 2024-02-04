using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    public string[] Level;
    
    public void Select0()
    {
        SceneController.Instance.LoadScene(Level[0]);
    }

    public void Select1()
    {
        SceneController.Instance.LoadScene(Level[1]);
    }

    public void Select2()
    {
        SceneController.Instance.LoadScene(Level[2]);
    }
    public void Select3()
    {
        SceneController.Instance.LoadScene(Level[3]);
    }
    public void Select4()
    {
        SceneController.Instance.LoadScene(Level[4]);
    }
    public void Select5()
    {
        SceneController.Instance.LoadScene(Level[5]);
    }
    public void Select6()
    {
        SceneController.Instance.LoadScene(Level[6]);
    }
    public void Select7()
    {
        SceneController.Instance.LoadScene(Level[7]);
    }
}
