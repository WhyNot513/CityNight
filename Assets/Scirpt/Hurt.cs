using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt : MonoBehaviour
{
    public AudioData audioData;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.TryGetComponent<playerController>(out playerController player))
        {
            //  player.CanLadder = true;


            if (this.gameObject.tag == "EnemyBullet")
            {
                player.CanHurt = true;
                this.gameObject.SetActive(false);

            }
            if (audioData.AudioClip != null)
            {
                AduioManager.instance.PlayerSFX(audioData);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<playerController>(out playerController player))
        {
            if (this.gameObject.tag == "Enemy")
            {

                player.CanHurt = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<playerController>(out playerController player))
        {
            //  player.CanLadder = false;
            //  player.CanHurt = false;
            if (this.gameObject.tag == "EnemyBullet")
            {
                this.gameObject.SetActive(false);
                //player.CurrentHealth -= 5;
                //player.statebar.UpdateStats(player.CurrentHealth, player.MaxHealth);
            }
        }
    }
}
