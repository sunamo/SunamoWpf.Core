using SunamoWpf._public;
using SunamoWpf.Storage;

namespace SunamoWpf.Core.Tests;

public class ApplicationDataContainerTests
{
    const string fileTest = @"D:\_Test\sunamo\Storage\ApplicationDataContainer\file.txt";
    Dictionary<string, ABWpf> testData = new Dictionary<string, ABWpf>();
    const string key1 = "k1";
    const string key2 = "k2";
    const string value1 = "Love";
    const int value2 = 0;

    public ApplicationDataContainerTests()
    {
        testData.Add(key1, new ABWpf(typeof(string).FullName!, value1));
        testData.Add(key2, new ABWpf(typeof(int).FullName!, value2));
    }

    [Fact]
    public void Save()
    {
        ApplicationDataContainer container = new ApplicationDataContainer(fileTest);

        foreach (var item in testData)
        {
            container.Values[item.Key] = item.Value.B;
        }
    }

    [Fact]
    public void Load()
    {
        Save();
        ApplicationDataContainer container = new ApplicationDataContainer(fileTest);

        foreach (var item in container.Values.GetItems())
        {
            if (testData.ContainsKey(item.Key))
            {
                testData.Remove(item.Key);
            }
        }

        Assert.Equal(0, testData.Count());
    }

    [Fact]
    public async Task Clear()
    {
        Save();
        ApplicationDataContainer container = new ApplicationDataContainer(fileTest);
        await container.Values.Nuke();

        container = new ApplicationDataContainer(fileTest);
        Assert.Equal(0, container.Values.GetItems().Count());
    }

    [Fact]
    public async Task DeleteEntry()
    {
        Save();

        ApplicationDataContainer container = new ApplicationDataContainer(fileTest);
        await container.Values.DeleteEntry(key1);

        container = new ApplicationDataContainer(fileTest);

        // Is really object, not ABWpf
        var value = container.Values[key2];
        Assert.Equal(value2, value);
        Assert.Equal(1, container.Values.GetItems().Count());
    }
}
