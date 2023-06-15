using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountdownManager : MonoBehaviour
{
    public Text countdownText;

    private void Start()
    {
        StartCoroutine(CountdownCoroutine());
    }

    private IEnumerator CountdownCoroutine()
    {
        int countdown = 3;

        while (countdown > 0)
        {
            countdownText.text = countdown.ToString();
            yield return new WaitForSeconds(1f);
            countdown--;
        }

        countdownText.text = "Fight!";
        yield return new WaitForSeconds(1f);

        // G?i ph??ng th?c b?t ??u tr?n ??u t?i ?ây

        countdownText.gameObject.SetActive(false); // T?t hi?n th? màn hình ??m ng??c
    }
}
