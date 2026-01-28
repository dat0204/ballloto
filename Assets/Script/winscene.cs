using UnityEngine;
using UnityEngine.SceneManagement;
public class winscene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void changescene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }    
}
