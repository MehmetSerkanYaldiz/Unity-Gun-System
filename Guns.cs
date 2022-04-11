using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Guns : MonoBehaviour

{
    public LayerMask zombieLayer;
    public Camera Cam;

    [Header("Ayarlar")]
    public bool atesEdebilirmi;
    float �ceridenAtesEtmeSikligi;
    public float disaridanAtesEtmeSikligi;
    public float menzil;

    [Header("Sesler")]
    public AudioSource FireSound;
    public AudioSource MermiBitti;

    [Header("Particle System")]
    public ParticleSystem gunsFireParticle;
    public ParticleSystem gunsFireParticle2;
    public ParticleSystem gunsFireParticle3;

    [Header("Animasyon")]
    public Animator animator;

    RaycastHit hit;

    private void FixedUpdate()
    {

        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, menzil, zombieLayer))
        {

            if (atesEdebilirmi && Time.time > �ceridenAtesEtmeSikligi && KalanMermiSayisi != 0)
            {
                Fire();
                animator.Play("Fire");

                �ceridenAtesEtmeSikligi = Time.time + disaridanAtesEtmeSikligi;
            }
            if (Time.time > �ceridenAtesEtmeSikligi && KalanMermiSayisi == 0)
            {
                MermiBitti.Play();
                �ceridenAtesEtmeSikligi = Time.time + disaridanAtesEtmeSikligi;
            }

           

        }
    }


    public void Fire()
    {
        gunsFireParticle.Play();
        gunsFireParticle2.Play(); 
        gunsFireParticle3.Play();
        FireSound.Play();
    }


}


