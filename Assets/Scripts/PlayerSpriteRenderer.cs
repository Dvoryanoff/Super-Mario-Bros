using UnityEngine;

public class PlayerSpriteRenderer : MonoBehaviour {

    public SpriteRenderer spriteRenderer { get; private set; }
    private PlayerMovement movement;

    [SerializeField] private Sprite idle;
    [SerializeField] private Sprite jump;
    [SerializeField] private Sprite slide;
    [SerializeField] private AnimatedSprite run;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement = GetComponentInParent<PlayerMovement>();
    }

    private void OnEnable() {
        spriteRenderer.enabled = true;
    }

    private void OnDisable() {
        spriteRenderer.enabled = false;
        run.enabled = false;
    }

    private void LateUpdate() {

        run.enabled = movement.IsRunning;
        if (movement.IsJumping) {
            spriteRenderer.sprite = jump;
        } else if (movement.IsSliding) {
            spriteRenderer.sprite = slide;
        } else if (!movement.IsRunning) {
            spriteRenderer.sprite = idle;
        }
    }
}

