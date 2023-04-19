using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverOnTrigger2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger game over")]
    [SerializeField] string triggeringTag;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggeringTag && enabled && this.gameObject.GetComponent<DestroyOnTrigger2D>().enabled) {
            Debug.Log("Game over!");

        // if player without shield, game over

            // Move to game over scene
            SceneManager.LoadScene("GameOver");    
            // UnityEditor.EditorApplication.isPlaying = false;  # Error on editor 2021.3
        }
    }

    private void Update() {
        /* Just to show the enabled checkbox in Editor */
    }

}
