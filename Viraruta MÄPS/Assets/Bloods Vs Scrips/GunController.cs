using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour{



    private AudioSource mAudioSrc;
    public bool isFiring;

    public BulletController bullet;
    public float bulletSpeed;

    public float fireRate;
    public float shotCounter;

    public Transform firePoint;


    // Start is called before the first frame update
    void Start(){
      mAudioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update(){


      if(isFiring){
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0){
          shotCounter = fireRate;
          BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as BulletController;
          newBullet.speed = bulletSpeed;
          mAudioSrc.Play();

        }

      } else {
        
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0){
        shotCounter = 0;
      }
      }


    }
}
