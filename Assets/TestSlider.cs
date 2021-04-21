using UnityEngine;
using UnityEngine.UI;

namespace KristinaWaldt
{
	public class TestSlider : MonoBehaviour
	{
		[SerializeField] protected IntObject currentObject;
		[SerializeField] protected IntObject maxObject;
		
		[SerializeField] protected MaxedIntObject maxedInt;

		private Image image;

		public AnimationCurve animationCurve;
		public Gradient gradient;
		
		public Color minColor = Color.red;
		public Color maxColor = Color.green;

		protected virtual void Awake()
		{
			SetupComponents();
			OnValueChanged();
		}

		protected virtual void OnEnable()
		{
			maxedInt.Subscribe(OnValueChanged);
			// currentObject.ValueChanged += OnValueChanged;
			// maxObject.ValueChanged += OnValueChanged;
		}
		
		protected virtual void OnDisable()
		{
			maxedInt.Unsubscribe(OnValueChanged);
			// currentObject.ValueChanged -= OnValueChanged;
			// maxObject.ValueChanged -= OnValueChanged;
		}

		private void OnValueChanged()
		{
			float percentage = (float)currentObject.RuntimeValue / maxObject.RuntimeValue;
			percentage = maxedInt.GetPercentage();
			ApplyChanges(percentage);
		}

		protected void SetupComponents()
		{
			image = GetComponent<Image>();
		}

		protected void ApplyChanges(float percentage)
		{
			image.fillAmount = percentage;

			float atCurve = animationCurve.Evaluate(percentage);
			image.color = Color.Lerp(minColor, maxColor, atCurve);
			
			image.color = gradient.Evaluate(percentage);

			float t = Mathf.InverseLerp(0.2f, 0.5f, percentage);
			image.color = Color.Lerp(minColor, maxColor, t);
		}
	}
}
