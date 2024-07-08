using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneManager : MonoBehaviour
{
    public Image progressBar;


    private void Start()
    {
        StartCoroutine(LoadAsync(1));
    }
    public void LoadLevelWithImage()
    {
        StartCoroutine(LoadAsync(1));
    }

    IEnumerator LoadAsync(int level)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(level);
        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / 1f);

            progressBar.fillAmount = progress;

            yield return null;
        }   
    }
}