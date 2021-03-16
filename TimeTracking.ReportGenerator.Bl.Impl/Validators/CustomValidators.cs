using System;
using System.Collections.Generic;
using FluentValidation;

namespace TimeTracking.ReportGenerator.Bl.Impl.Validators
{
    public static  class CustomValidators
    {
        private  static DateTime MinDateValue =  DateTime.Parse("01/01/2001");
        private static DateTime MaxDateValue = DateTime.UtcNow;
        public static IRuleBuilderOptions<T, DateTime> DateInValidRange<T>(this IRuleBuilder<T,DateTime> ruleBuilder) {
            return ruleBuilder
                .Must(DataTimeInRange)
                .WithMessage($"Data must be in range from '{MaxDateValue.ToShortDateString()}'to '{MaxDateValue.ToShortDateString()}");
                      
        }
        private static bool DataTimeInRange(DateTime value)
        {
            return (value > MinDateValue)&& (value < MaxDateValue);
        }
    }
}