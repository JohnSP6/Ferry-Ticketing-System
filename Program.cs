using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

List<PassengerTicket> Passengers = [];
string? userInput;
string userChoice = "";
bool validOption;

do
{
    Console.Clear();
    Console.Write(@"
===============( Main Menu )===============
-------------------------------------------
        1. Purchase a Ticket 
-------------------------------------------
        2. View Seating Arrangement
-------------------------------------------
        3. Exit
-------------------------------------------
===========================================
Please Select an Option: ");

    userInput = Console.ReadLine();

    if (userInput != null) userChoice = userInput;

    switch (userChoice.Trim())
    {
        case "1":
            PurchaseTicket();
            validOption = false;
            break;
        case "2":
            ViewSeating();
            validOption = false;
            break;
        case "3":
            validOption = true;
            break;
        default:
            validOption = false;
            break;
    }

} while (!validOption);

Console.Clear();
Console.Write(@"
===========================================

     Thank you and Have a great day!

===========================================");
Console.ReadLine();

void PurchaseTicket()
{
    string passengerClass = "";

    do
    {
        Console.Clear();
        Console.Write(@"
===============( Choice of Class )===============
-------------------------------------------------
        1. Business Class 
-------------------------------------------------
        2. Economy Class
-------------------------------------------------
        3. Back
-------------------------------------------------
=================================================
Please Select an Option: ");

        userInput = Console.ReadLine();

        if (userInput != null) userChoice = userInput;

        switch (userChoice.Trim())
        {
            case "1":
                passengerClass = "Business Class";
                validOption = true;
                break;
            case "2":
                passengerClass = "Economy Class";
                validOption = true;
                break;
            case "3":
                return;
            default:
                validOption = false;
                break;
        }

    } while (!validOption);

    //here
    List<string> passengerNames = GetNames(passengerClass);

    //here
    string passengerDestination = GetDestination();

    //here
    string passengerDepartureDate = GetDate();

    //here
    string passengerDepartureTime = GetTime();

    List<string> seats = [];
    string[] ferrySeatingArrangement = [" B1", " B2", " B3", " B4", " B5", " B6", " B7", " B8", " B9", "B10", " E1", " E2", " E3", " E4", " E5", " E6", " E7", " E8", " E9", "E10", "E11", "E12", "E13", "E14", "E15", "E16", "E17", "E18", "E19", "E20", "E21", "E22", "E23", "E24", "E25", "E26", "E27", "E28", "E29", "E30", "E31", "E32", "E33", "E34", "E35", "E36", "E37", "E38", "E39", "E40"];
    string passengerSeat = "";
    string ferryID = PassengerTicket.GetFerryID(passengerDestination, passengerDepartureTime);
    bool validSeat;

    foreach (PassengerTicket passenger in Passengers)
    {
        if(ferryID == passenger.FerryID && passengerDepartureDate == passenger.DepartureDate)
        {
            ferrySeatingArrangement[Array.IndexOf(ferrySeatingArrangement, passenger.SeatNumber)] = " X ";
        }
    }

    for(int i = 0; i < ferrySeatingArrangement.Length; i++)
    {
        if (passengerClass == "Business Class")
        {
            if(i > 9)
            {
                ferrySeatingArrangement[i] = "---";
            }
        }
        else
        {
            if(i < 10)
            {
                ferrySeatingArrangement[i] = "---";
            }
        }
    }
    
    foreach (string passenger in passengerNames)
    {
        do
        {
            PrintSeatArrangement(ferrySeatingArrangement);
            Console.Write($"Please select a seat {(passengerNames.Count > 1 ? $"for {passenger} " : "")}({(passengerClass == "Business Class" ? "B1 - B10" : "E1 - E40")}): ");
            
            userInput = Console.ReadLine();
            if (userInput != null) passengerSeat = userInput.ToUpper().Trim();

            if (passengerSeat.Length < 3) passengerSeat = " " + passengerSeat;

            if(!ferrySeatingArrangement.Contains(passengerSeat) || passengerSeat.Contains('X') || passengerSeat.Contains('-'))
            {
                Console.WriteLine("\nSorry, Invalid seat");
                Console.ReadKey();
                validSeat = false;
            } 
            else
            {
                seats.Add(passengerSeat);
                ferrySeatingArrangement[Array.IndexOf(ferrySeatingArrangement, passengerSeat)] = " X ";
                validSeat = true;
            }


        } while (!validSeat);
    }

    Console.Clear();

    for(int i = 0; i < seats.Count; i++)
    {
        PassengerTicket passenger = new PassengerTicket(passengerNames[i], passengerClass, seats[i], passengerDepartureDate, passengerDepartureTime, passengerDestination);
        passenger.PrintTicket();
        Passengers.Add(passenger);
    }
    
    Console.ReadKey();

}

void ViewSeating()
{
    do
    {
        Console.Clear();
        Console.Write(@"
===============( Seating )=================
-------------------------------------------
    1. Seat Numbers & Arrangements
-------------------------------------------
    2. Booked Seats
-------------------------------------------
    3. Back
-------------------------------------------
===========================================
Please Select an Option: ");

        userInput = Console.ReadLine();

        if (userInput != null) userChoice = userInput;

        switch (userChoice.Trim())
        {
            case "1":
                string[] ferrySeatingArrangement = [" B1", " B2", " B3", " B4", " B5", " B6", " B7", " B8", " B9", "B10", " E1", " E2", " E3", " E4", " E5", " E6", " E7", " E8", " E9", "E10", "E11", "E12", "E13", "E14", "E15", "E16", "E17", "E18", "E19", "E20", "E21", "E22", "E23", "E24", "E25", "E26", "E27", "E28", "E29", "E30", "E31", "E32", "E33", "E34", "E35", "E36", "E37", "E38", "E39", "E40"];
                PrintSeatArrangement(ferrySeatingArrangement);
                Console.ReadKey();
                validOption = false;
                break;
            case "2":
                string[] bookedSeats = [" B1", " B2", " B3", " B4", " B5", " B6", " B7", " B8", " B9", "B10", " E1", " E2", " E3", " E4", " E5", " E6", " E7", " E8", " E9", "E10", "E11", "E12", "E13", "E14", "E15", "E16", "E17", "E18", "E19", "E20", "E21", "E22", "E23", "E24", "E25", "E26", "E27", "E28", "E29", "E30", "E31", "E32", "E33", "E34", "E35", "E36", "E37", "E38", "E39", "E40"];
                string destination = GetDestination();
                string date = GetDate();
                string time = GetTime();
                string ferryID = PassengerTicket.GetFerryID(destination, time);

                foreach (PassengerTicket passenger in Passengers)
                {
                    if(ferryID == passenger.FerryID && date == passenger.DepartureDate)
                    {
                        bookedSeats[Array.IndexOf(bookedSeats, passenger.SeatNumber)] = " X ";
                    }
                }
                
                PrintSeatArrangement(bookedSeats);

                Console.ReadKey();

                validOption = false;
                break;
            case "3":
                validOption = true;
                break;
            default:
                validOption = false;
                break;
        }
    } while (!validOption);
}

static void ClearCurrentLine(int space = 0)
{
    // Get the current cursor position
    var position = Console.GetCursorPosition();

    // Set the cursor to the last line (Top is zero-based)
    Console.SetCursorPosition(0, position.Top - space);

    // Clear the line by writing spaces
    Console.Write(new string(' ', Console.WindowWidth));
    
    // Reset the cursor position back to the beginning of the line
    Console.SetCursorPosition(0, position.Top - space);
}

void PrintSeatArrangement(string[] ferrySeatingArrangement)
{
    Console.Clear();
    Console.WriteLine($@"
                                      
*******************************************************************************************
*                                     BUSINESS CLASS                                      *
*******************************************************************************************
*       {ferrySeatingArrangement[0]}       *       {ferrySeatingArrangement[1]}       *       {ferrySeatingArrangement[2]}       *       {ferrySeatingArrangement[3]}       *       {ferrySeatingArrangement[4]}       *
*******************************************************************************************
*       {ferrySeatingArrangement[5]}       *       {ferrySeatingArrangement[6]}       *       {ferrySeatingArrangement[7]}       *       {ferrySeatingArrangement[8]}       *       {ferrySeatingArrangement[9]}       *
*******************************************************************************************
*                                     ECONOMY CLASS                                       *
*******************************************************************************************
*       {ferrySeatingArrangement[10]}       *       {ferrySeatingArrangement[11]}       *       {ferrySeatingArrangement[12]}       *       {ferrySeatingArrangement[13]}       *       {ferrySeatingArrangement[14]}       *
*******************************************************************************************
*       {ferrySeatingArrangement[15]}       *       {ferrySeatingArrangement[16]}       *       {ferrySeatingArrangement[17]}       *       {ferrySeatingArrangement[18]}       *       {ferrySeatingArrangement[19]}       *
*******************************************************************************************
*       {ferrySeatingArrangement[20]}       *       {ferrySeatingArrangement[21]}       *       {ferrySeatingArrangement[22]}       *       {ferrySeatingArrangement[23]}       *       {ferrySeatingArrangement[24]}       *
*******************************************************************************************
*       {ferrySeatingArrangement[25]}       *       {ferrySeatingArrangement[26]}       *       {ferrySeatingArrangement[27]}       *       {ferrySeatingArrangement[28]}       *       {ferrySeatingArrangement[29]}       *
*******************************************************************************************
*       {ferrySeatingArrangement[30]}       *       {ferrySeatingArrangement[31]}       *       {ferrySeatingArrangement[32]}       *       {ferrySeatingArrangement[33]}       *       {ferrySeatingArrangement[34]}       *
*******************************************************************************************
*       {ferrySeatingArrangement[35]}       *       {ferrySeatingArrangement[36]}       *       {ferrySeatingArrangement[37]}       *       {ferrySeatingArrangement[38]}       *       {ferrySeatingArrangement[39]}       *
*******************************************************************************************
*       {ferrySeatingArrangement[40]}       *       {ferrySeatingArrangement[41]}       *       {ferrySeatingArrangement[42]}       *       {ferrySeatingArrangement[43]}       *       {ferrySeatingArrangement[44]}       *
*******************************************************************************************
*       {ferrySeatingArrangement[45]}       *       {ferrySeatingArrangement[46]}       *       {ferrySeatingArrangement[47]}       *       {ferrySeatingArrangement[48]}       *       {ferrySeatingArrangement[49]}       *
*******************************************************************************************");
}

string GetDestination()
{
    string passengerDestination = "";

    do
    {
        Console.Clear();
        Console.Write(@"
===================( Destination )====================
------------------------------------------------------
       1. Pulau Langkawi  --->  Pulau Pinang 
------------------------------------------------------
       2. Pulau Pinang    --->  Pulau Langkawi 
------------------------------------------------------
======================================================
Please Select an Option: ");

        userInput = Console.ReadLine();

        if (userInput != null) userChoice = userInput;

        switch (userChoice.Trim())
        {
            case "1":
                validOption = true;
                return passengerDestination= "Pulau Langkawi  --->  Pulau Pinang";
            case "2":
                validOption = true;
                return passengerDestination = "Pulau Pinang    --->  Pulau Langkawi";
            default:
                validOption = false;
                break;
        }

    } while (!validOption);

    return passengerDestination;

}

string GetDate()
{
    string passengerDepartureDate = "";

    do
    {
        Console.Clear();
        Console.Write($@"
===================( Date of Departure )====================
------------------------------------------------------
       1. {DateTime.Now.AddDays(1):MMMM dd, yyyy}    ({DateTime.Now.AddDays(1).DayOfWeek})
------------------------------------------------------
       2. {DateTime.Now.AddDays(2):MMMM dd, yyyy}    ({DateTime.Now.AddDays(2).DayOfWeek})
------------------------------------------------------
       3. {DateTime.Now.AddDays(3):MMMM dd, yyyy}    ({DateTime.Now.AddDays(3).DayOfWeek})
------------------------------------------------------
       4. {DateTime.Now.AddDays(4):MMMM dd, yyyy}    ({DateTime.Now.AddDays(4).DayOfWeek})
------------------------------------------------------
       5. {DateTime.Now.AddDays(5):MMMM dd, yyyy}    ({DateTime.Now.AddDays(5).DayOfWeek})
------------------------------------------------------
       6. {DateTime.Now.AddDays(6):MMMM dd, yyyy}    ({DateTime.Now.AddDays(6).DayOfWeek})
------------------------------------------------------
       7. {DateTime.Now.AddDays(7):MMMM dd, yyyy}    ({DateTime.Now.AddDays(7).DayOfWeek})
------------------------------------------------------
       8. {DateTime.Now.AddDays(8):MMMM dd, yyyy}    ({DateTime.Now.AddDays(8).DayOfWeek})
------------------------------------------------------
======================================================
Please Select an Option: ");

        userInput = Console.ReadLine();

        if (userInput != null) userChoice = userInput;

        switch (userChoice.Trim())
        {
            case "1":
                
                validOption = true;
                return passengerDepartureDate = DateTime.Now.AddDays(1).ToString("MMMM dd, yyyy");
            case "2":
                validOption = true;
                return passengerDepartureDate = DateTime.Now.AddDays(2).ToString("MMMM dd, yyyy");
            case "3":
                validOption = true;
                return passengerDepartureDate = DateTime.Now.AddDays(3).ToString("MMMM dd, yyyy");
            case "4":
                validOption = true;
                return passengerDepartureDate = DateTime.Now.AddDays(4).ToString("MMMM dd, yyyy");
            case "5":
                validOption = true;
                return passengerDepartureDate = DateTime.Now.AddDays(5).ToString("MMMM dd, yyyy");
            case "6":
                validOption = true;
                return passengerDepartureDate = DateTime.Now.AddDays(6).ToString("MMMM dd, yyyy");
            case "7":
                validOption = true;
                return passengerDepartureDate = DateTime.Now.AddDays(7).ToString("MMMM dd, yyyy");
            case "8":
                validOption = true;
                return passengerDepartureDate = DateTime.Now.AddDays(8).ToString("MMMM dd, yyyy");
            default:
                validOption = false;
                break;
        }

    } while (!validOption);

    return passengerDepartureDate;
}

string GetTime()
{
    string passengerDepartureTime = "";

    do
    {
        Console.Clear();
        Console.Write($@"
=========================( Time of Departure )========================
----------------------------------------------------------------------
1. (10:00 a.m.)   2. (11:00 a.m.)   3. (12:00 p.m.)   4. ( 1:00 p.m.)
----------------------------------------------------------------------
5. ( 2:00 p.m.)   6. ( 3:00 p.m.)   7. ( 4:00 p.m.)   8. ( 5:00 p.m.)
----------------------------------------------------------------------
======================================================================
Please Select an Option: ");

        userInput = Console.ReadLine();

        if (userInput != null) userChoice = userInput;

        switch (userChoice.Trim())
        {
            case "1":
                validOption = true;
                return passengerDepartureTime = "10:00 a.m.";
            case "2":
                validOption = true;
                return passengerDepartureTime = "11:00 a.m.";
            case "3":
                validOption = true;
                return passengerDepartureTime = "12:00 p.m.";
            case "4":
                validOption = true;
                return passengerDepartureTime = " 1:00 p.m.";
            case "5":
                validOption = true;
                return passengerDepartureTime = " 2:00 p.m.";
            case "6":
                validOption = true;
                return passengerDepartureTime = " 3:00 p.m.";
            case "7":
                validOption = true;
                return passengerDepartureTime = " 4:00 p.m.";
            case "8":
                validOption = true;
                return passengerDepartureTime = " 5:00 p.m.";
            default:
                validOption = false;
                break;
        }

    } while (!validOption);

    return passengerDepartureTime;
}

List<string> GetNames(string passengerClass)
{
    string adultTicket = "";
    int adultNumber;
    
    string childTicket = "";
    int childNumber;
    
    string seniorTicket = "";
    int seniorNumber;
    
    string passengerName = "";

    int availableSeats = passengerClass == "Business Class" ? 10 : 40;

    bool validName;
    bool validNumber;

    List<string> passengerNames = [];

    do
    {
        Console.Clear();
        Console.Write($@"
=====================( Ticket Pricing: {passengerClass} )=====================

1. Adult                -      ${(passengerClass == "Business Class" ? "60" : "30")}
2. Child                -      ${(passengerClass == "Business Class" ? "30" : "15")}
3. Senior Citizen       -      ${(passengerClass == "Business Class" ? "40" : "20")}

==============================================================================

Please enter the number of tickets for each field. 
[NOTE: If you do not wish to buy a ticket for a specific field, press 'Enter'] 

Adult          : ");

        userInput = Console.ReadLine();

        if (userInput != null) adultTicket = userInput;
        if (adultTicket.Trim() == "") 
        {
            adultNumber = 0;
            validNumber = true;
        }
        else validNumber = int.TryParse(adultTicket, out adultNumber);

        //If user puts more than 10
        if(validNumber && adultNumber > availableSeats)
        {
            validNumber = false;
            Console.WriteLine("______________________________________________________________________________\nSorry, there are not enough seats.");
            Console.ReadKey();
        }
        else if (validNumber && adultNumber < availableSeats) availableSeats -= adultNumber;
        
    } while (!validNumber);

    do
    {
        Console.Write("Child          : ");
        userInput = Console.ReadLine();

        if (userInput != null) childTicket = userInput;

        if (childTicket.Trim() == "") 
        {
            childNumber = 0;
            validNumber = true;
        }
        else validNumber = int.TryParse(childTicket, out childNumber);
        
        if(validNumber && childNumber > availableSeats)
        {
            validNumber = false;
            Console.WriteLine("______________________________________________________________________________\nSorry, there are not enough seats.");
            Console.ReadKey();
        }
        else if (validNumber && childNumber < availableSeats) availableSeats -= childNumber;

        if(!validNumber) ClearCurrentLine(1);

    } while (!validNumber);

    do
    {
        Console.Write("Senior Citizen : ");
        userInput = Console.ReadLine();

        if (userInput != null) seniorTicket = userInput;
        if (seniorTicket.Trim() == "")
        {
            seniorNumber = 0;
            validNumber = true;
        }
        else validNumber = int.TryParse(seniorTicket, out seniorNumber);
        
        if(validNumber && seniorNumber > availableSeats)
        {
            validNumber = false;
            Console.WriteLine("______________________________________________________________________________\nSorry, there are not enough seats.");
            Console.ReadKey();
        }
        else if (validNumber && seniorNumber < availableSeats) availableSeats -= seniorNumber;

        if(!validNumber) ClearCurrentLine(1);

    } while (!validNumber);

    Console.WriteLine("______________________________________________________________________________");
    Console.WriteLine($"\nNumber of tickets purchased: {adultNumber + childNumber + seniorNumber}");
    Console.WriteLine($"Total: ${((passengerClass == "Business Class" ? 60 : 30) * adultNumber) + ((passengerClass == "Business Class" ? 30 : 15) * childNumber) + ((passengerClass == "Business Class" ? 40 : 20) * seniorNumber)}");
    Console.WriteLine("______________________________________________________________________________");

    for(int i = 0; i < (adultNumber + childNumber + seniorNumber); i++)
    {
        do{
        Console.Write($"\nFull Name [Guest {i + 1}]: ");
        
        userInput = Console.ReadLine();

        if(userInput != null)
        {
            passengerName = userInput.Trim();
        }

        if (passengerName == "") 
        {
            validName = false;
            ClearCurrentLine(2);
        }
        else
        {
            validName = true;
            passengerNames.Add(passengerName);
            Console.WriteLine("______________________________________________________________________________");
        }

        } while (!validName);

    }
    
    return passengerNames;
}

//ADDED REQUIREMENTS
//- Check if the ferry has enough space before having the passenger select time or date
//- Check if the child is accompanied alone in the ticket payment
//- Check if the total number of tickets DOES NOT exceed available seats [DONE]
//- Make a save file to get and write to
//- Fix allignment

//STUFF I MISSED
//- Didn't add check to see if no person bought any ticket 
//- Vanessa is being nice to me now





