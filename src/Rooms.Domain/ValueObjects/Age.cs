using Flunt.Notifications;
using Flunt.Validations;
using Rooms.Domain.Enums;

namespace Rooms.Domain.ValueObjects;

public class Age : Notifiable<Notification>
{
    private const long MIN_YEARS_OLD = 0;
    private const long MAX_YEARS_OLD = 120;

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
                MIN_YEARS_OLD,
                nameof(YearsOld),
                $"Age must be at least {MIN_YEARS_OLD} years old."
            )
            .IsLowerThan
            (
                YearsOld,
                MAX_YEARS_OLD,
                nameof(YearsOld),
                $"Age must be less than {MAX_YEARS_OLD} years old."
            )
            .AreNotEquals
            (
                AgeGroup,
                EAgeGroup.Undefined,
                nameof(EAgeGroup),
                "The age group cannot be undefined."
            )
        );
    }

    public DateTime BirthDate { get; private set; }
    public long YearsOld {get; private set;}
    public EAgeGroup AgeGroup {get; private set;}

    public void DefineYearsOld()
    {
        DateTime today = DateTime.Now;
        long yearsOld = BirthDate.Year - today.Year;

        if(BirthDate.Date > today.Date)
            yearsOld--;

        YearsOld = yearsOld;
    }

    public void DefineAgeGroup()
    {
        if(YearsOld >= MIN_YEARS_OLD && YearsOld <= 17)
        {
            AgeGroup = EAgeGroup.Child;
        }
        else if(YearsOld >= 18 && YearsOld <= 64)
        {
            AgeGroup = EAgeGroup.Child; 
        }
        else if(YearsOld >= 65 && YearsOld <= MAX_YEARS_OLD)
        {
            AgeGroup = EAgeGroup.Elderly;
        }
        else
        {
            AgeGroup = EAgeGroup.Undefined;
        }
    }
}