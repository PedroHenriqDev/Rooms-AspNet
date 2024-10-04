using Flunt.Notifications;
using Flunt.Validations;
using Rooms.Domain.Enums;
using Rooms.Domain.Validations;

namespace Rooms.Domain.ValueObjects;

public class Age : Notifiable<Notification>
{
    public Age(DateTime birthDate)
    {
        BirthDate = birthDate;

        DefineYearsOld();
        DefineAgeGroup();

        AddNotifications
        (
            new Contract<Age>()
            .Requires()
            .IsGreaterThan
            (
                YearsOld,
                ValidationsRules.MIN_YEARS_OLD,
                nameof(YearsOld),
                string.Format(ValidationMessagesResource.AGE_LEAST_MESSAGE, ValidationsRules.MIN_YEARS_OLD)
            )
            .IsLowerThan
            (
                YearsOld,
                ValidationsRules.MAX_YEARS_OLD,
                nameof(YearsOld),
                string.Format(ValidationMessagesResource.AGE_LESS_MESSAGE, ValidationsRules.MAX_YEARS_OLD)
            )
            .AreNotEquals
            (
                AgeGroup,
                EAgeGroup.Undefined,
                nameof(EAgeGroup),
                ValidationMessagesResource.AGE_UNDEFINED_MESSAGE
            )
        );
    }

    public DateTime BirthDate { get; private set; }
    public long YearsOld {get; private set;}
    public EAgeGroup AgeGroup {get; private set;}

    public void DefineYearsOld()
    {
        DateTime today = DateTime.Now;
        long yearsOld = today.Year - BirthDate.Year;

        if(BirthDate.Date > today.Date)
            yearsOld--;

        YearsOld = yearsOld;
    }

    public void DefineAgeGroup()
    {
        if(YearsOld >= ValidationsRules.MIN_YEARS_OLD && YearsOld <= 17)
        {
            AgeGroup = EAgeGroup.Child;
        }
        else if(YearsOld >= 18 && YearsOld <= 64)
        {
            AgeGroup = EAgeGroup.Child; 
        }
        else if(YearsOld >= 65 && YearsOld <= ValidationsRules.MAX_YEARS_OLD)
        {
            AgeGroup = EAgeGroup.Elderly;
        }
        else
        {
            AgeGroup = EAgeGroup.Undefined;
        }
    }
}