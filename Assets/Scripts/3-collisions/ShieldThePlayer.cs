using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class ShieldThePlayer : MonoBehaviour {
    [Tooltip("The number of seconds that the shield remains active")] [SerializeField] float duration;
    [SerializeField] SpriteRenderer shieldSprite;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Debug.Log("Shield triggered by player");
            var destroyComponent = other.GetComponent<DestroyOnTrigger2D>();
            
             var shieldObject = other.transform.Find("ShieldSprite")?.gameObject;
                shieldSprite = shieldObject?.GetComponent<SpriteRenderer>();

            if (destroyComponent) {
                destroyComponent.StartCoroutine(ShieldTemporarily(destroyComponent));        // co-routines
                    // NOTE: If you just call "StartCoroutine", then it will not work, 
                    //       since the present object is destroyed!
                // ShieldTemporarily(destroyComponent);                                      // async-await
                Destroy(gameObject);  // Destroy the shield itself - prevent double-use
            }
        } else {
            Debug.Log("Shield triggered by "+other.name);
        }
    }

    private IEnumerator ShieldTemporarily(DestroyOnTrigger2D destroyComponent) {   // co-routines
    // private async void ShieldTemporarily(DestroyOnTrigger2D destroyComponent) {      // async-await
        destroyComponent.enabled = false;
        if (!shieldSprite.enabled)
            shieldSprite.enabled = true;

        shieldSprite.color = new Color(1, 1, 1, 1);

        for (float i = duration; i > 0; i--) {
            // change the sprite transparency to show the time remaining
            shieldSprite.color = new Color(1, 1, 1, i/duration);

            Debug.Log("Shield: " + i + " seconds remaining!");
            yield return new WaitForSeconds(1);       // co-routines
            // await Task.Delay(1000);                // async-await
        }
        Debug.Log("Shield gone!");
        shieldSprite.enabled = false;
        destroyComponent.enabled = true;
    }

    // make the sheild appear or disappear using the sprite renderer

}

    