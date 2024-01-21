using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class SceneController
{
    private static SceneController instance;
    public static SceneController Instance { get => instance ?? new SceneController(); }
    //单例模式

    public void LoadScene(BaseScene scene)
    {
        SceneManager.LoadScene(scene.SceneName);
        scene.EnterScene();
    }
    public void LoadSceneAsyn(BaseScene scene)
    {
       MonoManager.Instance.StartCroutine(ReallyLoadSceneAsyn(scene));
    }
    private IEnumerator ReallyLoadSceneAsyn(BaseScene scene)
    {
        float disProgress = 0f;
        float currentProgress = 0f;

        AsyncOperation asy = SceneManager.LoadSceneAsync(scene.SceneName);
        asy.allowSceneActivation = false;

        while(currentProgress < 0.9f)
        {
            currentProgress = asy.progress;
            while(disProgress < currentProgress) 
            {
                disProgress += 0.01f;
                EventCenter.Instance.EventTrigger("加载场景", disProgress);
            }
            yield return currentProgress;
        }

        while(disProgress <= 1f)
        {
            disProgress += 0.01f;
            EventCenter.Instance.EventTrigger("加载场景" , disProgress);
            yield return disProgress;
        }

        while (!asy.isDone)
        {
            //  Debug.Log("进入加载 3");
            EventCenter.Instance.EventTrigger("加载场景", 1f);
            if (disProgress >= 0.9f)
            {
                asy.allowSceneActivation = true;
            }
            yield return asy.progress;
        }

        scene.EnterScene();
    }
}
