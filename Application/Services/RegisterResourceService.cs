using Infrastructure.Services;

namespace Application.Services;

public class RegisterResourceService
{
    private readonly SqlManager _sqlManager;

    public RegisterResourceService(SqlManager sqlManager)
    {
        _sqlManager = sqlManager;
    }

    public async Task ExecuteAsync(string contentPath)
    {
        var directory = new DirectoryInfo(@$"{contentPath}/Scripts"); //Assuming Test is your Folder
        var sqlFiles = directory.GetFiles("*.sql");

        foreach (var sqlFile in sqlFiles)
        {
            var sql = await File.ReadAllTextAsync(sqlFile.FullName);
            _sqlManager.Add(sqlFile.Name, sql);
        }
    }
}
