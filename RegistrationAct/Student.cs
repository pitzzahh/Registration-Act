namespace RegistrationAct;

public class Student
{
    public long? StudentNumber { get; init; }
    public string? FullName { get; init; }
    public string? Program { get; init; }
    public string? Gender { get; init; }
    public byte? Age { get; init; }
    public string? BirthDay { get; init; }
    public long? ContactNumber { get; init; }

    public override string ToString()
    {
        return $"Student Number: {StudentNumber}\n" +
               $"Full Name: {FullName}\n" +
               $"Program: {Program}\n" +
               $"Gender: {Gender}\n" +
               $"Age: {Age}\n" +
               $"Birthday: {BirthDay}\n" +
               $"Contact Number: {ContactNumber}\n";
    }
}