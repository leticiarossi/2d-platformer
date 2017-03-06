using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {
	void OnClick() {
		SceneManager.LoadScene ("MainGame");
	}
}