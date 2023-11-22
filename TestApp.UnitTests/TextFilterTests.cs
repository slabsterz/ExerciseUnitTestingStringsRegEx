using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class TextFilterTests
{
    
    [Test]
    public void Test_Filter_WhenNoBannedWords_ShouldReturnOriginalText()
    {
        // Arrange
        string[] banned = Array.Empty<string>();
        string text = "The quick brown fox jumps over the lazy dog";

        // Act
        string result = TextFilter.Filter(banned, text);

        // Assert
        Assert.That(result, Is.EqualTo(text));
    }

    [Test]
    public void Test_Filter_WhenBannedWordExists_ShouldReplaceBannedWordWithAsterisks()
    {
        // Arrange
        string[] banned = new[] { "fox" };
        string text = "The quick brown fox jumps over the lazy dog";
        string expected = "The quick brown *** jumps over the lazy dog";

        // Act
        string result = TextFilter.Filter(banned, text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Filter_WhenBannedWordsAreEmpty_ShouldReturnOriginalText()
    {
        // Arrange
        string[] banned = new string[] {  };
        string text = "The quick brown fox jumps over the lazy dog";

        // Act
        string result = TextFilter.Filter(banned, text);

        // Assert
        Assert.That(result, Is.EqualTo(text));
    }

    [Test]
    public void Test_Filter_WhenBannedWordsContainWhitespace_ShouldReplaceBannedWord()
    {
        // Arrange
        string[] banned = new[] { " dog" };
        string text = "The quick brown fox jumps over the lazy dog";
        string expected = "The quick brown fox jumps over the lazy****";

        // Act
        string result = TextFilter.Filter(banned, text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
