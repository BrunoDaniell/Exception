using Exception.Entities.Exceptions;

using System.Security.Principal;

namespace Exception.Entities
{
    internal class Reservation
    {

        public int RoomNumber { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        public Reservation()
        {
        }

        public Reservation(int roomNuber, DateTime checkIn, DateTime checkOut )
        {
             if (checkOut <= checkIn)
            {
                 throw new DomainException("Error in reervation: Check-out date must be after check-in.");
            }
            RoomNumber = roomNuber;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public int Duration()
        {
            TimeSpan durantion = CheckOut.Subtract( CheckIn );
            return (int)durantion.TotalDays;
        }

        public void UpdateDates(DateTime checkIn, DateTime checkOut)
        {

            DateTime now = DateTime.Now;
            if (checkIn < now || checkOut < now)
            {
                throw new DomainException("Error in reservetion: Reservation date for update must be future dates.");
            }

            if (checkOut <= checkIn)
            {
                 throw new DomainException("Error in reervation: Check-out date must be after check-in.");
            }


            CheckIn = checkIn;
            CheckOut = checkOut;
            
        }

        public override string ToString()
        {
            return "Room " + RoomNumber + ", check-in: " + CheckIn.ToString(" dd/MM/yyyy ") + CheckOut.ToString(" dd/MM/yyyy , ") + Duration() + " nights.";
        }
    }
}
