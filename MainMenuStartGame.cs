using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuStartGame : MonoBehaviour
{
    public static MainMenuStartGame Instance;
	
	public Text load;
	public Slider slide;
	float progressinfo;

	// Start is called before the first frame update
	

    public void LoadSceneWithCharChoice(string levelName) {
		//SceneManager.LoadScene(levelName);
		StartCoroutine(LoadScene(levelName));
		
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
