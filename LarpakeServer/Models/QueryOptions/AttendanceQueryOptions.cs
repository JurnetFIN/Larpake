﻿namespace LarpakeServer.Models.QueryOptions;

public class AttendanceQueryOptions : QueryOptions
{
    public DateTime? Before { get; set; } = null;
    public DateTime? After { get; set; } = null;
    public long? EventId { get; set; } = null;
    public Guid? UserId { get; set; } = null;
    public bool? IsCompleted { get; set; } = null;


    public override bool HasNonNullValues()
    {
        return Before is not null 
            || After is not null 
            || EventId is not null 
            || UserId is not null 
            || IsCompleted is not null;
    }
}
