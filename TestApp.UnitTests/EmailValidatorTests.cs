using NUnit.Framework;

namespace TestApp.UnitTests;

public class EmailValidatorTests
{

    [TestCase("peter09@gmail.com")]
    [TestCase("STEVEN+007@yahoo.de")]
    [TestCase("Anastacia%Roghard@yahoo.dede")]
    public void Test_ValidEmails_ReturnsTrue(string email)
    {
        // Arrange

        // Act
        bool result = EmailValidator.IsValidEmail(email);

        // Assert
        Assert.That(result, Is.True);
    }

    //"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
    [TestCase("peter09()petrov@gmail.com")]
    [TestCase("peter09@gmail.c")]
    [TestCase("peter@petrov@gmail.c")]
    [TestCase("peter@petrov@yahoo.com")]
    public void Test_InvalidEmails_ReturnsFalse(string email)
    {
        // Arrange

        // Act
        bool result = EmailValidator.IsValidEmail(email);
        
        // Assert
        Assert.That(result, Is.False);
    }
}
