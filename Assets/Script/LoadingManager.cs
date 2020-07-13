using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingManager : MonoBehaviour
{
    public static string nextScene;

    [SerializeField]
    Image Loadingbar;

    void Start()
    {
        StartCoroutine(LoadScene());
    }

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("Loading");
    }
    
    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;

            timer += Time.deltaTime;

            if (op.progress >= 0.9f)
            {
                Loadingbar.fillAmount = Mathf.Lerp(Loadingbar.fillAmount, 1f, timer);

                if (Loadingbar.fillAmount == 1.0f)
                    op.allowSceneActivation = true;
            }
            else
            {
                Loadingbar.fillAmount = Mathf.Lerp(Loadingbar.fillAmount, op.progress, timer);
                if (Loadingbar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
        }

    }
}
