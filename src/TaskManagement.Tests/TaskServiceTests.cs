using Moq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagement.Api.Data;
using TaskManagement.Api.Services;

namespace TaskManagement.Tests;

public class TaskServiceTests
{
    private readonly TaskService _service;
    private readonly ApplicationDbContext _context;

    public TaskServiceTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                      .UseInMemoryDatabase(databaseName: "TestDB").Options;
        _context = new ApplicationDbContext(options);
        _service = new TaskService(_context);
    }

    [Fact]
    public async Task GetTasksAsync_ShouldReturnEmptyList_WhenNoTasksExist()
    {
        var result = await _service.GetTasksAsync();
        Assert.Empty(result);
    }
}
