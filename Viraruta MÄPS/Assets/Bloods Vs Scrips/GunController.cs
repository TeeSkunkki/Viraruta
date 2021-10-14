using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour{



    private AudioSource mAudioSrc;
    public bool isFiring;

    public BulletController bullet;
    public float bulletSpeed;

    public float fireRate;
    private float shotCounter;
    public float gunBloom;

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
          newBullet.maxBloom = Mathf.Clamp(gunBloom, 0.0f, 10.0f);
          newBullet.speed = bulletSpeed;
          //mAudioSrc.Play();
          gunBloom++;
        }

      } else {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0){
        shotCounter = 0;
      }
      }
      if(gunBloom >= 10.0f){
        gunBloom = 10.0f;
      }else if(gunBloom <= 0.0f){
        gunBloom = 0.0f;
      }else{
        gunBloom -= Time.deltaTime * 2;
      }
    }
}
