using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))//validatorType bir IValidator mı?
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//Çalışma anında instance oluşturmak
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];// AbstractValidator(BaseType)'ın ilk argümanı (product vs..)
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//Methodun(Add vs..) argümanlarını gez, oradaki bir tip  entityType a eşitse onları validate et.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
