using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AtencionTramites.Model.Classes
{
	public class RangeIfAttribute : ValidationAttribute
	{
		private int _min { get; set; }

		private int _max { get; set; }

		private string _dependentProperty { get; set; }

		private object _targetValue { get; set; }

		private string _mensaje { get; set; }

		public RangeIfAttribute(int min, int max, string dependentProperty, object targetValue, string mensaje)
		{
			_min = min;
			_max = max;
			_dependentProperty = dependentProperty;
			_targetValue = targetValue;
			_mensaje = mensaje;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			RangeAttribute _innerAttribute = new RangeAttribute(_min, _max);
			_ = _mensaje;
			PropertyInfo field = validationContext.ObjectType.GetProperty(_dependentProperty);
			if (field != null)
			{
				object dependentValue = field.GetValue(validationContext.ObjectInstance, null);
				if (((dependentValue == null && _targetValue == null) || dependentValue.ToString() == _targetValue.ToString()) && !_innerAttribute.IsValid(value))
				{
					if (string.IsNullOrEmpty(_mensaje))
					{
						return new ValidationResult(validationContext.DisplayName + " out of range.");
					}
					return new ValidationResult(_mensaje);
				}
				return ValidationResult.Success;
			}
			return new ValidationResult(FormatErrorMessage(_dependentProperty));
		}
	}
}
