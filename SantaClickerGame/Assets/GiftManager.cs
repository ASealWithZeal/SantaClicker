using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class GiftManager : Singleton<GiftManager>
    {
        public int gifts = 0;
        public int NLTGifts = 0;
        public float months = 12;
        public float monthsPerClick = 1.0f;
        public float monthsPerSecond = 0.0f;
        public UIManager ui = null;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            ui.CheckHiredButtons(gifts, NLTGifts);
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();

            DecreaseMonths();
            CheckNLT();
        }

        private void DecreaseMonths()
        {
            months -= (monthsPerSecond * Time.deltaTime);
            CheckEarnGifts();
            ui.SetText(gifts, Mathf.CeilToInt(months), monthsPerSecond);
        }

        /// <summary>
        /// If the player reaches or exceeds the Naughty List Threshold, restart the game
        /// </summary>
        private void CheckNLT()
        {
            if (gifts >= NLTGifts)
            {
                gifts = 0;
                months = 12;
                monthsPerSecond = 0;

                ui.UnhireButtons();
                ui.UnpurchaseButtons();
                ui.SetText(gifts, Mathf.CeilToInt(months), monthsPerSecond);
            }
        }

        public void HitSanta()
        {
            months -= monthsPerClick;
            CheckEarnGifts();

            ui.SetText(gifts, Mathf.CeilToInt(months), monthsPerSecond);
        }

        private void CheckEarnGifts()
        {
            float n = months;
            if (months <= 0)
            {
                months = (12 + n);
                SetGifts(1);
            }
        }

        public void Hire(int cost, float increment)
        {
            SetGifts(-cost);
            monthsPerSecond += increment;
            ui.SetText(gifts, Mathf.CeilToInt(months), monthsPerSecond);
        }

        public void IncreaseMonthsPerClick(int cost, float increment)
        {
            SetGifts(-cost);
            monthsPerClick += increment;
            ui.SetText(gifts, Mathf.CeilToInt(months), monthsPerSecond);
        }

        public void DonateGifts()
        {
            // Increases NLT and resets gifts, months, and months per second
            NLTGifts += gifts;
            gifts = 0;
            months = 12;
            monthsPerSecond = 0;

            // Resets buttons and text
            ui.UnhireButtons();
            ui.NLT[1].SetText(NLTGifts.ToString());
            ui.SetText(gifts, Mathf.CeilToInt(months), monthsPerSecond);
        }

        private void SetGifts(int inc)
        {
            gifts += inc;
        }
    }
}