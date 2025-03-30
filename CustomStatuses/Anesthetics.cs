using System;
using System.Collections.Generic;
using System.Text;

namespace SaltsEnemies_Reseasoned.CustomStatuses
{
    public class Anesthetics : StatusEffect_SO
    {
        // Token: 0x0600000D RID: 13 RVA: 0x00002608 File Offset: 0x00000808
        public override void OnTriggerAttached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.AddObserver(new Action<object, object>(holder.OnEventTriggered_01), TriggerCalls.OnBeingDamaged.ToString(), caller);
            CombatManager.Instance.AddObserver(new Action<object, object>(holder.OnEventTriggered_02), TriggerCalls.OnTurnFinished.ToString(), caller);
            //CombatManager.Instance.AddObserver(new Action<object, object>(holder.OnEventTriggered_03), TriggerCalls.OnDirectDamaged.ToString(), caller);
        }

        // Token: 0x0600000E RID: 14 RVA: 0x00002690 File Offset: 0x00000890
        public override void OnTriggerDettached(StatusEffect_Holder holder, IStatusEffector caller)
        {
            CombatManager.Instance.RemoveObserver(new Action<object, object>(holder.OnEventTriggered_01), TriggerCalls.OnBeingDamaged.ToString(), caller);
            CombatManager.Instance.RemoveObserver(new Action<object, object>(holder.OnEventTriggered_02), TriggerCalls.OnTurnFinished.ToString(), caller);
            //CombatManager.Instance.RemoveObserver(new Action<object, object>(holder.OnEventTriggered_03), TriggerCalls.OnDirectDamaged.ToString(), caller);
        }

        // Token: 0x0600000F RID: 15 RVA: 0x00002718 File Offset: 0x00000918
        public override void OnEventCall_01(StatusEffect_Holder holder, object sender, object args)
        {
            DamageReceivedValueChangeException ex = args as DamageReceivedValueChangeException;
            bool flag = !ex.directDamage;
            if (!flag)
            {
                if(ex.amount - holder.m_ContentMain < 1)
                {
                    int maybeThisWillHelpIFuckingGuess = ex.amount;
                    int anesNewValue = maybeThisWillHelpIFuckingGuess - 1;
                    ex.AddModifier(new SubstractionValueModifier(false, anesNewValue));
                }
                else
                {
                    ex.AddModifier(new SubstractionValueModifier(false, holder.m_ContentMain));
                }
                    
            }
        }

        // Token: 0x06000010 RID: 16 RVA: 0x00002753 File Offset: 0x00000953
        public override void OnEventCall_02(StatusEffect_Holder holder, object sender, object args)
        {
            this.ReduceDuration(holder, sender as IStatusEffector);
        }

        // Token: 0x06000011 RID: 17 RVA: 0x00002764 File Offset: 0x00000964

        // Token: 0x06000012 RID: 18 RVA: 0x00002778 File Offset: 0x00000978
        public override void ReduceDuration(StatusEffect_Holder holder, IStatusEffector effector)
        {
            bool flag = !base.CanReduceDuration;
            if (!flag)
            {
                int contentMain = holder.m_ContentMain;
                holder.m_ContentMain -= 1;
                bool flag2 = !this.TryRemoveStatusEffect(holder, effector) && contentMain != holder.m_ContentMain;
                if (flag2)
                {
                    effector.StatusEffectValuesChanged(this._StatusID, holder.m_ContentMain - contentMain, false);
                }
            }
        }

        // Token: 0x06000013 RID: 19 RVA: 0x000027E0 File Offset: 0x000009E0

    }
}
