using UnityEngine;

public class HazardAndBonusHandler : MonoBehaviour
{
    private CourageSystem courageSystem;

    private void Start()
    {
        courageSystem = FindObjectOfType<CourageSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            courageSystem.DecreaseCourage(10);
            courageSystem.RemoveFollower(1);
            courageSystem.ShowFeedback("Tuzağa bastın! Dikkatli olmalısın.", Color.red);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Potion"))
        {
            courageSystem.IncreaseCourage(50);
            courageSystem.AddFollower(3);
            courageSystem.ShowFeedback("İlham verici bir konuşma yaptın!", new Color(1f, 0.5f, 0f)); // Turuncu
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Follower"))
        {
            courageSystem.IncreaseCourage(50);
            courageSystem.AddFollower(1);
            courageSystem.ShowFeedback("Gerçek liderler insanları peşinden sürükler.", Color.cyan); // Mavi
            Destroy(collision.gameObject);
        }
    }
}
