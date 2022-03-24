using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    [SerializeField]
    Button ResumeButton;
    [SerializeField]
    Button ExitButton;
    [SerializeField]
    Button MainMenuButton;

    bool isMenuShowing = false;

    // Start is called before the first frame update
    void Start()
    {
        ResumeButton.onClick.AddListener(delegate { resumeGame(); });
        MainMenuButton.onClick.AddListener(delegate { goToMainMenu(); });
        ExitButton.onClick.AddListener(delegate { exitGame(); });

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            isMenuShowing = !isMenuShowing;
        }
        gameObject.GetComponent<Canvas>().enabled = isMenuShowing;
    }

    void exitGame(){
        Application.Quit();
    }
    void resumeGame(){
        isMenuShowing = !isMenuShowing;
    }
    void goToMainMenu(){
        SceneManager.LoadScene(0);
    }
}
