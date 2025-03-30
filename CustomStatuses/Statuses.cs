using BrutalAPI;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SaltsEnemies_Reseasoned.CustomStatuses
{
    public class CustomStatuses
    {
        public static void Add()
        {
            if (!LoadedDBsHandler.StatusFieldDB.StatusEffects.ContainsKey("Anes_ID"))
            {
                StatusEffectInfoSO AnesInfo = ScriptableObject.CreateInstance<StatusEffectInfoSO>();
                AnesInfo._statusName = "Anesthetics";
                AnesInfo._description = "All damage, regardless of whether it is direct, will be reduced by the amount of Anesthetics upon being recieved. Anesthetics cannot reduce damage below 1. Decreases by 1 at the beginning of each turn. ";
                AnesInfo.icon = ResourceLoader.LoadSprite("Anesthetics");

                LoadedDBsHandler.StatusFieldDB.TryGetStatusEffect("Frail_ID", out StatusEffect_SO frail);
                StatusEffectInfoSO baseinfo = frail.EffectInfo;

                AnesInfo._applied_SE_Event = baseinfo._applied_SE_Event;
                AnesInfo._removed_SE_Event = baseinfo._removed_SE_Event;
                AnesInfo._updated_SE_Event = baseinfo._updated_SE_Event;

                Anesthetics anes = ScriptableObject.CreateInstance<Anesthetics>();
                anes._StatusID = "Anes_ID";
                anes._EffectInfo = AnesInfo;

                LoadedDBsHandler.StatusFieldDB.AddNewStatusEffect(anes, true);
                
                IntentInfoBasic AnestheticsIntent = new()
                {
                    _color = Color.white,
                    _sprite = ResourceLoader.LoadSprite("Anesthetics")
                };
                LoadedDBsHandler.IntentDB.AddNewBasicIntent("Status_Anesthetics", AnestheticsIntent);

                IntentInfoBasic AnestheticsRemIntent = new()
                {
                    _color = Color.gray,
                    _sprite = ResourceLoader.LoadSprite("Anesthetics")
                };
                LoadedDBsHandler.IntentDB.AddNewBasicIntent("Rem_Status_Anesthetics", AnestheticsRemIntent);
            }
        }
    }
    
}
