using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Akari
{
    public class UILoadingForm : UILoadingFormSign
    {
        private EventCenter EventManager;

        public override void Init()
        {
            base.Init();

            EventManager = GameEntry.Event;

            InitUIData();
        }

        public override void Open()
        {
            base.Open();

            EventManager.AddEventListener<float>(EventType.ProgressBarUpdate, ProgressBarUpdate);
        }

        public override void Close()
        {
            base.Close();

            EventManager.RemoveEventListener<float>(EventType.ProgressBarUpdate, ProgressBarUpdate);
        }

        private void ProgressBarUpdate(float value)
        {
            imgProgress.fillAmount = value;
        }
    }
}
