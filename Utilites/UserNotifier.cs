using AutoTestsForApplications.Interfaces;

namespace AutoTestsForApplications;

public class UserNotifier
{
    private readonly IEmailSender _sender;

    public UserNotifier(IEmailSender sender)
    {
        _sender = sender;
    }

    public void Notify(int userId)
    {
        _sender.Send("user@mail.com", $"Hello, user {userId}!");
    }
}