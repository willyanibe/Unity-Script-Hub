using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuStartGame : MonoBehaviour
{
    public static MainMenuStartGame Instance;
	public GameObject button1;
	public GameObject button2;
	public Text load;
	public Slider slide;
	float progressinfo;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadSceneWithCharChoice(string levelName) {
		//SceneManager.LoadScene(levelName);
		StartCoroutine(LoadScene(levelName));
		button1.SetActive(false);
		button2.SetActive(false);
	}

    public void RunInterstitialAd() {
        //AdsManager.Instance.RemoteShowInterstitial();
        //AdsManager.Instance.ShowAdmobInterstitial();
    }

	IEnumerator LoadScene(string level)
	{
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(level);


		while(!asyncLoad.isDone)
		{
			float progress = Mathf.Clamp01(asyncLoad.progress / .9f);
			slide.value = progress;
			progressinfo = progress * 100f;
			load.text = "LOADING" + "(" + (int)progressinfo + "%" + ")";

			yield return null;
		}
	}
}
