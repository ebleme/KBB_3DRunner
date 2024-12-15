using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ebleme.KBB3DRunner
{
    public class EnergyBar : MonoBehaviour
    {
        [SerializeField] private float maxValue = 100;
        [SerializeField] private float minValue = 0;

        [SerializeField] private Slider energySlider;

        [SerializeField] private float decreaseSpeed = 1f;
        [SerializeField] private float decreaseDelay = 1f;

        [SerializeField] private Image sliderFillImage;
        [SerializeField] private Color lowColor = Color.red; // %25
        [SerializeField] private Color midColor = Color.yellow; // %50
        [SerializeField] private Color maxColor = Color.green; // %90
        [SerializeField] private Color fullColor = Color.blue; // %100

        private float currentEnergy;

        public float CurrentEnergyForMoveFactor()
        {
            var energyPercentage = currentEnergy / maxValue;
            return Mathf.Clamp(energyPercentage, 1f / 2, 1);
        }

        private bool isDecreasing = false;

        private void Start()
        {
            energySlider.minValue = minValue;
            energySlider.maxValue = maxValue;
        }

        public void Set(float currentEnergy)
        {
            this.currentEnergy = currentEnergy;
            isDecreasing = true;
        }

        /// <summary>
        /// Öldürmeyen engeller enerjiyi azaltır
        /// </summary>
        /// <param name="val"></param>
        public void Decrease(float val)
        {
            currentEnergy -= val;
            ClampEnergyValue();
            SetSlider();
        }

        /// <summary>
        /// Collectables toplayınca çağırılır
        /// </summary>
        /// <param name="val"></param>
        public void Increase(float val)
        {
            currentEnergy += val;
            ClampEnergyValue();
            SetSlider();

            // 1 sn sonra isDecreasing olabilir

            Invoke(nameof(StartDecreasing), decreaseDelay);
        }

        private void StartDecreasing()
        {
            isDecreasing = true;
        }


        private void ClampEnergyValue()
        {
            currentEnergy = Mathf.Clamp(currentEnergy, minValue, maxValue);
        }

        private void Update()
        {
            if (isDecreasing)
            {
                Decrease(decreaseSpeed * Time.deltaTime);
            }
        }

        private void SetSlider()
        {
            energySlider.value = currentEnergy;

            switch (currentEnergy)
            {
                case < 25:
                    sliderFillImage.color = lowColor;
                    break;
                case < 50:
                    sliderFillImage.color = midColor;
                    break;
                case < 90:
                    sliderFillImage.color = maxColor;
                    break;
                case <= 100:
                    sliderFillImage.color = fullColor;
                    break;
            }
        }


        //Test
        [ContextMenu("IncreaseTest")]
        public void IncreaseTest()
        {
            Increase(50);
        }
    }
}