public class DeveloperRepository
{
    public List<Developer> _developerDirectory = new List<Developer>();

    // Creation
    public bool AddDeveloperToList(Developer developer)
    {
        int initialDevsCount = _developerDirectory.Count();
        _developerDirectory.Add(developer);

        if(_developerDirectory.Count > initialDevsCount)
        {
            return true;
        } 
        else 
        {
            return false;
        }
    }

    // Read Developer
    public List<Developer> GetDevelopers()
    {
        return _developerDirectory;
    }

    // Update Developer
    public bool UpdateDevelopers(Developer oldDev, Developer newDev)
    {
        if (oldDev != null)
        {
            oldDev.FirstName = newDev.FirstName;
            oldDev.LastName = newDev.LastName;
            oldDev.DevId = newDev.DevId;
            oldDev.HasLicense = newDev.HasLicense;
            return true;

        }
        else
        {
            return false;
        }
    }

    // Delete Developer
    public bool RemoveDeveoperFromList(int devId)
    {
        Developer removeDevId = GetDeveloperId(devId);

        int intialDevIdCount = _developerDirectory.Count;
        _developerDirectory.Remove(removeDevId);

        if(intialDevIdCount > _developerDirectory.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Getting Developer by ID
    public Developer GetDeveloperId(int idNum)
    {
        foreach (Developer developer in _developerDirectory)
        {
            if (developer.DevId == idNum)
            {
                return developer;
            }
        }
            return null;
    }

    public List<Developer> GetDevoperPlural()
    {
        List<Developer> pluralDevId = new List<Developer>();

        foreach (Developer developer in _developerDirectory)
        {                
            if(developer.HasLicense == false)
            {
                pluralDevId.Add(developer);
            }
        }
            return pluralDevId;
    }
}
