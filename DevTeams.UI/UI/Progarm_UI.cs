using static System.Console;

public class Program_UI
{
    private DeveloperRepository _developerRepoUI = new DeveloperRepository();
    private DeveloperTeamRepository _devTeamRepoUI = new DeveloperTeamRepository();

    private bool isRunning = true;

    public void Run()
    {
        SetContent();
        DevMenu();
    }

    private void DevMenu()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("== Welcome to Komodo DevTeams ==\n" +
            "-------------------------\n" +
            "Select a Menu Option:\n" +
            "-------------------------\n" +
            "1. Create a New Development Team\n" +
            "2. Create a New Developer\n" +
            "3. View Development Teams\n" +
            "4. View Existing Development Teams + Members\n" +
            "5. View Existing Developers\n" +
            "6. Add Developer to a Development Team\n" +
            "7. Remove a Development Team\n" +
            "8. Remove a Developer\n" +
            "9. Update a Developer\n" +
            "10. Update a Development Team\n" +
            "11. View Developers Needing Pluralsight Access\n" +
            "-------------------------\n" +
            "0. Close Application\n");

            var userInput = ReadLine();
            switch (userInput)
            {
                case "1":
                    CreateDevTeam();
                    break;
                case "2":
                    CreateNewDeveloper();
                    break;
                case "3":
                    DisplayIndTeam();
                    break;
                case "4":
                    DisplayAllDevTeams();
                    break;
                case "5":
                    DisplayAllDevelopers();
                    break;
                case "6":
                    AddDevToTeam();
                    break;
                case "7":
                    RemoveDevTeam();
                    break;
                case "8":
                    RemoveDeveloper();
                    break;
                case "9":
                    UpdateDeveloper();
                    break;
                case "10":
                    UpdateDevTeam();
                    break;
                case "11":
                    PluarlLic();
                    break;
                case "0":
                    isRunning = CloseSystem();
                    break;
                default:
                    System.Console.WriteLine("The number you selected isn't an option...please enter a valid number.");
                    break;
            }
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            Console.Clear();
        }
    }

    private bool CloseSystem()
    {
        System.Console.WriteLine("Now closing the system...");
        PressAnyKeyToContinue();
        return false;
    }

    private void PressAnyKeyToContinue()
    {
        System.Console.WriteLine("Press any key to continue...");
        ReadKey();
    }

    private void CreateDevTeam()
    {
        bool exitMethodCrTe = true;
        while (exitMethodCrTe)
        {
            Console.Clear();
            DevTeam newDevTeam = new DevTeam();

            Console.WriteLine("\nEnter a Name for the New Development Team.");
            string devTeamName = Console.ReadLine();

            newDevTeam.DevTeamName = devTeamName;

            Console.WriteLine("\nEnter the Development Team ID #: 1 to 10");
            string devTeamStr = Console.ReadLine();

            int devTeamIdInt = Convert.ToInt32(devTeamStr);
            newDevTeam.DevTeamId = CheckTeamIdRange(devTeamIdInt);

            Console.WriteLine("\nType \"Exit\" When Finished with Entries.");
            string exitCreDevTeam = Console.ReadLine().ToLower();

            bool createDevTeam = _devTeamRepoUI.AddDevTeamToList(newDevTeam);

            if (createDevTeam == true)
            {
                Console.WriteLine("\nDevelopment Teams Added.");
            }

            if (exitCreDevTeam == "exit")
            {
                exitMethodCrTe = false;
            }
        }
    }

    private void CreateNewDeveloper()
    {
        bool exitMethodCr = true;
        while (exitMethodCr)
        {
            Console.Clear();
            Developer newDeveloper = new Developer();

            Console.WriteLine("\nEnter the Developer's First Name.");
            string firstNameStr = Console.ReadLine();
            newDeveloper.FirstName = firstNameStr;

            Console.WriteLine("\nEnter the Developer's Last Name.");
            string LastNameStr = Console.ReadLine();
            newDeveloper.LastName = LastNameStr;

            Console.WriteLine("\nEnter the Developer's ID #: 1 to 30.");
            string devIdStr = Console.ReadLine();
            newDeveloper.DevId = CheckDevIdRange(Convert.ToInt32(devIdStr));

            int devIdInt = Convert.ToInt32(devIdStr);

            Console.WriteLine("\nEnter (Yes/No) if the Developer *Posseses a Pluralsight License.");
            string devLicense = Console.ReadLine().ToLower();

            if (devLicense == "yes")
            {
                newDeveloper.HasLicense = true;
            }
            else
            {
                newDeveloper.HasLicense = false;
            }

            bool addDeveloper = _developerRepoUI.AddDeveloperToList(newDeveloper);

            Console.WriteLine("\nType \"Exit\" When Finished with Entries.");
            string exitCreDev = Console.ReadLine().ToLower();

            if (addDeveloper == true)
            {
                Console.WriteLine("\nDevelopers Added.");
            }

            if (exitCreDev == "exit")
            {
                exitMethodCr = false;
            }
        }
    }

    private void DisplayIndTeam()
    {
        Console.Clear();
        List<DevTeam> listIndDevT = _devTeamRepoUI.GetDevTeams();

        foreach (DevTeam devTe in listIndDevT)
        {
            Console.WriteLine($"\nDevelopment Team Name: {devTe.DevTeamName}" +
                $"\nDevelopment Team ID Number: {devTe.DevTeamId}");

        }
    }

    private void DisplayAllDevTeams()
    {
        Console.Clear();
        List<DevTeam> listofDevTeams = _devTeamRepoUI.GetDevTeams();

        foreach (DevTeam devTeams in listofDevTeams)
        {
            Console.WriteLine($"\nDevelopment Team ID Number: {devTeams.DevTeamId}" +
                $"\nDevelopment Team Name: {devTeams.DevTeamName}");
            foreach (Developer dev in devTeams.DevTeamMembers)
            {
                Console.WriteLine($"\nDeveloper ID#: {dev.DevId}" +
                    $"\nDeveloper First Name: {dev.FirstName}" +
                    $"\nDeveloper Last Name: {dev.LastName}");
            }
        }
    }

    private void DisplayAllDevelopers()
    {
        Console.Clear();
        List<Developer> listofDevelopers = _developerRepoUI.GetDevelopers();

        foreach (Developer developer in listofDevelopers)
        {
            Console.WriteLine($"\nDeveloper ID Number: {developer.DevId}" +
                $"\nDeveloper First Name: {developer.FirstName}" +
                $"\nDeveloper Last Name: {developer.LastName}" +
                $"\nDeveloper Has a License: {developer.HasLicense}\n");
        }
    }

    private void AddDevToTeam()
    {
        bool exitMethodAddTe = true;
        while (exitMethodAddTe)
        {
            Console.Clear();
            List<Developer> addDevelopers = _developerRepoUI.GetDevelopers();
            List<DevTeam> devAddTeam = _devTeamRepoUI.GetDevTeams();

            DisplayBoth();

            Console.WriteLine("\nPlease Enter Developer ID # (1 to 30): \n");
            string localDev = Console.ReadLine();
            int localDevId = CheckDevIdRange(Convert.ToInt32(localDev));

            Console.WriteLine($"\nPlease Enter the Development Team Number to Assign Developer.");
            string localDevTeamStr = Console.ReadLine();

            int localDevTeamId = Convert.ToInt32(localDevTeamStr);

            DevTeam checkedDevId = _devTeamRepoUI.GetDevTeamId(localDevTeamId);

            foreach (DevTeam developerId in devAddTeam)
            {
                if (localDevTeamId <= 10)
                {
                    if (checkedDevId == null)
                    {
                        Console.WriteLine($"\nDeveloper Number: {localDev} Added to Development Team Number: {localDevTeamStr}\n");
                        _devTeamRepoUI.AddDevTeamMember(localDevTeamId);
                        Thread.Sleep(1500);
                    }
                    else
                    {
                        Console.WriteLine($"\nDeveloper Number: {localDev} is Already Assigned Development Team.\n");
                        Thread.Sleep(1500);
                    }
                }
                else
                {
                    Console.WriteLine("\nPlease Enter a Valid Development Team ID #:\n");

                }

                Console.WriteLine("\nType \"Exit\" When Finished with Entries.");
                string exitMethDis = Console.ReadLine().ToLower();

                if (exitMethDis == "exit")
                {
                    exitMethodAddTe = false;
                }
            }
        }
    }

    private void RemoveDevTeam()
    {
        List<DevTeam> removeDevTeam = _devTeamRepoUI.GetDevTeams();

        Console.Clear();

        DisplayIndTeam();

        Console.WriteLine("\nEnter the Development Team ID #:(1-10) for Removal.\n");
        string removeDevTeamID = Console.ReadLine();

        int removeDevTeamInt = Convert.ToInt32(removeDevTeamID);

        _devTeamRepoUI.RemoveDevTeamFromList(removeDevTeamInt);
    }

    private void RemoveDeveloper()
    {
        List<Developer> removeDeveloper = _developerRepoUI.GetDevelopers();

        Console.Clear();

        DisplayAllDevelopers();

        Console.WriteLine("\nEnter the Developer ID #:(1-30) for Removal.\n");
        int removeDevId = Convert.ToInt32(Console.ReadLine());

        bool confirmDevDel = _developerRepoUI.RemoveDeveoperFromList(removeDevId);

        if (confirmDevDel == true)
        {
            Console.WriteLine($"\n2nd Confirmation, Development Team {confirmDevDel} was Removed.\n");

        }
    }

    private void UpdateDeveloper()
    {
        Developer newDev = new Developer();

        Console.Clear();

        DisplayAllDevelopers();

        Console.WriteLine("\nEnter the ID Number of Developer for Updating.");
        int originId = Convert.ToInt32(Console.ReadLine());

        Developer oldDev = _developerRepoUI.GetDeveloperId(originId);

        Console.WriteLine("\nEnter the Developer's New ID #: 1 to 30.");
        newDev.DevId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\nEnter the Developer's New First Name.");
        newDev.FirstName = Console.ReadLine();

        Console.WriteLine("\nEnter the Developer's New Last Name.");
        newDev.LastName = Console.ReadLine();

        Console.WriteLine("\nEnter (Yes/No) if the Developer *Possesses a Pluralsight License.");
        string newLic = Console.ReadLine().ToLower();

        if (newLic == "yes")
        {
            newDev.HasLicense = true;
        }
        else
        {
            newDev.HasLicense = false;
        }

        _developerRepoUI.UpdateDevelopers(oldDev, newDev);
    }

    private void UpdateDevTeam()
    {
        DevTeam newTeam = new DevTeam();

        Console.Clear();

        DisplayIndTeam();

        Console.WriteLine("\nEnter the Development Team ID Number for Updating.");
        int teOriginId = Convert.ToInt32(Console.ReadLine());

        DevTeam oldDev = _devTeamRepoUI.GetDevTeamId(teOriginId);

        Console.WriteLine("\nEnter the Development Team NEW ID #: 1 to 10");
        newTeam.DevTeamId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("\nEnter the NEW Name for the Development Team.");
        newTeam.DevTeamName = Console.ReadLine();

        newTeam.DevTeamMembers = oldDev.DevTeamMembers;

        _devTeamRepoUI.UpdateDevTeams(oldDev, newTeam);
    }

    private void PluarlLic()
    {
        Console.Clear();

        List<Developer> pluralDev = _developerRepoUI.GetDevoperPlural();

        foreach (Developer dev in pluralDev)
        {
            Console.WriteLine($"\nDeveloper ID: {dev.DevId}" +
                $"\nFirst Name: {dev.FirstName}" +
                $"\nLast Name: {dev.LastName}.\n");
        }
    }

    // DATA VERIFICATION 

    public int CheckDevIdRange(int idNumCheck)
    {
        if (idNumCheck <= 30)
        {
            return idNumCheck;
        }
        else
        {
            Console.WriteLine("\nPlease Re-Enter the Developer's ID #: 1 to 30.\n");
            string devIdStrRe = Console.ReadLine();

            idNumCheck = Convert.ToInt32(devIdStrRe);
            return idNumCheck;
        }
    }

    private int CheckTeamIdRange(int idTeamCheck)
    {
        if (idTeamCheck <= 10)
        {
            return idTeamCheck;
        }
        else
        {
            Console.WriteLine("\nPlease Re-Enter the Developer's ID #: 1 to 10.\n");
            string devIdStrRe = Console.ReadLine();

            idTeamCheck = Convert.ToInt32(devIdStrRe);
            return idTeamCheck;
        }
    }

    private void DisplayBoth()
    {
        List<Developer> displayBoth = _developerRepoUI.GetDevelopers();
        List<DevTeam> displayTeam = _devTeamRepoUI.GetDevTeams();

        foreach (Developer dev in displayBoth)
        {
            Console.WriteLine($"\nDeveloper ID Number: {dev.DevId}" +
                $"\nDeveloper First Name: {dev.FirstName}" +
                $"\nDeveloper Last Name: {dev.LastName}" +
                $"\nDeveloper Has a License: {dev.HasLicense}\n");
        }

        foreach (DevTeam devTeam in displayTeam)
        {
            Console.WriteLine($"\nDevelopment Team Name: {devTeam.DevTeamName}" +
            $"\nDevelopment Team ID Number: {devTeam.DevTeamId}");

        }
    }

    private void SetContent()
    {
        Developer dev1 = new Developer("Jack", "NeedsLicense", 1, false);
        Developer dev2 = new Developer("John", "NeedsLicense", 2, false);
        Developer dev3 = new Developer("Paul", "Jones", 3, true);
        Developer dev4 = new Developer("Jason", "Williams", 4, false);
        Developer dev5 = new Developer("Jack", "Daniels", 5, true);
        Developer dev6 = new Developer("Jamie", "Smith", 6, true);
        Developer dev7 = new Developer("James", "Bond", 7, true);

        _developerRepoUI.AddDeveloperToList(dev1);
        _developerRepoUI.AddDeveloperToList(dev2);
        _developerRepoUI.AddDeveloperToList(dev3);
        _developerRepoUI.AddDeveloperToList(dev4);
        _developerRepoUI.AddDeveloperToList(dev5);
        _developerRepoUI.AddDeveloperToList(dev6);
        _developerRepoUI.AddDeveloperToList(dev7);

        List<Developer> devTeamMem1 = new List<Developer>();
        devTeamMem1.Add(dev1);
        devTeamMem1.Add(dev2);
        devTeamMem1.Add(dev3);

        List<Developer> devTeamMem2 = new List<Developer>();
        devTeamMem2.Add(dev4);
        devTeamMem2.Add(dev5);
        devTeamMem2.Add(dev6);

        List<Developer> devTeamMem3 = new List<Developer>();
        devTeamMem3.Add(dev1);
        devTeamMem3.Add(dev4);
        devTeamMem3.Add(dev7);

        List<Developer> devTeamMem4 = new List<Developer>();
        devTeamMem4.Add(dev2);
        devTeamMem4.Add(dev3);
        devTeamMem4.Add(dev5);
        devTeamMem4.Add(dev7);

        DevTeam devT1 = new DevTeam("DevTeamOne", 1, devTeamMem1);
        DevTeam devT2 = new DevTeam("DevTeamTwo", 2, devTeamMem2);
        DevTeam devT3 = new DevTeam("DevTeamThree", 3, devTeamMem3);
        DevTeam devT4 = new DevTeam("DevTeamFour", 4, devTeamMem4);

        _devTeamRepoUI.AddDevTeamToList(devT1);
        _devTeamRepoUI.AddDevTeamToList(devT2);
        _devTeamRepoUI.AddDevTeamToList(devT3);
        _devTeamRepoUI.AddDevTeamToList(devT4);
    }
}