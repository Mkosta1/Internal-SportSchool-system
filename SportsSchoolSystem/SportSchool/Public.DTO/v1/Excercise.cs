﻿namespace Public.DTO.v1.v1;

public class Excercise
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;
    
    public int Duration { get; set; } = default!;
    
    public string Level { get; set; } = default!;
}