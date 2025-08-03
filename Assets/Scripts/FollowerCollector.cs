using UnityEngine;

public class FollowerCollector : MonoBehaviour
{
    private CourageSystem courageSystem;

    private void Start()
    {
        courageSystem = FindObjectOfType<CourageSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Follower"))
        {
            courageSystem.AddFollower(1); // 🔥 Follower → +1 takipçi
            Destroy(other.gameObject);
        }
    }
}
