﻿using LarpakeServer.Data;
using LarpakeServer.Extensions;
using LarpakeServer.Identity;
using LarpakeServer.Models.DatabaseModels;
using LarpakeServer.Models.GetDtos;
using LarpakeServer.Models.QueryOptions;

namespace LarpakeServer.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
[RequiresPermissions(Permissions.CommonRead)]
public class StatisticsController : ExtendedControllerBase
{
    readonly IStatisticsService _statisticsService;
    readonly IFreshmanGroupDatabase _groupDb;

    public StatisticsController(
        IClaimsReader claimsReader,
        IStatisticsService statisticsService,
        IFreshmanGroupDatabase groupDb,
        ILogger<ExtendedControllerBase> logger) : base(claimsReader, logger)
    {
        _statisticsService = statisticsService;
        _groupDb = groupDb;
    }

    [HttpGet("users/points/average")]
    public async Task<IActionResult> GetAllAverage()
    {
        int? startYear = GetRequestUserStartYear();
        if (startYear is null)
        {
            return Unauthorized("User start year required.");
        }
        return await GetAllAverage(startYear.Value);
    }
    
    [HttpGet("users/{year}/points/average")]
    [RequiresPermissions(Permissions.ReadStatistics)]
    public async Task<IActionResult> GetAllAverage(int year)
    {
        long points = await _statisticsService.GetAveragePoints(year);
        return Ok(new { Points = points });
    }

    [HttpGet("users/points")]
    public async Task<IActionResult> GetAllTotal()
    {
        int? startYear = GetRequestUserStartYear();
        if (startYear is null)
        {
            return Unauthorized("User start year required.");
        }
        return await GetAllTotal(startYear.Value);
    }

    [HttpGet("users/{year}/points")]
    [RequiresPermissions(Permissions.ReadStatistics)]
    public async Task<IActionResult> GetAllTotal(int year)
    {
        long points = await _statisticsService.GetTotalPoints(year);
        return Ok(new { Points = points });
    }



    [HttpGet("users/self/points")]
    public async Task<IActionResult> GetUserTotal()
    {
        Guid userId = GetRequestUserId();
        return await GetUserTotal(userId);
    }

    [HttpGet("users/{userId}/points")]
    [RequiresPermissions(Permissions.ReadStatistics)]
    public async Task<IActionResult> GetUserTotal(Guid userId)
    {
        long? points = await _statisticsService.GetUserPoints(userId);
        return points is null
            ? IdNotFound() : Ok(new { Points = points });
    }

    [HttpGet("users/leading/points")]
    [RequiresPermissions(Permissions.ReadStatistics)]
    public async Task<IActionResult> GetLeadingUserPoints([FromQuery] QueryOptions options)
    {
        long[] records = await _statisticsService.GetLeadingUserPoints(options);
        return Ok(new LeadersGetDto<long>(records, options));
    }

    [HttpGet("users/leading")]
    [RequiresPermissions(Permissions.ReadStatistics)]
    public async Task<IActionResult> GetLeadingUsers([FromQuery] QueryOptions options)
    {
        var records = await _statisticsService.GetLeadingUsers(options);
        return Ok(new LeadersGetDto<UserPoints>(records, options));
    }



    [HttpGet("groups/{groupId}/points")]
    public async Task<IActionResult> GetFreshmanGroupTotal(int groupId)
    {
        /* User must have permissions to read 
         * statistics or be a member of the requested group
         */
        if (GetRequestPermissions().Has(Permissions.ReadStatistics))
        {
            Guid[]? groupMembers = await _groupDb.GetMembers(groupId);
            if (groupMembers is null)
            {
                return IdNotFound();
            }
            if (groupMembers.Contains(GetRequestUserId()) is false)
            {
                return Unauthorized("Not group member.");
            }
        }

        var result = await _statisticsService.GetFreshmanGroupPoints(groupId);
        return result is null
            ? IdNotFound() : Ok(result);
    }

    [HttpGet("groups/leading")]
    [RequiresPermissions(Permissions.ReadStatistics)]
    public async Task<IActionResult> GetLeadingFreshmanGroups([FromQuery] QueryOptions options)
    {
        var records = await _statisticsService.GetLeadingGroups(options);
        return Ok(new LeadersGetDto<GroupPoints>(records, options));
    }

}
