using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    [SerializeField] 
    Button PlayButton;
    
    [SerializeField] 
    Button ExitButton;

    void Start()
    {
        PlayButton.onClick.AddListener(delegate { startGame(); });
        ExitButton.onClick.AddListener(delegate { exitGame(); });

    }

    void startGame(){
        SceneManager.LoadScene(1);
    }

    void exitGame(){
        Application.Quit();
    }

}
