using System;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types.Enum;
using DG.Tweening;
using UnityEngine;

namespace Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon
{
    public abstract class UnitWeapon: MonoBehaviour
    {
        private Vector3 _cashedScale;

        public abstract WeaponType WeaponType
        {
            get;
        }

        protected abstract float ChangeDuration
        {
            get;
        }

        private void Awake()
        {
            _cashedScale = transform.localScale;
            transform.localScale = Vector3.zero;
        }

        public virtual void Activate()
        {
            transform.DOComplete();
            gameObject.SetActive(true);
            transform.DOScale(_cashedScale, ChangeDuration).SetEase(Ease.OutElastic);
        }

        public virtual void Deactivate()
        {
            transform.DOComplete();
            transform.DOScale(0f, ChangeDuration).SetEase(Ease.InElastic)
                .OnComplete((() => gameObject.SetActive(false)));
        }

        public virtual void PlayFx()
        {
            
        }
    }
}