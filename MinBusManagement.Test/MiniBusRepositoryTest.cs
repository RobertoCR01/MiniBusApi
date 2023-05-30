using System;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MiniBusManagement.Domain.Models.Administration;
using MiniBusManagement.Repository.Administration;
using MiniBusManagement.Repository.Data;
using Moq;
using Xunit;

namespace MiniBusManagement.Test;

public class MiniBusRepositoryTest : IDisposable
{
    private readonly DbConnection _connection;
    private readonly DbContextOptions<ApplicationDbContext> _contextOptions;

    #region ConstructorAndDispose
    ApplicationDbContext CreateContext() => new ApplicationDbContext(_contextOptions);
    public void Dispose() => _connection.Dispose();
    public MiniBusRepositoryTest()
    {
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();
        _contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlite(_connection)
            .Options;

        // Create the schema and seed some data
        using var context = new ApplicationDbContext(_contextOptions);

        if (context.Database.EnsureCreated())
        {
            using var viewCommand = context.Database.GetDbConnection().CreateCommand();
            viewCommand.CommandText = @"
            CREATE VIEW AllResources AS
            SELECT Brand
            FROM Minibuses;";
            viewCommand.ExecuteNonQuery();
        }
        context.AddRange(
            new MiniBusDBEntity
            {
                Id = 10,
                IdCompany = 2,
                Capacity = "20",
                Brand = "Toyota",
                Tipo = "Van",
                Year = 2020,
                ModificationDate = It.IsAny<DateTime>(),
                InsertionDate = It.IsAny<DateTime>(),
                UserInsert = "Roberto",
                UserModifies = "Roberto",
            });

        context.SaveChanges();
    }
    #endregion

    [Fact]
    public void GetBusByIdSuccess()
    {
        using var context = CreateContext();
        var repository = new MinibusRepository(context);

        var result = repository.GetMinibusByID(10);
        Assert.NotNull(result);
        MiniBus miniBusResponse = result.Result;
        Assert.NotNull(miniBusResponse);
        Assert.Equal("Toyota", miniBusResponse.Brand);
    }

    [Fact]
    public void GetAllMiniBusesSuccess()
    {
        using var context = CreateContext();
        var repository = new MinibusRepository(context);

        var minibuses = repository.GetMinibus().Result;

        Assert.Equal(5, minibuses.Count());
        Assert.Collection(
            minibuses,
            b => Assert.Equal("Toyota", b.Brand),
            b => Assert.Equal("Mazada", b.Brand),
            b => Assert.Equal("Isuzu", b.Brand),
            b => Assert.Equal("Ford", b.Brand),
            b => Assert.Equal("Toyota", b.Brand)
            );
    }

    [Fact]
    public void InsertMiniBusSucess()
    {
        var miniBusInsert = new MiniBus
        {
            Id = 11,
            IdCompany = 2,
            Capacity = "20",
            Brand = "Toyota",
            Tipo = "Van",
            Year = 2020,
            ModificationDate = It.IsAny<DateTime>(),
            InsertionDate = It.IsAny<DateTime>(),
            UserInsert = "Roberto",
            UserModifies = "Roberto",
        };
        using var context = CreateContext();
        var repository = new MinibusRepository(context);

        var result = repository.InsertMinibus(miniBusInsert);
        Assert.NotNull(result);
        int statusCode = result.Result;
        Assert.Equal(201,statusCode);

    }

    [Fact]
    public void UpdateMiniBusSuccess()
    {
        var miniBusInsert = new MiniBus
        {
            Id = 10,
            IdCompany = 2,
            Capacity = "20",
            Brand = "Toyota",
            Tipo = "Van",
            Year = 2020,
            ModificationDate = It.IsAny<DateTime>(),
            InsertionDate = It.IsAny<DateTime>(),
            UserInsert = "Roberto",
            UserModifies = "Roberto",
        };
        using var context = CreateContext();
        var repository = new MinibusRepository(context);

        var result = repository.UpdateMinibus(miniBusInsert);
        Assert.NotNull(result);
        int statusCode = result.Result;
        Assert.Equal(204, statusCode);
    }
    [Fact]
    public void UpdateMiniBusBadRequest()
    {
        var miniBusInsert = new MiniBus
        {
            Id = 0,
            IdCompany = 2,
            Capacity = "20",
            Brand = "Toyota",
            Tipo = "Van",
            Year = 2020,
            ModificationDate = It.IsAny<DateTime>(),
            InsertionDate = It.IsAny<DateTime>(),
            UserInsert = "Roberto",
            UserModifies = "Roberto",
        };
        using var context = CreateContext();
        var repository = new MinibusRepository(context);

        var result = repository.UpdateMinibus(miniBusInsert);
        Assert.NotNull(result);
        int statusCode = result.Result;
        Assert.Equal(400, statusCode);
    }
    [Fact]
    public void UpdateMiniBusNotFound()
    {
        var miniBusInsert = new MiniBus
        {
            Id = 20,
            IdCompany = 2,
            Capacity = "20",
            Brand = "Toyota",
            Tipo = "Van",
            Year = 2020,
            ModificationDate = It.IsAny<DateTime>(),
            InsertionDate = It.IsAny<DateTime>(),
            UserInsert = "Roberto",
            UserModifies = "Roberto",
        };
        using var context = CreateContext();
        var repository = new MinibusRepository(context);

        var result = repository.UpdateMinibus(miniBusInsert);
        Assert.NotNull(result);
        int statusCode = result.Result;
        Assert.Equal(500, statusCode);
    }
}