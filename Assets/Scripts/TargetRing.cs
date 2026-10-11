using System.Collections;
using UnityEngine;

public class TargetRing : MonoBehaviour
{
    [Header("Punctaj Inel")]
    public int pointsValue = 10;

    [Header("Feedback Vizual")]
    public Color hitColor = Color.yellow;
    private Color originalColor;
    private Renderer ringRenderer;
    private Coroutine flashCoroutine;

    private void Awake()
    {
        ringRenderer = GetComponent<Renderer>();
        if (ringRenderer != null)
        {
            originalColor = ringRenderer.material.color;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verificam daca obiectul care a lovit este proiectilul aruncat
        if (collision.gameObject.CompareTag("Throwable") || collision.gameObject.name.Contains("Projectile"))
        {
            // 1. Trimite punctele la ScoreManager
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddScore(pointsValue);
            }

            // 2. Efect vizual
            if (flashCoroutine != null)
                StopCoroutine(flashCoroutine);

            flashCoroutine = StartCoroutine(FlashEffect());
        }
    }

    private IEnumerator FlashEffect()
    {
        if (ringRenderer != null)
        {
            ringRenderer.material.color = hitColor;
            yield return new WaitForSeconds(0.35f);
            ringRenderer.material.color = originalColor;
        }
    }
}
