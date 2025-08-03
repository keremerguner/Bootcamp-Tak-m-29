using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CourageSystem : MonoBehaviour
{
    public int courage = 100;
    public int followers = 0;

    public Slider courageBar;
    public TextMeshProUGUI followerText;

    private TextMeshProUGUI feedbackText; // Tag ile otomatik alınacak

    private void Start()
    {
        // FeedbackText objesini otomatik bul
        GameObject feedbackObj = GameObject.FindGameObjectWithTag("Feedback");
        if (feedbackObj != null)
            feedbackText = feedbackObj.GetComponent<TextMeshProUGUI>();

        UpdateUI();

        // FeedbackText başta görünmesin
        if (feedbackText != null)
            feedbackText.gameObject.SetActive(false);
    }

    public void IncreaseCourage(int amount)
    {
        courage += amount;
        if (courage > 100) courage = 100;
        UpdateUI();
    }

    public void DecreaseCourage(int amount)
    {
        courage -= amount;
        if (courage < 0) courage = 0;
        UpdateUI();
    }

    public void AddFollower(int amount = 1)
    {
        followers += amount;
        UpdateUI();
    }

    public void RemoveFollower(int amount = 1)
    {
        followers -= amount;
        if (followers < 0) followers = 0;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (courageBar != null)
            courageBar.value = courage;

        if (followerText != null)
            followerText.text = "Takipçiler: " + followers.ToString();
    }

    // 🎯 Feedback yazısı göstermek için kullanılacak metot
    public void ShowFeedback(string message, Color color)
    {
        if (feedbackText != null)
        {
            feedbackText.text = message;
            feedbackText.color = color;
            feedbackText.gameObject.SetActive(true);
            CancelInvoke(nameof(HideFeedback));
            Invoke(nameof(HideFeedback), 2f); // 2 saniye sonra gizle
        }
    }

    void HideFeedback()
    {
        if (feedbackText != null)
            feedbackText.gameObject.SetActive(false);
    }
}
