using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types.Enum;
using BuilderGame.Gameplay.Farms.Data;
using UnityEngine;

namespace Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types
{
    public class SeedsWeapon: UnitWeapon
    {
        [SerializeField]
        private ParticleSystem _fx;
        public override void PlayFx()
        {
            _fx.Play();
        }

        public override WeaponType WeaponType => WeaponType.Seeds;
        protected override float ChangeDuration => 0.7f;
    }
}