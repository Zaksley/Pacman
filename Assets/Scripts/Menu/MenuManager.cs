using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MenuManager : MonoBehaviour
    {
        public void GetBackToMenu()
        {
            SceneManager.LoadScene("Menu"); 
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}