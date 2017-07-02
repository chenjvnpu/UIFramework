using UnityEngine;
using System.Collections;

public class LodingSceneCtrl : MonoBehaviour
{
	[SerializeField]
	private UISceneLodingCtrl uiSceneLoding;
	private AsyncOperation asyncopt;
	private int currentProcress = 0;
	// Use this for initialization
	void Start ()
	{
		LayerUIMgr.Instance.Reset ();
		StartCoroutine (LodingScene ());
	}

	IEnumerator LodingScene ()
	{
//		yield return new WaitForSeconds(0.2f);
		asyncopt = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync (GetSceneName ());
		asyncopt.allowSceneActivation = false;
		uiSceneLoding.SetProgressValue (0);
		yield return asyncopt;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (asyncopt == null)
			return;
		int toProcress = 0;
		if (asyncopt.progress < 0.9f) {
			toProcress = (int)(asyncopt.progress * 100);

		} else {
			toProcress = 100;
		}
		toProcress = Mathf.Clamp (toProcress, 1, 100);//最小值设为1，防止最小值为0的时候，跳过currentProcress++的case
//		Debug.Log (currentProcress+"---"+asyncopt.progress+"------"+toProcress);
		if (currentProcress < toProcress) {//使显示的当前进度连续变化
			currentProcress++;
		} else
			asyncopt.allowSceneActivation = true;
		uiSceneLoding.SetProgressValue (currentProcress);

	}

	string GetSceneName ()
	{
		string sceneName = "";
		switch (SceneMgr.Instance.CurrentSceneType) {
		case SceneType.Loding:
			sceneName = "loding";
			break;
		case SceneType.City:
			sceneName = "city";
			break;
		case SceneType.Login:
			sceneName = "login";
			break;
		default:
			break;
		}
		return sceneName;
	}
}
