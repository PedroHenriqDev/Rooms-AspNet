namespace Rooms.App.Dto
{
    public class PersonDto
    {
        public PersonDto(string firstName, string lastName, DateTime birthDate, short yearsOld, Guid seatId)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            YearsOld = yearsOld;
            BirthDate = birthDate;
            SeatId = seatId;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public short YearsOld { get; set; }
        public Guid SeatId { get; set; }
    }
}
