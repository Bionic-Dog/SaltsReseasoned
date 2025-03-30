using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned.CustomPassives
{
    class CustomPassives
    {
        public static void Add()
        {
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            PerformEffectPassiveAbility jumpy = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
            jumpy.m_PassiveID = "Jumpy_PA";
            jumpy.passiveIcon = ResourceLoader.LoadSprite("Jumpy");
            jumpy._characterDescription = "Upon being damaged, this party member will be randomly moved.";
            jumpy._enemyDescription = "Upon being damaged, this enemy will be randomly moved.";
            jumpy.effects =
                [
                    Effects.GenerateEffect(ScriptableObject.CreateInstance<MassSwapZoneEffect>(), 1, Targeting.Slot_SelfSlot),
                ];
            jumpy._triggerOn =
                [
                    TriggerCalls.OnDamaged,
                ];
            Passives.AddCustomPassiveToPool("Jumpy_PA", "Jumpy", jumpy);
            
        }
    }
}
