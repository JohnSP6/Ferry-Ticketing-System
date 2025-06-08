public class PassengerTicket
{
    //FIELDS & PROPERTIES
    public string Name { get; set; } //Passenger's name
    public string Class { get; set; }// Business or Economy Class
    public string SeatNumber { get; set; }//Seat number (B1 - E40)
    public string DepartureDate { get; set; }
    public string DepartureTime { get; set; }
    public string Destination { get; set; }
    public string FerryID { get; set; }
    public DateTime BookingTime { get; private set; }

    //CONSTRUCTORS
    public PassengerTicket(string name, string classSection, string seatNumber, string departureDate, string departureTime, string destination)
    {
        this.Name = name;
        this.Class = classSection;
        this.SeatNumber = seatNumber;
        this.DepartureDate = departureDate;
        this.DepartureTime = departureTime;
        this.Destination = destination;
        this.FerryID = GetFerryID(destination, departureTime);
        this.BookingTime = DateTime.Now;
        
    }

    //METHODS
    public static string GetFerryID(string destination, string time)
    {
        string ferryID = "";

        if(destination == "Pulau Langkawi  --->  Pulau Pinang") ferryID = "A";
        else ferryID = "B";

        switch(time)
        {
            case "10:00 a.m.":
                ferryID += "001";
                break;
            case "11:00 a.m.":
                ferryID += "002";
                break;
            case "12:00 p.m.":
                ferryID += "003";
                break;
            case " 1:00 p.m.":
                ferryID += "004";
                break;
            case " 2:00 p.m.":
                ferryID += "005";
                break;
            case " 3:00 p.m.":
                ferryID += "006";
                break;
            case " 4:00 p.m.":
                ferryID += "007";
                break;
            case " 5:00 p.m.":
                ferryID += "008";
                break;
        }
        return ferryID;
    }

    public void PrintTicket()
    {
        Console.WriteLine($@"
===================( Boarding Pass )====================
--------------------------------------------------------
Name           : {this.Name.ToUpper()}
Class          : {this.Class.ToUpper()}
Seat No.       : {this.SeatNumber.Trim()}
Departure Date : {this.DepartureDate}
Departure Time : {this.DepartureTime.Trim()}
Destination    : {this.Destination}
Ferry ID       : {this.FerryID}
Booking Time   : {this.BookingTime}
--------------------------------------------------------
========================================================");
        Console.WriteLine("\n");
    }
}