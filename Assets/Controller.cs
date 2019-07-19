using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public GameObject[] buttons;
    public int[] noOfSensors { get; set; }
    public string[] statNames { get; set; }
    public bool isVisible { get; set; } = false;
    public GameObject d1;
   // public GameObject preff = (GameObject)Resources.Load<GameObject>("Assets/Resources/Buttonpre");
    public Controller(int noOfUseCases)
    {
        buttons = new GameObject[noOfUseCases];
        isVisible = false;
        

    }
    public void Start()
    {
    //    d1 = (GameObject)Resources.Load<GameObject>("/Buttonpre");
        
 //       Debug.Log(d1);
    }

    public void LoadScene(string sceneName)
    {
        Debug.Log(sceneName + " Has Been Loaded");
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Debug.Log("saaaaaaaaaaaaaaaaa");
        // save any game data here
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    public void MainMenu(string sceneMenu)
    {
        SceneManager.LoadScene(sceneMenu);
    }

    public void DoSth()
    {
        Debug.Log("I see you.");
    }
    public GameObject buttonPrefab;
    //public GameObject testPrefab = (GameObject)Resources.Load("/Button7-2.png");
    
    public void MakeButton(string direction)
    {
    //    QuitGame();
        if (isVisible == false)
        {

            for (int i = 0; i < buttons.Length; i += 1)
            {
                buttons[i] = (GameObject)Instantiate(buttonPrefab);
                // Instantiate (clone) the prefab    


                var panel = GameObject.Find("Canvas");
                buttons[i].transform.position = panel.transform.position;
                buttons[i].GetComponent<RectTransform>().SetParent(panel.transform);
                buttons[i].GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, i*35, 30);
                buttons[i].layer = 5;
                //  button.GetComponent<RectTransform>().anchorMax = new Vector2(30.0f, 30.0f);
                //  button.GetComponent<RectTransform>().anchorMin = new Vector2(10.0f, 10.0f);
                buttons[i].GetComponentInChildren<Text>().text = "Sıcaklık";
                buttons[i].GetComponent<Button>().onClick.AddListener(delegate() { MakeButton("aasd"); });
            }
            isVisible = true;
        }
        else
        {
            for (int i = 0; i < buttons.Length; i += 1)
            {
                Destroy(buttons[i].gameObject);
            }
            isVisible = false;
        }

    }    
}
