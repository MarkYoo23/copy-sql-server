using Domain.Models.Masters;
using Infrastructure.Services.Tables;

namespace Infrastructure.Test.Services.Tables;

public class UnconstrainedTableQueryFactoryTest
    : IClassFixture<TableQueryFactory>
{
    private readonly TableQueryFactory _factory;

    public UnconstrainedTableQueryFactoryTest(TableQueryFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public void CreateTableScript_GeneratesCorrectQuery_WhenStringWith100Length()
    {
        var columns = new List<TableColumn>()
        {
            new()
            {
                Name = "StringColumnName",
                Datatype = "nvarchar",
                StringLength = 100,
                IsIdentity = false,
                IsNullable = false,
                IsPrimaryKey = false,
                ColumnDefault = null!,
            }
        };

        var query = _factory.ToQuery("sample", columns);
        Assert.Contains($"[StringColumnName] [nvarchar](100) NOT NULL", query);
    }

    [Fact]
    public void CreateTableScript_GeneratesCorrectQuery_WhenStringWithMaxLength()
    {
        var columns = new List<TableColumn>()
        {
            new()
            {
                Name = "StringColumnName",
                Datatype = "nvarchar",
                StringLength = -1,
                IsIdentity = false,
                IsNullable = false,
                IsPrimaryKey = false,
                ColumnDefault = null!,
            }
        };

        var query = _factory.ToQuery("sample", columns);
        Assert.Contains($"[StringColumnName] [nvarchar](max) NOT NULL", query);
    }

    [Fact]
    public void CreateTableScript_GeneratesCorrectQuery_WhenInt()
    {
        var columns = new List<TableColumn>()
        {
            new()
            {
                Name = "IntColumnName",
                Datatype = "int",
                StringLength = null,
                IsIdentity = false,
                IsNullable = false,
                IsPrimaryKey = false,
                ColumnDefault = null!,
            }
        };

        var query = _factory.ToQuery("sample", columns);
        Assert.Contains($"[IntColumnName] [int] NOT NULL", query);
    }

    [Fact]
    public void CreateTableScript_GeneratesCorrectQuery_WhenIntWithPrimaryAndIdentity()
    {
        var columns = new List<TableColumn>()
        {
            new()
            {
                Name = "IntColumnName",
                Datatype = "int",
                StringLength = null,
                IsIdentity = true,
                IsNullable = false,
                IsPrimaryKey = true,
                ColumnDefault = null!,
            }
        };

        var query = _factory.ToQuery("sample", columns);
        Assert.Contains($"[IntColumnName] [int] NOT NULL IDENTITY,", query);
        Assert.Contains($"CONSTRAINT [PK_sample] PRIMARY KEY ([IntColumnName])", query);
    }
}
