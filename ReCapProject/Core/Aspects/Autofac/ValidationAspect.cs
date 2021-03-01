using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac
{
    public class ValidationAspect: MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("Doğrulama sınıfı değil");
            }
            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); // CarValidator
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; // Car
            var invocationParameters = invocation.Arguments.Where(i => i.GetType() == entityType);
            foreach (var parameter in invocationParameters)
            {
                ValidationTool.Validate(validator, parameter);
            }
        }
    }
}
