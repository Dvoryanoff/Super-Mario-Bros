using UnityEngine;

public class SideScrolling : MonoBehaviour {
    private Transform player;
    private float height = 6.4f;
    private float undergroundHeight = -9.36f;
    // 155.5 9.36
    private void Awake() {
        player = GameObject.FindWithTag("Player").transform;
    }

    private void LateUpdate() {
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = Mathf.Max(player.transform.position.x, cameraPosition.x);
        transform.position = cameraPosition;
    }

    public void SetUnderground(bool underground) {
        Vector3 cameraPosition = transform.position;
        cameraPosition.y = underground ? undergroundHeight : height;
        transform.position = cameraPosition;

    }

}
