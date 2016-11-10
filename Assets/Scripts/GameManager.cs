using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


namespace Kettukanapeli
{
    public class GameManager : MonoBehaviour
    {
        #region Statics
        private static GameManager _instance;
        private static bool _isQuitting = false;

        public static GameManager Instance
        {
            get
            {
                if ( _instance == null && !_isQuitting )
                {
                    _instance = FindObjectOfType<GameManager> ();
                    if ( _instance == null )
                    {
                        GameObject go = new GameObject ( "GameManager" );
                        _instance = go.AddComponent<GameManager> ();
                        _instance.Init ();
                    }
                }
                return _instance;
            }
        }
        #endregion

        private Camera _mainCamera;
        private CameraSmoothFollow _cameraSmoothFollow;
        private GUIManager _guiManager;

        public GUIManager GUIManager
        {
            get
            {
                if ( _guiManager == null )
                {
                    _guiManager = FindObjectOfType<GUIManager> ();
                }
                if ( _guiManager == null )
                {
                    Debug.LogError ( "GameManager: GUIManager is not found from scene!" );
                    Debug.Break ();
                }

                return _guiManager;
            }
        }

        private void Awake ()
        {
            if ( _instance == null )
            {
                _instance = this;
                Init ();
            }
            else if ( _instance != this )
            {
                Destroy ( this );
            }
        }

        private void OnApplicationQuit ()
        {
            _isQuitting = true;
        }

        private void Init ()
        {
            _mainCamera = Camera.main;
            _cameraSmoothFollow = _mainCamera.GetComponent<CameraSmoothFollow> ();
            Pause ( true );
        }

        public void Pause ( bool pause )
        {
            if ( pause )
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        public void GameOver ()
        {
            Pause ( true );
            GUIManager.GameOver ();
            _cameraSmoothFollow.GameOver ();
        }

        public void StartGame ()
        {
            Pause ( false );
        }

        public void OnNewGamePressed ()
        {
            SceneManager.LoadScene ( SceneManager.GetActiveScene ().name );
        }

        public void OnQuitGamePressed ()
        {
            Application.Quit();
        }
    } 
}
