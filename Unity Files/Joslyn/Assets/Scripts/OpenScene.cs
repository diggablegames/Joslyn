using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour {
	[SerializeField] string sceneName;

	public void openScene(){
		SceneManager.LoadScene(sceneName);
	}
}
