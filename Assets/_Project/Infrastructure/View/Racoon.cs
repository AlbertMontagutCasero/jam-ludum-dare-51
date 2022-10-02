using System;
using LudumDare51.Interactor;
using UnityEngine;

namespace LudumDare51.Infrastructure
{
    public class Racoon: MonoBehaviour
    {
        private bool isInside;

        private void Awake()
        {
            GameSignals.OnRacoonCaught += this.OnRacoonCaught;
        }

        private void OnDestroy()
        {
            GameSignals.OnRacoonCaught -= this.OnRacoonCaught;
        }

        private void OnRacoonCaught()
        {
            if (this.isInside)
            {
                Destroy(this.gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            this.isInside = true;

            var catchRacoonInteractor = InteractorServiceLocator.GetInstance().GetService<CatchRacoonInteractor>();
            catchRacoonInteractor.SetAsInsideRacoonRange();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            this.isInside = false;
            
            
            var catchRacoonInteractor = InteractorServiceLocator.GetInstance().GetService<CatchRacoonInteractor>();
            catchRacoonInteractor.SetAsOutsideRacoonRange();
        }
    }
}