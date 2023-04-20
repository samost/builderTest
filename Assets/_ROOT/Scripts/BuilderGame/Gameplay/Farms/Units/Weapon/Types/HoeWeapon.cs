using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types.Enum;
using DG.Tweening;

namespace Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types
{
    public class HoeWeapon: UnitWeapon
    {
        public override WeaponType WeaponType => WeaponType.Hoe;
        protected override float ChangeDuration => 0.5f;
    }
}