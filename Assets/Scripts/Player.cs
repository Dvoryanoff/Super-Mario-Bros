using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField] private PlayerSpriteRenderer smallRenderer;
    [SerializeField] private PlayerSpriteRenderer bigRenderer;
    private PlayerSpriteRenderer activeRenderer;
    private CapsuleCollider2D capsuleCollider;

    private DeathAnimation deathAnimation;

    public bool small => smallRenderer.enabled;
    public bool big => bigRenderer.enabled;
    public bool dead => deathAnimation.enabled;

    private void Awake() {
        deathAnimation = GetComponent<DeathAnimation>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    public void Hit() {
        if (big) {
            Shrink();
        } else {
            Death();
        }
    }

    private void Death() {
        bigRenderer.enabled = false;
        smallRenderer.enabled = false;
        deathAnimation.enabled = true;

        GameManager.Instance.ResetLevel(3f);

    }
    private void Shrink() {
        smallRenderer.enabled = false;
        bigRenderer.enabled = true;
        activeRenderer = smallRenderer;

        capsuleCollider.size = new(1f, 1f);
        capsuleCollider.offset = new(0f, 0f);

        StartCoroutine(ScaleAnimation());

    }

    public void Grow() {
        smallRenderer.enabled = false;
        bigRenderer.enabled = true;
        activeRenderer = bigRenderer;

        capsuleCollider.size = new(1f, 2f);
        capsuleCollider.offset = new(0f, 0.5f);

        StartCoroutine(ScaleAnimation());

    }

    private IEnumerator ScaleAnimation() {
        float elapsed = 0f;
        float durationn = 0.5f;

        while (elapsed < durationn) {
            elapsed += Time.deltaTime;

            if (Time.frameCount % 4 == 0) {
                smallRenderer.enabled = !smallRenderer.enabled;
                bigRenderer.enabled = !smallRenderer.enabled;
            }
            yield return null;

            smallRenderer.enabled = false;
            bigRenderer.enabled = false;
            activeRenderer.enabled = true;
        }
    }
}
