using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public GameObject quizPanel;
    public TextMeshProUGUI questionText;
    public Button optionAButton;
    public Button optionBButton;
    public TextMeshProUGUI feedbackText;

    public string correctAnswer = "A";

    private CourageSystem courageSystem;

    private void Start()
    {
        quizPanel.SetActive(false);

        if (feedbackText != null)
            feedbackText.gameObject.SetActive(false);

        courageSystem = FindObjectOfType<CourageSystem>();

        optionAButton.onClick.AddListener(() => Answer("A"));
        optionBButton.onClick.AddListener(() => Answer("B"));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            quizPanel.SetActive(true);
            questionText.text = "İyi bir lider nasıl davranmalıdır?";
        }
    }

    public void Answer(string selected)
    {
        if (selected == correctAnswer)
        {
            feedbackText.text = "TAM BİR LİDER!";
            feedbackText.color = Color.green;
            courageSystem.IncreaseCourage(10);
            courageSystem.AddFollower(10); // doğruysa +10 takipçi
        }
        else
        {
            feedbackText.text = "LİDER DOĞRU OLMALIDIR";
            feedbackText.color = Color.red;
            courageSystem.DecreaseCourage(5);
            courageSystem.RemoveFollower(3); // yanlışsa -3 takipçi
        }

        feedbackText.gameObject.SetActive(true);
        quizPanel.SetActive(false);

        // 2 saniye sonra quiz nesnesini yok et ve feedback'i kapat
        Invoke(nameof(HideFeedbackAndDestroy), 2f);
    }

    private void HideFeedbackAndDestroy()
    {
        feedbackText.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
