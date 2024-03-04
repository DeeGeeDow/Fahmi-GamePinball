using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchController : MonoBehaviour
{
    // menyimpan variabel bola sebagai referensi untuk pengecekan
    public Collider bola;

    public Material offMaterial;
    public Material onMaterial;

    private Renderer renderer;
    public ScoreManager scoreManager;
    public float score;

    private enum SwitchState
    {
        Off,
        On,
        Blink
    };

    private SwitchState state;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material = offMaterial;
        StartCoroutine(BlinkTimerStart(5));
    }

    private void Set(bool active)
    {
        if (active)
        {
            state = SwitchState.On;
            renderer.material = onMaterial;
            StopAllCoroutines();
        }else
        {
            state = SwitchState.Off;
            renderer.material = offMaterial;
            StartCoroutine(BlinkTimerStart(5));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // memastikan yang menabrak adalah bola
        if (other == bola)
        {
            Toggle();
        }
    }

    private void Toggle()
    {
        Set(state == SwitchState.On);
        scoreManager.AddScore(score);
    }

    private IEnumerator Blink(int times)
    {
        state = SwitchState.Blink;

        // ulang perubahan nyala mati sebanyak parameter
        for (int i = 0; i < times; i++)
        {
            renderer.material = onMaterial;
            yield return new WaitForSeconds(0.5f);
            renderer.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }

        state = SwitchState.Off;
        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }

}
