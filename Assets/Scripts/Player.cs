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
    public bool starPower { get; private set; }

    private void Awake() {
        deathAnimation = GetComponent<DeathAnimation>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        activeRenderer = smallRenderer;
    }

    public void Hit() {
        if (!starPower && !dead) {
            if (big) {
                Shrink();
            } else {
                Death();
            }
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

    public void StarPower(float duration = 10f) {
        StartCoroutine(StarPowerAnimation(duration));
    }

    private IEnumerator StarPowerAnimation(float duration) {
        starPower = true;
        float elapsed = 0;

        while (elapsed < duration) {
            elapsed += Time.deltaTime;
            if (Time.frameCount % 4 == 0) {
                activeRenderer.spriteRenderer.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
            }
            yield return null;
        }

        activeRenderer.spriteRenderer.color = Color.white;
        starPower = false;

    }
}
