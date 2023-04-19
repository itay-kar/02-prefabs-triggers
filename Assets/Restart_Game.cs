using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class Restart_Game : MonoBehaviour
{
    [SerializeField] InputAction restartGame = new InputAction(type: InputActionType.Button);
    // Start is called before the first frame update
    void OnEnable()  {
        restartGame.Enable();
    }

    void OnDisable()  {
        restartGame.Disable();
    }

    void Update() {
        if (restartGame.triggered){
            SceneManager.LoadScene("level-1");
        }
    }

    
}
