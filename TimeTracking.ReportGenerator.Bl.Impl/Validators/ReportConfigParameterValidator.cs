using System;
using FluentValidation;
using TimeTracking.ReportGenerator.Models;

namespace TimeTracking.ReportGenerator.Bl.Impl.Validators
{
    public class ReportConfigParameterValidator:AbstractValidator<ReportConfiguration>
    {
        public ReportConfigParameterValidator()
        {
            RuleFor(x => x.ReportFormatType)
                .IsInEnum();
            
            RuleFor(x=>x.ReportParameters.FromDate)
                .DateInValidRange();
            
            RuleFor(x=>x.ReportParameters.ToDate)
                .DateInValidRange();

            RuleFor(x => x.ReportParameters.ProjectName)
                .NotNull()
                .NotEmpty();
            
            RuleFor(x => x.ReportParameters.UserId)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.ReportParameters.ReportType)
                .IsInEnum();
        }
      
    }
}