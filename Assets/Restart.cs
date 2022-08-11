using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceMatch3
{
    public class Restart : MonoBehaviour
    {
        public void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
