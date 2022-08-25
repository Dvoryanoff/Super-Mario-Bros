using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private PlayerSpriteRenderer smallRenderer;
    [SerializeField] private PlayerSpriteRenderer bigRenderer;

    private DeathAnimation deathAnimation;

    public bool small => smallRenderer.enabled;
    public bool big => bigRenderer.enabled;
    public bool dead => deathAnimation.enabled;

    private void Awake() {
        deathAnimation = GetComponent<DeathAnimation>();
    }

    public void Hit() {
        if (big) {
            Shrink();
        } else {
            Death();
        }
    }

    private void Shrink() {

    }

    private void Death() {
        bigRenderer.enabled = false;
        smallRenderer.enabled = false;
        deathAnimation.enabled = true;

        GameManager.Instance.ResetLevel(3f);

    }
}
