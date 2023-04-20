using UnityEngine;
using UnityEngine.SceneManagement;

namespace BuilderGame.Infrastructure.Services
{
    public class SimpleRestarter: MonoBehaviour
    {
        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}