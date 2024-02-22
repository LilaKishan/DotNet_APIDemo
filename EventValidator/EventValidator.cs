using APIDemo.Models;
using FluentValidation;

namespace APIDemo.EventValidator
{
    public class EventValidator : AbstractValidator<EventModel>
    {
        public EventValidator() {
            //RuleFor(EventModel => EventModel.EventDate)
            //    .NotEmpty().WithMessage("Eventdate is not empty")
            //     .NotNull().WithMessage("Eventdate is not null")
            //     .DependentRules(RuleFor(EventModel=> EventModel.EventDate).));
            RuleFor(EventModel => EventModel.EventDate)
                .GreaterThan(DateTime.Now).WithMessage("");
            RuleFor(EventModel => EventModel.EventDate)
                .LessThan(DateTime.Now.AddDays(30)).WithMessage("");
            RuleFor(EventModel => EventModel.EventDate)
                .Must(date => date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday).WithMessage("");
            RuleFor(EventModel => EventModel.EventDate)
                .InclusiveBetween(DateTime.Now, DateTime.Now.AddMonths(1)).WithMessage("");

            //RuleFor(EventModel => EventModel.EventDate)
            //    .When(EventModel => EventModel.EventDate == "2003-09-20");



        }

    }
}

//Eventdate must be futuredate
//    Eventdate must be only within next 30 days
//    Eventdate must not be on sunday and saturday
//    Eventdate must be within nextmonth