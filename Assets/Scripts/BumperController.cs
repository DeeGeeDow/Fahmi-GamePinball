using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    // menyimpan variabel bola sebagai referensi untuk pengecekan
    public Collider ballCollider;
    public float multiplier;

    private void OnCollisionEnter(Collision collision)
    {
        // memastikan yang menabrak adalah bola
        if (collision.collider == ballCollider)
        {
            Rigidbody rbBall = ballCollider.GetComponent<Rigidbody>();
            rbBall.velocity *= multiplier;
            // kita lakukan debug
            Debug.Log("Kena Bola");
        }
    }
}
