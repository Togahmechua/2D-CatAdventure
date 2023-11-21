using System.Collections;
using UnityEngine;

public class Appear : MonoBehaviour
{
    public GameObject trigger;
    public float timeToAppear = 5f;
    public float timeToDisappear = 3f;

    private void Start()
    {
        // Bắt đầu coroutine để quản lý việc kích hoạt và tắt
        StartCoroutine(AppearAndDisappear());
    }

    private IEnumerator AppearAndDisappear()
    {
        while (true)
        {
            // Kích hoạt Object
            trigger.SetActive(true);
            yield return new WaitForSeconds(timeToAppear);

            // Tắt Object
            trigger.SetActive(false);
            yield return new WaitForSeconds(timeToDisappear);
        }
    }
}
