namespace Rooms.App.Dto
{
    public class PersonDto
    {
        public PersonDto(Guid id, string firstName, string lastName, DateTime birthDate, short yearsOld, Guid seatId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            YearsOld = yearsOld;
            BirthDate = birthDate;
            SeatId = seatId;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public short YearsOld { get; set; }
        public Guid SeatId { get; set; }
    }
}
