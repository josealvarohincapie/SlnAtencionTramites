using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace AtencionTramites.Model.Classes
{
	public class RequiredIfAttribute : ValidationAttribute
	{
		private readonly RequiredAttribute _innerAttribute = new RequiredAttribute();

		private string _dependentProperty { get; set; }

		private object _targetValue { get; set; }

		private string _mensaje { get; set; }

		public RequiredIfAttribute(string dependentProperty, object targetValue, string mensaje)
		{
			_dependentProperty = dependentProperty;
			_targetValue = targetValue;
			_mensaje = mensaje;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			_ = _mensaje;
			PropertyInfo field = validationContext.ObjectType.GetProperty(_dependentProperty);
			if (field != null)
			{
				object dependentValue = field.GetValue(validationContext.ObjectInstance, null);
				if (((dependentValue == null && _targetValue == null) || dependentValue.ToString() == _targetValue.ToString()) && !_innerAttribute.IsValid(value))
				{
					if (string.IsNullOrEmpty(_mensaje))
					{
						return new ValidationResult(validationContext.DisplayName + " Is required.");
					}
					return new ValidationResult(_mensaje);
				}
				return ValidationResult.Success;
			}
			return new ValidationResult(FormatErrorMessage(_dependentProperty));
		}
	}
}
