public class Developer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int DevId { get; set; }
    public bool HasLicense { get; set; }

    public Developer() { }

    public Developer(string firstName, string lastName, int devId, bool hasLicense)
    {
        FirstName = firstName;
        LastName = lastName;
        DevId = devId;
        HasLicense = hasLicense;
    }
}