using System.Collections;
using UnityEngine;

public class Pipe : MonoBehaviour {

    [SerializeField] private Transform connection;
    [SerializeField] private KeyCode enterKeyKode = KeyCode.S;
    [SerializeField] private Vector3 enterDirection = Vector3.down;
    [SerializeField] private Vector3 exitDirection = Vector3.zero;

    private void OnTriggerStay2D(Collider2D other) {
        if (connection != null && other.CompareTag(nameof(Player))) {
            if (Input.GetKeyDown(enterKeyKode)) {
                StartCoroutine(enter(other.transform));
            }

        }

    }

    private IEnumerator Enter(Transform player) {
        player.GetComponent<PlayerMovement>().enabled = false;

        Vector3 enteredPosition = transform.position + enterDirection;
        Vector3 enteredScale = Vector3.one * 0.5f;

    }

}
