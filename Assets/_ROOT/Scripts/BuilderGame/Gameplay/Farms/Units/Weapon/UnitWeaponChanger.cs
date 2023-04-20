using System;
using System.Linq;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon;
using Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units.Weapon.Types.Enum;
using UnityEngine;

namespace Assets._ROOT.Scripts.BuilderGame.Gameplay.Farms.Units
{
    [Serializable]
    public class UnitWeaponChanger
    {
        private UnitWeapon _currentWeapon;
        
        [SerializeField]
        private UnitWeapon[] _unitWeapons;

        public UnitWeapon CurrentWeapon => _currentWeapon;

        public void ChangeWeapon(WeaponType changedWeaponType)
        {
            if (_currentWeapon?.WeaponType == changedWeaponType)
            {
                return;
            }

            _currentWeapon?.Deactivate();
            _currentWeapon = null;

            if (changedWeaponType == WeaponType.Hands)
            {
                return;
            }
            
            _currentWeapon = _unitWeapons.FirstOrDefault(w => w.WeaponType == changedWeaponType);
            _currentWeapon?.Activate();
        }
        
    }
}