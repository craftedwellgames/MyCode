using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;


public class LoadingBar : MonoBehaviour {

    public Slider loadingbar;
    public Text loadingPercent;
    AsyncOperation sceneLoading;
    float loadingBarPer;
   
    // public AudioSource backgrndMusic;

    void Start()
    {
        StartCoroutine(AsynchronousLoad("SampleScene"));
        //  backgrndMusic.Play();
    }


    IEnumerator AsynchronousLoad(string SampleScene)
    {
        yield return null;
        sceneLoading = SceneManager.LoadSceneAsync(SampleScene);
        sceneLoading.allowSceneActivation = false;

        while (!sceneLoading.isDone)
        {
            float progress = Mathf.Clamp01(sceneLoading.progress / 0.9f);
            loadingbar.value = loadingBarPer;
            loadingBarPer = progress * 100;
            loadingPercent.text = loadingBarPer.ToString() + "%";
            
          
            if (sceneLoading.progress == 0.9f)
            {
                sceneLoading.allowSceneActivation = true;
               // StartCoroutine("Pause");

                yield return null;
            }

        }
    }
 //   public IEnumerator Pause()
   // {
   //     yield return new WaitForSeconds(2);
        //  backgrndMusic.Stop();
       
   // }
}





  

