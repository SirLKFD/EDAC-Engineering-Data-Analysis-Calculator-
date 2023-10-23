public class StudentInfo
{
    private string name;
    private string id;
    private string yearOfBirth;
    private string monthOfBirth;
    private string dayOfBirth;

    public StudentInfo(string name, string id, string yearOfBirth, string monthOfBirth, string dayOfBirth)
    {
        this.name = name;
        this.id = id;
        this.yearOfBirth = yearOfBirth;
        this.monthOfBirth = monthOfBirth;
        this.dayOfBirth = dayOfBirth;
    }

    public string GetName()
    {
        return name;
    }

    public string GetStudentID()
    {
        return id;
    }

    public string GetYearOfBirth()
    {
        return yearOfBirth;
    }

    public string GetMonthOfBirth()
    {
        return monthOfBirth;
    }

    public string GetDayOfBirth()
    {
        return dayOfBirth;
    }

    public void SetMonthOfBirth(string month)
    {
        this.monthOfBirth = month;
    }

}
