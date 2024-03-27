using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class PlayButton : MonoBehaviour
    {
        public void Play() => SceneManager.LoadScene(1);
    }
}