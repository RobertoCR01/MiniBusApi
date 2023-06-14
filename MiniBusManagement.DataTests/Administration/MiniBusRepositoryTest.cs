using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MiniBusManagement.Data.Repositories.Administration;
using MiniBusManagement.Data.Repositories;
using MiniBusManagement.Domain.Models.Administration;
using MiniBusManagement.Repositories.Entities.Administration;
using Moq;
using Xunit;
using AutoMapper;


namespace MiniBusManagement.Test;

public class MiniBusRepositoryTest : IDisposable
{
    private readonly DbConnection _connection;
    private readonly DbContextOptions<ApplicationDbContext> _contextOptions;
    private readonly IMapper _mapper;

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
        new CompanyDBEntity
            {
                Id = 1,
                ContactNumber = "2655666",
                ContactName = "Roberto Diaz",
                City = "San Jose",
                Address = "359 Avon",
                Email = "Roberto@gmail.com",
                Name = "Prueba",
                Phone = "25655656",
                InsertionDate = DateTime.Now,
                ModificationDate = DateTime.Now,
                UserInsert = "Roberto",
                UserModifies = "RobertoM"
            });
        context.AddRange(
        new MiniBusDBEntity
            {
                Id = 10,
                Company= new CompanyDBEntity { Id = 1 },
                Plate="Pak715",
                Capacity = 20,
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
        var repository = new MinibusRepository(context,_mapper);

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
        var repository = new MinibusRepository(context, _mapper);

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
            Company = new Company
            {
                Id = 1,
            },
            Capacity = 20,
            Brand = "Toyota",
            Tipo = "Van",
            Year = 2020,
            ModificationDate = It.IsAny<DateTime>(),
            InsertionDate = It.IsAny<DateTime>(),
            UserInsert = "Roberto",
            UserModifies = "Roberto",
        };
        using var context = CreateContext();
        var repository = new MinibusRepository(context, _mapper);

        var result = repository.InsertMinibus(miniBusInsert);
        Assert.NotNull(result);
        int statusCode = result.Result;
        Assert.Equal(201, statusCode);

    }

    [Fact]
    public void UpdateMiniBusSuccess()
    {
        var miniBusInsert = new MiniBus
        {
            Id = 10,
            Company = new Company
            {
                Id = 1,
            },
            Capacity = 20,
            Brand = "Toyota",
            Tipo = "Van",
            Year = 2020,
            ModificationDate = It.IsAny<DateTime>(),
            InsertionDate = It.IsAny<DateTime>(),
            UserInsert = "Roberto",
            UserModifies = "Roberto",
        };
        using var context = CreateContext();
        var repository = new MinibusRepository(context, _mapper);

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
            Company = new Company
            {
                Id = 1,
            },
            Capacity = 20,
            Brand = "Toyota",
            Tipo = "Van",
            Year = 2020,
            ModificationDate = It.IsAny<DateTime>(),
            InsertionDate = It.IsAny<DateTime>(),
            UserInsert = "Roberto",
            UserModifies = "Roberto",
        };
        using var context = CreateContext();
        var repository = new MinibusRepository(context, _mapper);

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
            Company = new Company
            {
                Id = 1,
            },
            Capacity = 20,
            Brand = "Toyota",
            Tipo = "Van",
            Year = 2020,
            ModificationDate = It.IsAny<DateTime>(),
            InsertionDate = It.IsAny<DateTime>(),
            UserInsert = "Roberto",
            UserModifies = "Roberto",
        };
        using var context = CreateContext();
        var repository = new MinibusRepository(context, _mapper);

        var result = repository.UpdateMinibus(miniBusInsert);
        Assert.NotNull(result);
        int statusCode = result.Result;
        Assert.Equal(500, statusCode);
    }
}