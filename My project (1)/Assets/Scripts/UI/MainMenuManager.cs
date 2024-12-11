using UnityEngine;
using UnityEngine.SceneManagement; 
public class MainMenuManager : MonoBehaviour
{
	
	[Header("Main Menu")]
	[SerializeField] private GameObject mainMenuScreen;
    private void Awake()
    {
		mainMenuScreen.SetActive(true);
    }
    private void Update()
    {

    }

    #region Game Over
    
	public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    //Quit game/exit play mode if in Editor
    public void Quit()
    {
        Application.Quit(); //Quits the game (only works in build)

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //Exits play mode (will only be executed in the editor)
#endif
    }
    #endregion
}